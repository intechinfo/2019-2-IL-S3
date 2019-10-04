using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NUnit.Framework;

namespace ITI.PrimarySchool.Tests
{
    [TestFixture]
    public class PublicModelChecker
    {
        [Test]
        [Explicit]
        public void write_current_public_API_to_console_with_double_quotes()
        {
            Console.WriteLine( GetPublicAPI( typeof( School ).Assembly ).ToString().Replace( "\"", "\"\"" ) );
        }

        [Test]
        public void public_API_is_not_modified()
        {
            var model = XElement.Parse( @"<Assembly Name=""ITI.PrimarySchool"">
  <Types>
    <Type Name=""ITI.PrimarySchool.Classroom"">
      <Member Type=""Method"" Name=""AddPupil"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Method"" Name=""FindPupil"" />
      <Member Type=""Method"" Name=""get_Name"" />
      <Member Type=""Method"" Name=""get_School"" />
      <Member Type=""Method"" Name=""get_Teacher"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""Name"" />
      <Member Type=""Property"" Name=""School"" />
      <Member Type=""Method"" Name=""set_Name"" />
      <Member Type=""Property"" Name=""Teacher"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
    <Type Name=""ITI.PrimarySchool.Pupil"">
      <Member Type=""Property"" Name=""Classroom"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Property"" Name=""FirstName"" />
      <Member Type=""Method"" Name=""get_Classroom"" />
      <Member Type=""Method"" Name=""get_FirstName"" />
      <Member Type=""Method"" Name=""get_LastName"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""LastName"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
    <Type Name=""ITI.PrimarySchool.School"">
      <Member Type=""Constructor"" Name="".ctor"" />
      <Member Type=""Method"" Name=""AddClassRoom"" />
      <Member Type=""Method"" Name=""AddTeacher"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Method"" Name=""FindClassRoom"" />
      <Member Type=""Method"" Name=""FindTeacher"" />
      <Member Type=""Method"" Name=""get_Name"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""Name"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
    <Type Name=""ITI.PrimarySchool.Teacher"">
      <Member Type=""Property"" Name=""Assignment"" />
      <Member Type=""Method"" Name=""AssignTo"" />
      <Member Type=""Method"" Name=""Equals"" />
      <Member Type=""Method"" Name=""get_Assignment"" />
      <Member Type=""Method"" Name=""get_Name"" />
      <Member Type=""Method"" Name=""get_School"" />
      <Member Type=""Method"" Name=""GetHashCode"" />
      <Member Type=""Method"" Name=""GetType"" />
      <Member Type=""Property"" Name=""Name"" />
      <Member Type=""Property"" Name=""School"" />
      <Member Type=""Method"" Name=""ToString"" />
    </Type>
  </Types>
</Assembly>
" );
            var current = GetPublicAPI( typeof( School ).Assembly );
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
