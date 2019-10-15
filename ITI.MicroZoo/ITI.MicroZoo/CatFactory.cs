namespace ITI.MicroZoo
{
    public class CatFactory : IAnimalFactory<Cat>
    {
        public Cat Create(Zoo context, string name)
        {
            return new Cat(context, name);
        }
    }
}
