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
            string path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
            {
                for (int i = 0; i < 100; i++) writer.WriteLine(i);
            }

            using (FileStream stream = File.OpenRead(path))
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

        [Test]
        public void read_and_write_with_BinaryReader_and_BinaryWriter()
        {
            string path = Path.GetTempFileName();
            using (FileStream stream = File.OpenWrite(path))
            using (BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode))
            {
                for (int i = 0; i < 100; i++) writer.Write(i);
            }

            using(FileStream stream = File.OpenRead(path))
            using(BinaryReader reader = new BinaryReader(stream, Encoding.Unicode))
            {
                for(int i = 0; i < 100; i++)
                {
                    int n = reader.ReadInt32();
                    Assert.That(n, Is.EqualTo(i));
                }
            }
        }
    }
}