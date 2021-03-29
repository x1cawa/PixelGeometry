using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry.Maths
{
    public class RotMatrix
    {
        public double Rotation { get; set; }

        public RotMatrix() { }
        public RotMatrix(double rotation) => Rotation = rotation;
        public static double ToRadians(double deg) => deg * Math.PI / 180;

        public static VectorDouble operator*(RotMatrix matrix, VectorDouble vector)
        {
            double rad = ToRadians(matrix.Rotation);
            double sin = Math.Sin(rad);
            double cos = Math.Cos(rad);
            double x = vector.X * cos - vector.Y * sin;
            double y = vector.X * sin + vector.Y * cos;
            return new VectorDouble(x, y);
        }
            


    }
}
