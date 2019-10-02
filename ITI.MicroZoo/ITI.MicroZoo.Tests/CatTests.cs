using System;
using NUnit.Framework;

namespace ITI.MicroZoo.Tests
{
    [TestFixture]
    public class CatTests
    {
        [Test]
        public void rename_cat()
        {
            Zoo zoo = new Zoo();
            Cat sut = zoo.CreateCat("name");

            sut.Name = "new-name";

            Cat c1 = zoo.FindCat("new-name");
            Cat c2 = zoo.FindCat("name");
            Assert.That(c1, Is.SameAs(sut));
            Assert.That(c2, Is.Null);
            Assert.That(sut.Name, Is.EqualTo("new-name"));
        }

        [Test]
        public void kill_cat()
        {
            Zoo zoo = new Zoo();
            Cat sut = zoo.CreateCat("name");

            sut.Kill();

            Assert.That(sut.IsAlive, Is.False);
            Assert.That(zoo.FindCat("name"), Is.Null);
            Cat c = zoo.CreateCat("name");
            Assert.That(c, Is.Not.SameAs(sut));
            Assert.That(sut.Zoo, Is.Null);
            Assert.Throws<InvalidOperationException>(() => sut.Kill());
        }
    }
}
