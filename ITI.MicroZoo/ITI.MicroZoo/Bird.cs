using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace ITI.MicroZoo
{
    public class Bird
    {
        Zoo _context;
        string _name;
        Vector _position;
        double _energy;
        int _age;
        bool _isFlying;
        double _direction;

        internal Bird(Zoo context, string name)
        {
            _context = context;
            _name = name;
            _position = context.GetRandomPosition();
            _direction = context.GetNextRandomDouble(0, 2 * Math.PI);
            _energy = context.GetNextRandomDouble(0.2, 1.0);
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

        public bool IsAlive
        {
            get { return _context != null; }
        }

        public void Kill()
        {
            if (!IsAlive) throw new InvalidOperationException("This bird is already dead.");

            MailService mailService = new MailService();
            mailService.SendMail(
                "antoine.raquillet@esiea.fr",
                "A bird is dying.",
                string.Format("{0} is dying.", _name));

            _context.OnKill(this);
            _context = null;
        }

        public Zoo Zoo
        {
            get { return _context; }
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
            if (_isFlying)
            {
                _position = _context.GetRandomPosition();
                _energy = Math.Max(0.0, _energy - _context.Options.EnergyDecreaseDelta);
                if (_energy <= _context.Options.LandingLimit) _isFlying = false;
            }
            else
            {
                _energy = Math.Min(1.0, _energy + _context.Options.EnergyIncreaseDelta);
                if (_energy >= _context.Options.FlyingLimit) _isFlying = true;
            }
        }

        internal Vector Position
        {
            get { return _position; }
        }
    }
}
