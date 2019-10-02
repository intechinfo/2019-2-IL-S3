using System;
using System.Collections.Generic;

namespace ITI.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Bird> _birds;
        readonly Dictionary<string, Cat> _cats;
        readonly Random _random;

        public Zoo()
        {
            _birds = new Dictionary<string, Bird>();
            _cats = new Dictionary<string, Cat>();
            _random = new Random();
        }

        public Bird CreateBird(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_birds.ContainsKey(name)) throw new ArgumentException("A bird with this name already exists.", nameof(name));

            Bird bird = new Bird(this, name);
            _birds.Add(name, bird);
            return bird;
        }

        public Cat CreateCat(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_cats.ContainsKey(name)) throw new ArgumentException("A cat with this name already exists.", nameof(name));

            Cat cat = new Cat(this, name);
            _cats.Add(name, cat);
            return cat;
        }

        public Bird FindBird(string name)
        {
            _birds.TryGetValue(name, out Bird bird);
            return bird;
        }

        public Cat FindCat(string name)
        {
            _cats.TryGetValue(name, out Cat cat);
            return cat;
        }

        internal void OnRename(Cat cat, string newName)
        {
            if (_cats.ContainsKey(newName)) throw new ArgumentException("A cat with this name already exists.", nameof(newName));

            _cats.Remove(cat.Name);
            _cats.Add(newName, cat);
        }

        internal void OnRename(Bird bird, string newName)
        {
            if (_birds.ContainsKey(newName)) throw new ArgumentException("A bird with this name already exists.", nameof(newName));

            _birds.Remove(bird.Name);
            _birds.Add(newName, bird);
        }

        internal void OnKill(Cat cat)
        {
            _cats.Remove(cat.Name);
        }

        internal void OnKill(Bird bird)
        {
            _birds.Remove(bird.Name);
        }

        internal Position GetRandomPosition()
        {
            return new Position(GetNextRandomDouble(-1.0, 1.0), GetNextRandomDouble(-1.0, 1.0));
        }

        internal double GetNextRandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }
    }
}
