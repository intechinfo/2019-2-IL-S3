namespace ITI.SFMLExample.Model
{
    public class Player
    {
        readonly GameContext _ctx;
        double _energy;
        double _x;
        double _y;

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

        public double X
        {
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public void Move(double deltaX, double deltaY)
        {
            _x += deltaX;
            _y += deltaY;
        }
    }
}
