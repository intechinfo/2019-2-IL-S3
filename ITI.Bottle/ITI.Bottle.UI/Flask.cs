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

        public void Fulfill()
        {
            _currentVolume = _maxCapacity;
        }

        public void Empty(ushort volumeToRemove)
        {
            if (volumeToRemove > _currentVolume) _currentVolume = 0;
            else _currentVolume -= volumeToRemove;
        }

        public void Empty()
        {
            _currentVolume = 0;
        }

        public ushort Volume
        {
            get { return _currentVolume; }
            private set { _currentVolume = Math.Min(_maxCapacity, value); }
        }

        public ushort MaxCapacity
        {
            get { return _maxCapacity; }
        }

        public bool IsEmpty
        {
            get { return _currentVolume == 0; }
        }

        // public bool IsEmpty => _currentVolume == 0;

        public bool IsFull
        {
            get { return _maxCapacity == _currentVolume; }
        }
    }
}
