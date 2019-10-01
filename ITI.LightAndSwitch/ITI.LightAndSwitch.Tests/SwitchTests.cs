using NUnit.Framework;

namespace ITI.LightAndSwitch.Tests
{
    [TestFixture]
    public class SwitchTests
    {
        [Test]
        public void toggle_switch()
        {
            Switch sut = new Switch(4);
            Light light = new Light();
            bool attached = sut.Attach(light);

            sut.Toggle();

            Assert.That(attached, Is.True);
            Assert.That(light.IsOn, Is.True);
        }

        [Test]
        public void attach_light_with_switch_already_on()
        {
            Switch sut = new Switch(4);
            sut.Attach(new Light());
            sut.Toggle();
            Light light = new Light();

            sut.Attach(light);

            Assert.That(light.IsOn, Is.True);
        }
    }
}
