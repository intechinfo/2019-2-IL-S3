using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ITI.PrimarySchool.Tests
{
    [TestFixture]
    public class T3TeacherClassroomAssignation
    {
        [Test]
        public void t1_teachers_can_be_assigned_to_a_classroom()
        {
            School s = new School( "Evariste Galois" );
            Classroom c1 = s.AddClassRoom( "CE1" );
            Classroom c2 = s.AddClassRoom( "CE2" );
            Assert.That( c1.Teacher, Is.Null, "No teacher assigned yet to CE1." );
            Assert.That( c2.Teacher, Is.Null, "No teacher assigned yet to CE2." );

            Teacher t = s.AddTeacher( "Albert" );
            t.AssignTo( c1 );
            Assert.That( t.Assignment, Is.SameAs( c1 ), "Albert is now teaching to CE1." );
            Assert.That( c1.Teacher, Is.SameAs( t ), "CE1 is now teached by Albert." );
            Assert.That( c2.Teacher, Is.Null, "CE2 still has no teacher." );

        }

        [Test]
        public void t2_when_a_teacher_is_assigned_to_a_classroom_he_losts_its_previous_classroom()
        {
            School s = new School( "Evariste Galois" );
            Classroom c1 = s.AddClassRoom( "CE1" );
            Classroom c2 = s.AddClassRoom( "CE2" );
            Teacher t = s.AddTeacher( "Albert" );
            
            t.AssignTo( c1 );
            Assert.That( t.Assignment, Is.SameAs( c1 ), "Albert is now teaching to CE1." );
            Assert.That( c1.Teacher, Is.SameAs( t ), "CE1 is now teached by Albert." );
            Assert.That( c2.Teacher, Is.Null, "CE2 still has no teacher." );

            t.AssignTo( c2 );
            Assert.That( t.Assignment, Is.SameAs( c2 ), "Albert is now teaching to CE2." );
            Assert.That( c2.Teacher, Is.SameAs( t ), "CE2 is now teached by Albert." );
            Assert.That( c1.Teacher, Is.Null, "CE1 has no teacher anymore." );
        }

        [Test]
        public void t3_teachers_and_classrooms_must_belong_to_the_same_school()
        {
            School s1 = new School( "Evariste Galois" );
            Classroom c1S1 = s1.AddClassRoom( "CE1 (Evariste Galois)" );
            Teacher tS1 = s1.AddTeacher( "Evariste" );

            School s2 = new School( "Jules Vallès" );
            Classroom c1S2 = s2.AddClassRoom( "CE1 (Jules Vallès)" );

            Assert.DoesNotThrow( () => tS1.AssignTo( c1S1 ) );
            Assert.Throws<ArgumentException>( () => tS1.AssignTo( c1S2 ) );

            School s3 = new School( "Evariste Galois" );
            Classroom c1S3 = s3.AddClassRoom( "CE1 (Evariste Galois n°2)" );
            Assert.Throws<ArgumentException>( () => tS1.AssignTo( c1S3 ) );
        }

        [Test]
        public void t4_assigning_a_teacher_to_a_null_classroom_removes_its_assignment()
        {
            School s = new School( "Evariste Galois" );
            Classroom c = s.AddClassRoom( "CE1" );
            Teacher t = s.AddTeacher( "Evariste" );

            Assert.DoesNotThrow( () => t.AssignTo( null ) );

            t.AssignTo( c );
            Assert.That( t.Assignment, Is.SameAs( c ), "Evariste now teachs to CE1." );
            Assert.That( c.Teacher, Is.SameAs( t ), "CE1 has teacher Evariste." );
            
            t.AssignTo( null );
            Assert.That( t.Assignment, Is.Null, "Evariste does not teach anymore." );
            Assert.That( c.Teacher, Is.Null, "CE1 has no teacher anymore." );
        }

    }
}
