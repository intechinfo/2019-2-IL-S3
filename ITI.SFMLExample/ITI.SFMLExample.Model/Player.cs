using System;

namespace ITI.SFMLExample.Model
{
    public class Player
    {
        readonly GameContext _ctx;
        double _energy;
        float _x;
        float _y;
        float _deltaX;
        float _deltaY;

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

        public void StartMove(float deltaX, float deltaY)
        {
            _deltaX = deltaX;
            _deltaY = deltaY;
        }

        public void StopMove()
        {
            _deltaX = 0.0f;
            _deltaY = 0.0f;
        }

        public void Update()
        {
            if(_energy > 0.2 && (_deltaX != 0.0f || _deltaY != 0.0f))
            {
                _x = Math.Max(Math.Min(_x + _deltaX, 1.0f), -1.0f);
                _y = Math.Max(Math.Min(_y + _deltaY, 1.0f), -1.0f);
                _energy -= 0.1;
            }
            else if(_energy <= 0.2 || (_deltaX == 0.0f && _deltaY == 0.0f))
            {
                _energy += 0.05f;
            }
        }
    }
}
