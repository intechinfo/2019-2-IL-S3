namespace ITI.MicroZoo
{
    public class Cat
    {
        readonly string _name;
        double _x;
        double _y;
        double _energy;
        int _age;

        internal Cat(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            set { throw new System.NotImplementedException(); }
        }
    }
}
