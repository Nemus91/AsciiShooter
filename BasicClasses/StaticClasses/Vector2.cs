using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsciiShooter
{
    public class Vector2
    {
        public int X;
        public int Y;

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Vector2 copyFrom)
        {
            X = copyFrom.X;
            Y = copyFrom.Y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public static Vector2 operator *(int a, Vector2 b)
        {
            return new Vector2(b.X * a, b.Y * a);
        }

        public static Vector2 operator *(Vector2 b, int a)
        {
            return a * b;
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                Vector2 other = obj as Vector2;
                return ((other.X == X) && (other.Y == Y));
            }
            return base.Equals(obj);
        }
    }
}
