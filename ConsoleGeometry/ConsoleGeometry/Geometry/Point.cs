using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Geometry.Maths;

namespace ConsoleGeometry.Geometry
{
    public class Point : IPoint, ICloneable
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public Point() : this(0, 0) {}
        public Point(int left, int top) => SetLeftTop(left, top);
        public Point(ConsoleState.Cursor cursor, bool bottom) : this(cursor.Left, cursor.Top * 2 + Convert.ToInt32(bottom)) { }

        #region Methods
        public void SetLeftTop(int x, int y) { Left = x; Top = y; }
        public override string ToString() => $"({Left},{Top})";
        public virtual object Clone() => new Point(Left, Top);
        public ConsoleState.Cursor ToCursor() => new ConsoleState.Cursor(this);
        #endregion

        #region Operators
        public static Point operator +(Point another) => another;
        public static Point operator -(Point another) => new Point(-another.Left, -another.Top);
        public static Point operator +(Point left, Point right) => new Point(left.Left + right.Left, left.Top + right.Top);
        public static Point operator -(Point left, Point right) => left + (-right);
        public static Point operator +(Point point, VectorDouble vector) => point + vector.ToIntVector();
        public static Point operator +(Point point, Vector vector) => new Point(point.Left + vector.X, point.Top + vector.Y);
        public static Point operator -(Point point, VectorDouble vector) => point + (-vector);
        public static Point operator -(Point point, Vector vector) => point + (-vector);
        #endregion
    }
}
