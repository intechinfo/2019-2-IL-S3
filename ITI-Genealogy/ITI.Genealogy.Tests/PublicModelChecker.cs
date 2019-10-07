using ITI.Genealogy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ITI.Genealogy.Tests
{
    [TestFixture]
    public class PublicModelChecker
    {
        [Test]
        [Explicit]
        public void write_current_public_API_to_console_with_double_quotes()
        {
            Console.WriteLine( GetPublicAPI( typeof( FamilyTree ).Assembly ).ToString().Replace( "\"", "\"\"" ) );
        }

        [Test]
        public void public_API_is_not_modified()
        {
            var model = XElement.Parse( @"<Assembly Name=""ITI.Genealogy"">
  <Types>
    <Type Name=""ITI.Genealogy.ChildOptions"">
      <Member Type=""Constructor"" Name="".ctor"" />
      <Member Type=""Constructor"" Name="".ctor"" />
      <Member Type=""Constructor"" Name="".ctor"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
    <Type Name=""ITI.Genealogy.FamilyTree"">
      <Member Type=""Constructor"" Name="".ctor"" />
      <Member Type=""Method"" Name=""Breed"" />
      <Member Type=""Method"" Name=""CreateAncestor"" />
      <Member Type=""Method"" Name=""CreateAncestor"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Method"" Name=""Exist"" />
      <Member Type=""Method"" Name=""get_Item"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""Item"" />
      <Member Type=""Method"" Name=""PassAway"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
    <Type Name=""ITI.Genealogy.Person"">
      <Member Type=""Property"" Name=""BirthDate"" />
      <Member Type=""Property"" Name=""DeathDate"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Property"" Name=""Father"" />
      <Member Type=""Property"" Name=""FirstName"" />
      <Member Type=""Method"" Name=""get_BirthDate"" />
      <Member Type=""Method"" Name=""get_DeathDate"" />
      <Member Type=""Method"" Name=""get_Father"" />
      <Member Type=""Method"" Name=""get_FirstName"" />
      <Member Type=""Method"" Name=""get_IsDead"" />
      <Member Type=""Method"" Name=""get_IsFemale"" />
      <Member Type=""Method"" Name=""get_LastName"" />
      <Member Type=""Method"" Name=""get_Mother"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""IsDead"" />
      <Member Type=""Property"" Name=""IsFemale"" />
      <Member Type=""Property"" Name=""LastName"" />
      <Member Type=""Property"" Name=""Mother"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
  </Types>
</Assembly>
" );
            var current = GetPublicAPI( typeof( FamilyTree ).Assembly );
            if( !XElement.DeepEquals( model, current ) )
            {
                string m = model.ToString( SaveOptions.DisableFormatting );
                string c = current.ToString( SaveOptions.DisableFormatting );
                Assert.That( c, Is.EqualTo( m ) );
            }
        }

        XElement GetPublicAPI( Assembly a )
        {
            return new XElement( "Assembly",
                                  new XAttribute( "Name", a.GetName().Name ),
                                  new XElement( "Types",
                                                AllNestedTypes( a.GetExportedTypes() )
                                                 .OrderBy( t => t.FullName )
                                                 .Select( t => new XElement( "Type",
                                                                                new XAttribute( "Name", t.FullName ),
                                                                                t.GetMembers()
                                                                                 .OrderBy( m => m.Name )
                                                                                 .Select( m => new XElement( "Member",
                                                                                                              new XAttribute( "Type", m.MemberType ),
                                                                                                              new XAttribute( "Name", m.Name ) ) ) ) ) ) );
        }

        IEnumerable<Type> AllNestedTypes( IEnumerable<Type> types )
        {
            foreach( Type t in types )
            {
                yield return t;
                foreach( Type nestedType in AllNestedTypes( t.GetNestedTypes() ) )
                {
                    yield return nestedType;
                }
            }
        }
    }
}
