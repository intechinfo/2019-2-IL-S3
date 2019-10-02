namespace ITI.MicroZoo
{
    public class Cat
    {
        Zoo _context;
        string _name;
        double _x;
        double _y;
        double _energy;
        int _age;

        internal Cat(Zoo context, string name)
        {
            _context = context;
            _name = name;
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
    }
}
