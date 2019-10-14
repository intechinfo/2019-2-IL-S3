using System;
using System.Collections.Generic;

namespace ITI.MicroZoo
{
    public class Cat : Animal
    {
        internal Cat(Zoo context, string name)
            : base(context, name)
        {
        }

        public void Kill()
        {
            if (!IsAlive) throw new InvalidOperationException("This cat is already dead.");

            Zoo.OnKill(this);
            Zoo = null;
        }

        internal override void Update()
        {
            List<Bird> birds = Zoo.Birds;
            double minDistance = double.MaxValue;
            Bird target = null;
            foreach (Bird bird in birds)
            {
                double distance = Math.Sqrt(Math.Pow(X - bird.X, 2) + Math.Pow(Y - bird.Y, 2));
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = bird;
                }
            }

            if (target != null)
            {
                if (minDistance < Zoo.Options.CatSpeed)
                {
                    Position = target.Position;
                    target.Kill();
                }
                else
                {

                    Vector direction = target.Position.Sub(Position);
                    direction = direction.Multiply(1 / direction.Magnitude);
                    Vector move = direction.Multiply(Zoo.Options.CatSpeed);
                    Position = Position.Add(move);
                }
            }
        }
    }
}
