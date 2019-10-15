namespace ITI.MicroZoo
{
    public class BirdFactory : IAnimalFactory<Bird>
    {
        public Bird Create(Zoo context, string name)
        {
            return new Bird(context, name);
        }
    }
}
