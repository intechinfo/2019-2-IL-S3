using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace ITI.MicroZoo.Tests
{
    [TestFixture]
    public class BirdTests
    {
        [Test]
        public void rename_bird()
        {
            Zoo zoo = new Zoo();
            Bird sut = zoo.CreateBird("name");

            sut.Name = "new-name";

            Bird b1 = zoo.FindBird("new-name");
            Bird b2 = zoo.FindBird("name");
            Assert.That(b1, Is.SameAs(sut));
            Assert.That(b2, Is.Null);
            Assert.That(sut.Name, Is.EqualTo("new-name"));
        }
    }
}
