using System;

namespace ITI.Bottle.UI
{
    class Flask
    {
        ushort _maxCapacity;
        ushort _currentVolume;

        public Flask()
            : this(1000)
        {
        }

        public Flask(ushort maxCapacity)
        {
            _maxCapacity = maxCapacity;
        }

        public void Fill(ushort volumeToAdd)
        {
            _currentVolume += volumeToAdd;
            if (_currentVolume > _maxCapacity) _currentVolume = _maxCapacity;
        }
    }
}
