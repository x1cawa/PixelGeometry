using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public class Line : ILine, ICloneable
    {
        public Point StartPoint { get; set; }
        public Vector Vector { get; set; }
        public Point EndPoint
        {
            get => StartPoint + Vector;
            set => Vector = new Vector(StartPoint, value);
        }

        public Line() : this(new Point(), new Vector()) { }
        public Line(Point startPoint, Vector vector) => SetLine(startPoint, vector);
        public Line(Point startPoint, Point endPoint) : this(startPoint, new Vector(startPoint, endPoint)) { }

        public void SetLine(Point startPoint, Vector vector)
        {
            StartPoint = startPoint;
            Vector = vector;
        }

        public virtual object Clone() => new Line((Point)StartPoint.Clone(), (Vector)Vector.Clone());

        public IEnumerable<Point> BreakeIntoPoints()
        {
            if (Vector.IsZero)
                yield break;

            Point currPoint = StartPoint;
            float actualPosition = 0;
            float ratio = 0;
            Vector forEachVector = this.Vector.X != 0 ? new Vector(this.Vector.X / Math.Abs(this.Vector.X), 0) : new Vector();
            Vector forRatioVector = this.Vector.Y != 0 ? new Vector(0, this.Vector.Y / Math.Abs(this.Vector.Y)) : new Vector();
            Vector buf = this.Vector;
            if (Math.Abs(Vector.X) < Math.Abs(Vector.Y))
            {
                (forEachVector, forRatioVector) = (forRatioVector, forEachVector);
                buf = new Vector(buf.Y, buf.X);
            }

            ratio = buf.Y != 0 ? Math.Abs(buf.X) / (float)Math.Abs(buf.Y) : 1;
            actualPosition = ratio;

            for(int i = 0; i < Math.Max(Math.Abs(Vector.X), Math.Abs(Vector.Y)); i++)
            {
                yield return currPoint;
                currPoint += forEachVector;
                actualPosition -= 1;
                if (actualPosition <= 0)
                {
                    currPoint += forRatioVector;
                    actualPosition += ratio;
                }
            }

            yield break;
        }

        public static Line operator *(int multiplier, Line line) => line * multiplier;
        public static Line operator *(Line line, int multiplier) => new Line(line.StartPoint, line.Vector * multiplier);
        public static Line operator /(Line line, int divider) => new Line(line.StartPoint, line.Vector / divider);
    }
}
