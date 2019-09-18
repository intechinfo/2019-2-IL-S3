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
    }
}
