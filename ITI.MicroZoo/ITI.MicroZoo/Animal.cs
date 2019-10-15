using System;

namespace ITI.MicroZoo
{
    public abstract class Animal
    {
        Zoo _context;
        string _name;
        Vector _position;
        double _energy;
        int _age;
        double _direction;

        protected Animal(Zoo context, string name)
        {
            _context = context;
            _name = name;
            _position = context.GetRandomPosition();
            _direction = context.GetNextRandomDouble(0, 2 * Math.PI);
            _energy = context.GetNextRandomDouble(0.2, 1.0);
        }

        internal abstract void Update();

        public virtual void Kill()
        {
            if (!IsAlive) throw new InvalidOperationException("This animal is already dead.");

            _context.OnKill(this);
            _context = null;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _context.OnRename(this, value);
                _name = value;
            }
        }

        public bool IsAlive
        {
            get { return _context != null; }
        }

        public Zoo Zoo
        {
            get { return _context; }
            protected set { _context = value; }
        }

        public double X
        {
            get { return _position.X; }
        }

        public double Y
        {
            get { return _position.Y; }
        }

        public Vector Position
        {
            get { return _position; }
            protected set { _position = value; }
        }

        public double Energy
        {
            get { return _energy; }
            protected set { _energy = value; }
        }
    }
}
