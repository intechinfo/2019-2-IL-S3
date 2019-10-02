using NUnit.Framework;

namespace ITI.MicroZoo.Tests
{
    [TestFixture]
    public class ZooTests
    {
        [Test]
        public void create_and_find_cats()
        {
            Zoo sut = new Zoo();
            Cat cat1 = sut.CreateCat("Cat-1");
            Cat cat2 = sut.CreateCat("Cat-2");

            Cat c1 = sut.FindCat("Cat-1");
            Cat c2 = sut.FindCat("Cat-2");

            Assert.That(c1.Name, Is.EqualTo("Cat-1"));
            Assert.That(c1, Is.SameAs(cat1));

            Assert.That(c2.Name, Is.EqualTo("Cat-2"));
            Assert.That(c2, Is.SameAs(cat2));
        }

        [Test]
        public void create_and_find_birds()
        {
            Zoo sut = new Zoo();
            Bird bird1 = sut.CreateBird("Bird-1");
            Bird bird2 = sut.CreateBird("Bird-2");

            Bird b1 = sut.FindBird("Bird-1");
            Bird b2 = sut.FindBird("Bird-2");

            Assert.That(b1.Name, Is.EqualTo("Bird-1"));
            Assert.That(b1, Is.SameAs(bird1));

            Assert.That(b2.Name, Is.EqualTo("Bird-2"));
            Assert.That(b2, Is.SameAs(bird2));
        }
    }
}
