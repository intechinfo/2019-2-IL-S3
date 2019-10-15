namespace ITI.MicroZoo
{
    public class Dog : Animal
    {
        internal Dog(Zoo context, string name)
            : base(context, name)
        {
        }

        internal override void Update()
        {
            // update dog...
        }
    }
}
