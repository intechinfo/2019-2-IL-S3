using System;

namespace ITI.MicroZoo
{
    public struct Vector
    {
        public readonly double X;
        public readonly double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector Add(Vector other)
        {
            return new Vector(X + other.X, Y + other.Y);
        }

        public Vector Sub(Vector other)
        {
            return new Vector(X - other.X, Y - other.Y);
        }

        public Vector Multiply(double n)
        {
            return new Vector(X * n, Y * n);
        }

        public double Magnitude
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }
    }
}
