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

        public ushort GetCurrentVolume()
        {
            return _currentVolume;
        }

        public ushort GetMaxCapacity()
        {
            return _maxCapacity;
        }
    }
}
