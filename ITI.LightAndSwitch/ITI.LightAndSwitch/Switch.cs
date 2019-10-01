using System;

namespace ITI.LightAndSwitch
{
    public class Switch
    {
        Light[] _lights;
        bool _isOn;

        public Switch(int lightCount)
        {
            if (lightCount <= 0) throw new ArgumentException("The light count must be greater than 0.", nameof(lightCount));
            _lights = new Light[lightCount];
        }

        public bool Attach(Light light)
        {
            for(int i = 0; i < _lights.Length; i++)
            {
                if(_lights[i] == null)
                {
                    _lights[i] = light;
                    if (_isOn) light.Toggle();
                    return true;
                }
            }

            return false;
        }

        public bool Detach(Light light)
        {
            for(int i = 0; i < _lights.Length; i++)
            {
                if( _lights[i] == light)
                {
                    _lights[i] = null;
                    if (_isOn) light.Toggle();
                    return true;
                }
            }

            return false;
        }

        public void Toggle()
        {
            _isOn = !_isOn;
            for(int i = 0; i < _lights.Length; i++)
            {
                Light light = _lights[i];
                if(light != null)
                {
                    light.Toggle();
                }
            }
        }
    }
}
