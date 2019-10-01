namespace ITI.LightAndSwitch
{
    public class Light
    {
        bool _isOn;

        public Light()
        {
            _isOn = false;
        }

        internal void Toggle()
        {
            _isOn = !_isOn;
        }

        public bool IsOn
        {
            get { return _isOn; }
        }
    }
}
