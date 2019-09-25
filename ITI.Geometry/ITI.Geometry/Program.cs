using System;

namespace ITI.Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Segment s = new Segment(3, 5);
            DisplaySegment(s);

            s.Left = 2;
            DisplaySegment(s);

            s.Right = 10;
            DisplaySegment(s);

            s.Move(2);
            DisplaySegment(s);

            s.Move(-4);
            DisplaySegment(s);

            Console.WriteLine("Is 0 on [3, 8[ ? {0}", s.IsOn(0));
            Console.WriteLine("Is 4 on [3, 8[ ? {0}", s.IsOn(4));
            Console.WriteLine("Is 12 on [3, 8[ ? {0}", s.IsOn(12));

            s.Left = 0;
            Console.WriteLine("[0, 5[ overlaps [0, 5[ ? {0} - expected: True", s.IsOverlaping(Segment.Create(0, 5)));
            Console.WriteLine("[0, 5[ overlaps [-1, 6[ ? {0} - expected: True", s.IsOverlaping(Segment.Create(-1, 6)));
            Console.WriteLine("[0, 5[ overlaps [-2, -1[ ? {0} - expected: False", s.IsOverlaping(Segment.Create(-2, -1)));
            Console.WriteLine("[0, 5[ overlaps [6, 8[ ? {0} - expected: False", s.IsOverlaping(Segment.Create(6, 8)));
            Console.WriteLine("[0, 5[ overlaps [3, 4[ ? {0} - expected: True", s.IsOverlaping(Segment.Create(3, 4)));
            Console.WriteLine("[0, 5[ overlaps [-2, 3[ ? {0} - expected: True", s.IsOverlaping(Segment.Create(-2, 3)));
            Console.WriteLine("[0, 5[ overlaps [3, 8[ ? {0} - expected: True", s.IsOverlaping(Segment.Create(3, 8)));

            DisplaySegment(s.GetIntersection(Segment.Create(-2, 3)));
            DisplaySegment(s.GetIntersection(Segment.Create(3, 4)));
            DisplaySegment(s.GetIntersection(Segment.Create(6, 8)));

            Console.WriteLine("[0, 5[ is equal to [0, 5[ ? {0} - expected: true", s.IsEqual(Segment.Create(0, 5)));
            Console.WriteLine("[0, 5[ is equal to [1, 4[ ? {0} - expected: false", s.IsEqual(Segment.Create(1, 4)));
            Console.WriteLine("[0, 5[ is equal to [0, 5[ ? {0} - expected: true", s.IsEqual(s));
        }

        static void DisplaySegment(Segment s)
        {
            if (s == null) Console.WriteLine("The segment is null.");
            else Console.WriteLine("Left: {0}, right: {1}, length; {2}", s.Left, s.Right, s.Length);
        }
    }
}
