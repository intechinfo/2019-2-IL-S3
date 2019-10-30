using System;

namespace ITI.SFMLExample.Model
{
    public class Player
    {
        readonly GameContext _ctx;
        double _energy;
        float _x;
        float _y;
        bool _hasMoved;

        internal Player(GameContext ctx)
        {
            _ctx = ctx;
            _x = 0;
            _y = 0;
            _energy = 1;
        }

        public double Energy
        {
            get { return _energy; }
        }

        public float X
        {
            get { return _x; }
        }

        public float Y
        {
            get { return _y; }
        }

        public void Move(float deltaX, float deltaY)
        {
            if (_energy > 0.1)
            {
                _x += deltaX;
                _y += deltaY;
                _energy -= 0.2;
                _hasMoved = true;
            }
        }

        public void Update()
        {
            if(!_hasMoved) _energy = Math.Min(1.0, _energy + 0.05);
            _hasMoved = false;
        }
    }
}
