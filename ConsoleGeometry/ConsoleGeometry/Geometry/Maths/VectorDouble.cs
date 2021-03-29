using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry.Maths
{
    public class VectorDouble : ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool IsZero { get => X == 0 && Y == 0; }

        public VectorDouble() : this(0, 0) { }
        public VectorDouble(double x, double y) { X = x; Y = y; }

        public object Clone() => new VectorDouble(X, Y);
        public override string ToString() => $"({X:f2}; {Y:f2})";
        public Vector ToIntVector() => new Vector((int)Math.Floor(X), (int)Math.Floor(Y));

        public static VectorDouble operator *(VectorDouble vector, double multiplier) => new VectorDouble(vector.X * multiplier, vector.Y * multiplier);
        public static VectorDouble operator *(double multiplier, VectorDouble vector) => vector * multiplier;
        public static VectorDouble operator /(VectorDouble vector, double divider)
        {
            if (divider == 0)
                throw new DivideByZeroException();
            return new VectorDouble(vector.X / divider, vector.Y / divider);
        }
        public static VectorDouble operator -(VectorDouble vector) => new VectorDouble(-vector.X, -vector.Y);
        public static VectorDouble operator +(VectorDouble left, VectorDouble right) => new VectorDouble(left.X + right.X, left.Y + right.Y);
        public static VectorDouble operator -(VectorDouble left, VectorDouble right) => left + (-right);
    }
}
