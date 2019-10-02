namespace ITI.MicroZoo
{
    public class Bird
    {
        readonly string _name;
        double _x;
        double _y;
        double _energy;
        int _age;
        bool _isFlying;

        internal Bird(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
