using NUnit.Framework;

namespace ITI.Bottle.Tests
{
    [TestFixture]
    public class FlaskTests
    {
        [Test]
        public void fulfill_a_flask()
        {
            // Arrange
            Flask flask = new Flask(2000);

            // Act
            flask.Fulfill();

            // Assert
            Assert.That(flask.Volume, Is.EqualTo(flask.MaxCapacity));
        }

        [TestCase(0u)]
        [TestCase(200u)]
        [TestCase(500u)]
        [TestCase(1000u)]
        public void fill_a_flask(uint expectedVolume)
        {
            Flask flask = new Flask(2000);
            flask.Fill((ushort)expectedVolume);
            Assert.That(flask.Volume, Is.EqualTo(expectedVolume));
        }

        [Test]
        public void fill_with_too_big_volume()
        {
            Flask flask = new Flask(2000);
            Assert.Throws<System.InvalidOperationException>(() => flask.Fill(3000));
        }
    }
}
