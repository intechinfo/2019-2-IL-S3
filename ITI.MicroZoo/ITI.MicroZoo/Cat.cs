using System;
using System.Collections.Generic;

namespace ITI.MicroZoo
{
    public class Cat
    {
        Zoo _context;
        string _name;
        Position _position;
        double _energy;
        int _age;

        internal Cat(Zoo context, string name)
        {
            _context = context;
            _name = name;
            _position = context.GetRandomPosition();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(value));

                _context.OnRename(this, value);
                _name = value;
            }
        }

        public void Kill()
        {
            if (!IsAlive) throw new InvalidOperationException("This cat is already dead.");

            _context.OnKill(this);
            _context = null;
        }

        public Zoo Zoo
        {
            get { return _context; }
        }

        public bool IsAlive
        {
            get { return _context != null; }
        }

        public double X
        {
            get { return _position.X; }
        }

        public double Y
        {
            get { return _position.Y; }
        }

        internal void Update()
        {
            //Bird[] birds = _context.Birds;
            //double minDistance = double.MaxValue;
            //foreach (Bird bird in birds)
            //{
            //    double distance = _position ?? bird.Position;
            //    if (distance < minDistance) minDistance = distance;
            //}

            throw new NotImplementedException();
        }
    }
}
