using System.IO;
using System.Text;
using NUnit.Framework;

namespace ITI.PrimarySchool.Model.Tests
{
    [TestFixture]
    public class SchoolTests
    {
        [Test]
        public void write_and_read_school()
        {
            School sut = new School("in'tech");
            Classroom c = sut.FindOrCreate("classroom-1");
            c.MaxStudentCount = 10;
            c = sut.FindOrCreate("classroom-2");
            c.MaxStudentCount = 20;
            c = sut.FindOrCreate("classroom-3");
            c.MaxStudentCount = 30;

            string path = Path.GetTempFileName();
            System.Console.WriteLine(path);
            using (FileStream stream = File.OpenWrite(path))
            using(BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode))
            {
                sut.Save(writer);
            }

            using(FileStream stream = File.OpenRead(path))
            using(BinaryReader reader = new BinaryReader(stream, Encoding.Unicode))
            {
                School school = new School(reader);

                Assert.That(school.Name, Is.EqualTo(sut.Name));
                Assert.That(school, Is.Not.SameAs(sut));

                Classroom c1 = school.FindOrCreate("classroom-1");
                Assert.That(c1.School, Is.SameAs(school));
                Assert.That(c1.Name, Is.EqualTo("classroom-1"));
                Assert.That(c1.MaxStudentCount, Is.EqualTo(10));

                Classroom c2 = school.FindOrCreate("classroom-2");
                Assert.That(c2.School, Is.SameAs(school));
                Assert.That(c2.Name, Is.EqualTo("classroom-2"));
                Assert.That(c2.MaxStudentCount, Is.EqualTo(20));

                Classroom c3 = school.FindOrCreate("classroom-3");
                Assert.That(c3.School, Is.SameAs(school));
                Assert.That(c3.Name, Is.EqualTo("classroom-3"));
                Assert.That(c3.MaxStudentCount, Is.EqualTo(30));
            }
        }
    }
}
