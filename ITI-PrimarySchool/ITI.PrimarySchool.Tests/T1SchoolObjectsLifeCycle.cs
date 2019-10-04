using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.PrimarySchool.Tests
{
    [TestFixture]
    public class T1SchoolObjectsLifeCycle
    {
        [Test]
        public void t1_creating_named_schools()
        {
            Assert.Throws<ArgumentException>( () => new School( null ) );
            Assert.Throws<ArgumentException>( () => new School( String.Empty ) );
            
            {
                School s = new School( "Evariste Galois" );
                Assert.That( s.Name, Is.EqualTo( "Evariste Galois" ) );
            }
            {
                var randomName = Guid.NewGuid().ToString();
                School s = new School( randomName );
                Assert.That( s.Name, Is.EqualTo( randomName ) );
            }
            Assert.That( typeof( School ).GetProperty( "Name" ).GetSetMethod(), Is.Null, "School.Name must NOT be writeable." );
        }

        [Test]
        public void t2_classrooms_are_created_by_school_and_have_a_unique_name()
        {
            School s = new School( "Evariste Galois" );

            Assert.Throws<ArgumentException>( () => s.AddClassRoom( null ) );
            Assert.Throws<ArgumentException>( () => s.AddClassRoom( String.Empty ) );

            Classroom c1 = s.AddClassRoom( "CE1" );
            Assert.That( c1.School, Is.SameAs( s ) );
            Assert.That( c1.Name, Is.EqualTo( "CE1" ) );
            Assert.Throws<ArgumentException>( () => s.AddClassRoom( "CE1" ) );

            Classroom c2 = s.AddClassRoom( "CE2" );
            Assert.That( c2.School, Is.SameAs( s ) );
            Assert.That( c2.Name, Is.EqualTo( "CE2" ) );
            Assert.Throws<ArgumentException>( () => s.AddClassRoom( "CE1" ) );

            Assert.That( typeof( Classroom ).GetConstructors( BindingFlags.Instance | BindingFlags.Public ), Is.Empty, "Classroom must not expose any public constructors." );
        }

        [Test]
        public void t3_teachers_are_created_by_school_and_have_a_unique_name()
        {
            School s = new School( "Evariste Galois" );

            Assert.Throws<ArgumentException>( () => s.AddTeacher( null ) );
            Assert.Throws<ArgumentException>( () => s.AddTeacher( String.Empty ) );

            Teacher c1 = s.AddTeacher( "Jean-Paul" );
            Assert.That( c1.School, Is.SameAs( s ) );
            Assert.That( c1.Name, Is.EqualTo( "Jean-Paul" ) );
            Assert.Throws<ArgumentException>( () => s.AddTeacher( "Jean-Paul" ) );

            Teacher c2 = s.AddTeacher( "Albert" );
            Assert.That( c2.School, Is.SameAs( s ) );
            Assert.That( c2.Name, Is.EqualTo( "Albert" ) );
            Assert.Throws<ArgumentException>( () => s.AddTeacher( "Albert" ) );

            Assert.That( typeof( Teacher ).GetProperty( "Name" ).GetSetMethod(), Is.Null, "Teacher.Name must NOT be writeable." );
            Assert.That( typeof( Teacher ).GetConstructors( BindingFlags.Instance | BindingFlags.Public ), Is.Empty, "Teacher must not expose any public constructors." );
        }

        [Test]
        public void t4_pupils_are_created_by_classrooms_and_have_a_unique_firstname_and_lastname()
        {
            School s = new School( "Evariste Galois" );
            Classroom c = s.AddClassRoom( "C" );

            Pupil p1 = c.AddPupil( "Jean-Paul", "Sartre" );
            Assert.That( p1.Classroom, Is.SameAs( c ) );
            Assert.That( p1.FirstName, Is.EqualTo( "Jean-Paul" ) );
            Assert.That( p1.LastName, Is.EqualTo( "Sartre" ) );
            Assert.Throws<ArgumentException>( () => c.AddPupil( "Jean-Paul", "Sartre" ) );

            Pupil p2 = c.AddPupil( "Jean-Paul", "Deux" );
            Assert.That( p2.Classroom, Is.SameAs( c ) );
            Assert.That( p2.FirstName, Is.EqualTo( "Jean-Paul" ) );
            Assert.That( p2.LastName, Is.EqualTo( "Deux" ) );
            Assert.Throws<ArgumentException>( () => c.AddPupil( "Jean-Paul", "Deux" ) );

            Assert.That( typeof( Pupil ).GetProperty( "FirstName" ).GetSetMethod(), Is.Null, "Pupil.FirstName must NOT be writeable." );
            Assert.That( typeof( Pupil ).GetProperty( "LastName" ).GetSetMethod(), Is.Null, "Pupil.FirstName must NOT be writeable." );
            Assert.That( typeof( Pupil ).GetConstructors( BindingFlags.Instance | BindingFlags.Public ), Is.Empty, "Pupil must not expose any public constructors." );
        }

        [TestCase( null, null )]
        [TestCase( "", "Valid" )]
        [TestCase( "Y", "Valid" )]
        [TestCase( "Valid", null )]
        [TestCase( "Valid", "" )]
        [TestCase( "Valid", "A" )]
        [TestCase( null, "Valid" )]
        [TestCase( "B", "Valid" )]
        public void t5_pupils_firstname_and_lastname_must_be_not_null_and_longer_than_2_characters( string firstName, string lastName )
        {
            School s = new School( "Evariste Galois" );
            Classroom c = s.AddClassRoom( "C" );
            Assert.Throws<ArgumentException>( () => c.AddPupil( firstName, lastName ) );
        }
    }
}
