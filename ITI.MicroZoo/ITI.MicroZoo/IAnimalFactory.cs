namespace ITI.MicroZoo
{
    public interface IAnimalFactory<T> where T : Animal
    {
        T Create(Zoo context, string name);
    }
}
