using System;
using System.Collections.Generic;

namespace ITI.MicroZoo
{
    public class Zoo
    {
        readonly Dictionary<string, Bird> _birds;
        readonly Dictionary<string, Cat> _cats;

        public Zoo()
        {
            _birds = new Dictionary<string, Bird>();
            _cats = new Dictionary<string, Cat>();
        }

        public Bird CreateBird(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_birds.ContainsKey(name)) throw new ArgumentException("A bird with this name already exists.", nameof(name));

            Bird bird = new Bird(name);
            _birds.Add(name, bird);
            return bird;
        }

        public Cat CreateCat(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must be not null nor whitespace.", nameof(name));
            if (_cats.ContainsKey(name)) throw new ArgumentException("A cat with this name already exists.", nameof(name));

            Cat cat = new Cat(name);
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
    }
}
