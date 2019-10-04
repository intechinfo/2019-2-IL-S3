using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.PrimarySchool.Tests
{
    [TestFixture]
    class T2SchoolObjectsNaming
    {
        [Test]
        public void t1_teachers_can_be_found_by_name()
        {
            School s = new School( "Evariste Galois" );
            Teacher c1 = s.AddTeacher( "CE1-1" );
            Assert.That( s.FindTeacher( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindTeacher( "CE1-2" ), Is.Null );

            Teacher c2 = s.AddTeacher( "CE1-2" );
            Assert.That( s.FindTeacher( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindTeacher( "CE1-2" ), Is.SameAs( c2 ) );
            Assert.That( s.FindTeacher( "CE1-3" ), Is.Null );

            Teacher c3 = s.AddTeacher( "CE1-3" );
            Teacher c4 = s.AddTeacher( "CE2-1" );
            Teacher c5 = s.AddTeacher( "CE2-2" );

            Assert.That( s.FindTeacher( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindTeacher( "CE1-2" ), Is.SameAs( c2 ) );
            Assert.That( s.FindTeacher( "CE1-3" ), Is.SameAs( c3 ) );
            Assert.That( s.FindTeacher( "CE2-1" ), Is.SameAs( c4 ) );
            Assert.That( s.FindTeacher( "CE2-2" ), Is.SameAs( c5 ) );

            var randomNames = Enumerable.Range( 0, 20 ).Select( i => String.Format( "n°{0} - {1}", i, Guid.NewGuid().ToString() ) ).ToArray();
            var teachers = randomNames.Select( n => s.AddTeacher( n ) ).ToArray();
            CollectionAssert.AreEqual( teachers, randomNames.Select( n => s.FindTeacher( n ) ) );
        }

        [Test]
        public void t2_pupils_can_be_found_by_name()
        {
            School s = new School( "Evariste Galois" );
            Classroom c = s.AddClassRoom( "CE1" );

            Pupil albert = c.AddPupil( "Albert", "Einstein" );
            Assert.That( c.FindPupil( "Albert", "Einstein" ), Is.SameAs( albert ) );
            Assert.That( c.FindPupil( "Max", "Planck" ), Is.Null );

            Pupil max = c.AddPupil( "Max", "Planck" );
            Assert.That( c.FindPupil( "Albert", "Einstein" ), Is.SameAs( albert ) );
            Assert.That( c.FindPupil( "Max", "Planck" ), Is.SameAs( max ) );
            Assert.That( c.FindPupil( "Enrico", "Fermi" ), Is.Null );

            Pupil enrico = c.AddPupil( "Enrico", "Fermi" );
            Pupil paul = c.AddPupil( "Paul", "Langevin" );
            Pupil nikola = c.AddPupil( "Nikola", "Tesla" );

            Assert.That( c.FindPupil( "Albert", "Einstein" ), Is.SameAs( albert ) );
            Assert.That( c.FindPupil( "Max", "Planck" ), Is.SameAs( max ) );
            Assert.That( c.FindPupil( "Enrico", "Fermi" ), Is.SameAs( enrico ) );
            Assert.That( c.FindPupil( "Paul", "Langevin" ), Is.SameAs( paul ) );
            Assert.That( c.FindPupil( "Nikola", "Tesla" ), Is.SameAs( nikola ) );

            var randomNames = Enumerable.Range( 0, 20 )
                                            .Select( i => new  { 
                                                    LastName = String.Format( "n°{0} - {1}", i, Guid.NewGuid().ToString() ), 
                                                    FirstName = Guid.NewGuid().ToString() } )
                                            .ToArray();
            var pupils = randomNames.Select( n => c.AddPupil( n.FirstName, n.LastName ) ).ToArray();
            CollectionAssert.AreEqual( pupils, randomNames.Select( n => c.FindPupil( n.FirstName, n.LastName ) ) );
        }

        [Test]
        public void t3_classrooms_can_be_found_by_name()
        {
            School s = new School( "Evariste Galois" );
            Classroom c1 = s.AddClassRoom( "CE1-1" );
            Assert.That( s.FindClassRoom( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindClassRoom( "CE1-2" ), Is.Null );

            Classroom c2 = s.AddClassRoom( "CE1-2" );
            Assert.That( s.FindClassRoom( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindClassRoom( "CE1-2" ), Is.SameAs( c2 ) );
            Assert.That( s.FindClassRoom( "CE1-3" ), Is.Null );

            Classroom c3 = s.AddClassRoom( "CE1-3" );
            Classroom c4 = s.AddClassRoom( "CE2-1" );
            Classroom c5 = s.AddClassRoom( "CE2-2" );

            Assert.That( s.FindClassRoom( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindClassRoom( "CE1-2" ), Is.SameAs( c2 ) );
            Assert.That( s.FindClassRoom( "CE1-3" ), Is.SameAs( c3 ) );
            Assert.That( s.FindClassRoom( "CE2-1" ), Is.SameAs( c4 ) );
            Assert.That( s.FindClassRoom( "CE2-2" ), Is.SameAs( c5 ) );

            var randomNames = Enumerable.Range( 0, 20 ).Select( i => String.Format( "n°{0} - {1}", i, Guid.NewGuid().ToString() ) ).ToArray();
            var classRooms = randomNames.Select( n => s.AddClassRoom( n ) ).ToArray();
            CollectionAssert.AreEqual( classRooms, randomNames.Select( n => s.FindClassRoom( n ) ) );
        }

        [Test]
        public void t4_classrooms_can_be_renamed()
        {
            School s = new School( "Evariste Galois" );
            Classroom c1 = s.AddClassRoom( "CE1-1" );
            Classroom c2 = s.AddClassRoom( "CE1-2" );

            Assert.That( s.FindClassRoom( "CE1-1" ), Is.SameAs( c1 ) );
            Assert.That( s.FindClassRoom( "CE1-2" ), Is.SameAs( c2 ) );

            c1.Name = "XRQ-3712";
            Assert.That( s.FindClassRoom( "CE1-1" ), Is.Null );
            Assert.That( c1.Name, Is.EqualTo( "XRQ-3712" ) );
            Assert.That( s.FindClassRoom( "XRQ-3712" ), Is.SameAs( c1 ) );
            
            Assert.Throws<ArgumentException>( () => c1.Name = "CE1-2" );

            Assert.DoesNotThrow( () => c2.Name = "CE1-2" );
            Assert.DoesNotThrow( () => c1.Name = "XRQ-3712" );
        }
    }
}
