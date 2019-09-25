using System;

namespace ITI.Geometry
{
    public class Segment
    {
        readonly int _length;
        int _position;

        public Segment(int position, int length)
        {
            _position = position;
            _length = Math.Abs(length);
        }

        public static Segment Create(int point1, int point2)
        {
            int left = Math.Min(point1, point2);
            int right = Math.Max(point1, point2);
            return new Segment(left, right - left);
        }

        public void Move(int delta)
        {
            _position += delta;
        }

        public int Left
        {
            get { return _position; }
            set { _position = value; }
        }

        public int Right
        {
            get { return _position + _length; }
            set { _position = value - _length; }
        }

        public int Length
        {
            get { return _length; }
        }

        public bool IsOn(int point)
        {
            return _position <= point && point < Right;
        }

        public bool IsOverlaping(Segment other)
        {
            return IsOn(other.Left) || IsOn(other.Right) || other.IsOn(Left);
        }

        public Segment GetIntersection(Segment other)
        {
            if (!IsOverlaping(other)) return null;

            return Segment.Create(
                Math.Max(Left, other.Left),
                Math.Min(Right, other.Right));
        }

        public static Segment GetIntersection(Segment s1, Segment s2)
        {
            return s1.GetIntersection(s2);
        }

        public bool IsEqual(Segment segment)
        {
            return _position == segment._position && _length == segment._length;
        }
    }
}
