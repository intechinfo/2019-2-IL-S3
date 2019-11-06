using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            sut.CreateStudent("firstName-1", "lastName-1");
            sut.CreateStudent("firstName-2", "lastName-2");
            sut.CreateStudent("firstName-3", "lastName-3");
            sut.CreateStudent("firstName-4", "lastName-4");

            string path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode))
            {
                sut.Save(writer);
            }

            using (FileStream stream = File.OpenRead(path))
            using (BinaryReader reader = new BinaryReader(stream, Encoding.Unicode))
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

                Student s1 = school.FindStudent("lastName-1");
                Assert.That(s1.School, Is.SameAs(school));
                Assert.That(s1.FirstName, Is.EqualTo("firstName-1"));
                Assert.That(s1.LastName, Is.EqualTo("lastName-1"));

                Student s2 = school.FindStudent("lastName-2");
                Assert.That(s2.School, Is.SameAs(school));
                Assert.That(s2.FirstName, Is.EqualTo("firstName-2"));
                Assert.That(s2.LastName, Is.EqualTo("lastName-2"));

                Student s3 = school.FindStudent("lastName-3");
                Assert.That(s3.School, Is.SameAs(school));
                Assert.That(s3.FirstName, Is.EqualTo("firstName-3"));
                Assert.That(s3.LastName, Is.EqualTo("lastName-3"));

                Student s4 = school.FindStudent("lastName-4");
                Assert.That(s4.School, Is.SameAs(school));
                Assert.That(s4.FirstName, Is.EqualTo("firstName-4"));
                Assert.That(s4.LastName, Is.EqualTo("lastName-4"));
            }
        }

        [Test]
        public void json_serialization()
        {
            School sut = new School("in'tech");
            Classroom c = sut.FindOrCreate("classroom-1");
            c.MaxStudentCount = 10;
            c = sut.FindOrCreate("classroom-2");
            c.MaxStudentCount = 20;
            c = sut.FindOrCreate("classroom-3");
            c.MaxStudentCount = 30;
            sut.CreateStudent("firstName-1", "lastName-1");
            sut.CreateStudent("firstName-2", "lastName-2");
            sut.CreateStudent("firstName-3", "lastName-3");
            sut.CreateStudent("firstName-4", "lastName-4");

            JToken json = sut.ToJson();
            string path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
            {
                json.WriteTo(jsonWriter);
            }

            using (FileStream stream = File.OpenRead(path))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (JsonTextReader jsonReader = new JsonTextReader(reader))
            {
                JToken jSchool = JToken.ReadFrom(jsonReader);
                School school = new School(jSchool);

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

                Student s1 = school.FindStudent("lastName-1");
                Assert.That(s1.School, Is.SameAs(school));
                Assert.That(s1.FirstName, Is.EqualTo("firstName-1"));
                Assert.That(s1.LastName, Is.EqualTo("lastName-1"));

                Student s2 = school.FindStudent("lastName-2");
                Assert.That(s2.School, Is.SameAs(school));
                Assert.That(s2.FirstName, Is.EqualTo("firstName-2"));
                Assert.That(s2.LastName, Is.EqualTo("lastName-2"));

                Student s3 = school.FindStudent("lastName-3");
                Assert.That(s3.School, Is.SameAs(school));
                Assert.That(s3.FirstName, Is.EqualTo("firstName-3"));
                Assert.That(s3.LastName, Is.EqualTo("lastName-3"));

                Student s4 = school.FindStudent("lastName-4");
                Assert.That(s4.School, Is.SameAs(school));
                Assert.That(s4.FirstName, Is.EqualTo("firstName-4"));
                Assert.That(s4.LastName, Is.EqualTo("lastName-4"));
            }
        }
    }
}
