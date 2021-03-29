using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public class Vector : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool IsZero { get => X == 0 && Y == 0; }

        public Vector() : this(0, 0) { }
        public Vector(int x, int y) { X = x; Y = y; }
        public Vector(Point startPoint, Point endPoint) : this(endPoint.Left - startPoint.Left, endPoint.Top - startPoint.Top) {}

        public object Clone() => new Vector(X, Y);
        public override string ToString() => $"({X},{Y})";

        public static Vector operator *(Vector vector, int multiplier) => new Vector(vector.X * multiplier, vector.Y * multiplier);
        public static Vector operator *(int multiplier, Vector vector) => vector * multiplier;
        public static Vector operator /(Vector vector, int divider)
        {
            if (divider == 0)
                throw new DivideByZeroException();
            return new Vector(vector.X / divider, vector.Y / divider);
        }
        public static Vector operator -(Vector vector) => new Vector(-vector.X, -vector.Y);
        public static Vector operator +(Vector left, Vector right) => new Vector(left.X + right.X, left.Y + right.Y);
        public static Vector operator -(Vector left, Vector right) => left + (-right);
    }
}
