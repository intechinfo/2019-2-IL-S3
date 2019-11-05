using System.IO;
using System.Text;
using NUnit.Framework;

namespace ITI.PrimarySchool.Model.Tests
{
    [TestFixture]
    public class FileSystemApiTests
    {
        [Test]
        public void write_and_read_from_file()
        {
            using (FileStream stream = File.OpenWrite("test.txt"))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
            {
                for (int i = 0; i < 100; i++) writer.WriteLine(i);
            }

            using (FileStream stream = File.OpenRead("test.txt"))
            using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
            {
                for (int i = 0; i < 100; i++)
                {
                    string line = reader.ReadLine();
                    Assert.That(int.TryParse(line, out int n), Is.True);
                    Assert.That(n, Is.EqualTo(i));
                }
            }
        }
    }
}