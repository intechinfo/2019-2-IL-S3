using System;
using System.Collections.Generic;

namespace ITI.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Animal> _animals;
        readonly Random _random;
        readonly ZooOptions _options;
        readonly IMailService _mailService;
        readonly List<Animal> _deadAnimals;
        bool _isUpdating;

        public Zoo()
        {
            _animals = new Dictionary<string, Animal>();
            _random = new Random();
            _options = new ZooOptions();
            _mailService = new FileSystemMailService();
            _deadAnimals = new List<Animal>();
        }

        internal IMailService MailService
        {
            get { return _mailService; }
        }

        public Bird CreateBird(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_animals.ContainsKey(name)) throw new ArgumentException("A bird with this name already exists.", nameof(name));

            Bird bird = new Bird(this, name);
            _animals.Add(name, bird);
            return bird;
        }

        public Cat CreateCat(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_animals.ContainsKey(name)) throw new ArgumentException("A cat with this name already exists.", nameof(name));

            Cat cat = new Cat(this, name);
            _animals.Add(name, cat);
            return cat;
        }

        public Bird FindBird(string name)
        {
            _animals.TryGetValue(name, out Animal animal);
            Bird bird = animal as Bird;
            return bird;
        }

        public Cat FindCat(string name)
        {
            _animals.TryGetValue(name, out Animal animal);
            Cat cat = animal as Cat;
            return cat;
        }

        public void Update()
        {
            _isUpdating = true;
            _deadAnimals.Clear();
            foreach (Animal animal in _animals.Values) animal.Update();
            foreach (Animal animal in _deadAnimals) _animals.Remove(animal.Name);
            _isUpdating = false;
        }

        internal void OnRename(Animal animal, string newName)
        {
            if (_animals.ContainsKey(newName)) throw new ArgumentException("An animal with this name already exists.", nameof(newName));

            _animals.Remove(animal.Name);
            _animals.Add(newName, animal);
        }

        internal void OnKill(Animal animal)
        {
            if (_isUpdating) _deadAnimals.Add(animal);
            else _animals.Remove(animal.Name);
        }

        internal Vector GetRandomPosition()
        {
            return new Vector(GetNextRandomDouble(-1.0, 1.0), GetNextRandomDouble(-1.0, 1.0));
        }

        internal double GetNextRandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }

        internal List<Bird> Birds
        {
            get
            {

                List<Bird> birds = new List<Bird>();
                foreach (Animal animal in _animals.Values)
                {
                    Bird bird = animal as Bird;
                    if (bird != null) birds.Add(bird);
                }

                return birds;
            }
        }

        internal ZooOptions Options
        {
            get { return _options; }
        }
    }
}
