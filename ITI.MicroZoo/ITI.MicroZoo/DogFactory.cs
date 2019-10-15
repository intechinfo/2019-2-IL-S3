namespace ITI.MicroZoo
{
    public class DogFactory : IAnimalFactory<Dog>
    {
        public Dog Create(Zoo context, string name)
        {
            return new Dog(context, name);
        }
    }
}
