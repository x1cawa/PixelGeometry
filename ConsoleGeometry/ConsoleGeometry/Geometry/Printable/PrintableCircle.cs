using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Geometry.Maths;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableCircle : AbstractPrintableFigure
    {
        /// <summary>360 * Accuracy dots</summary>
        public double Accuracy { get; set; }
        public int Radius { get; set; }
        public PrintableCircle(int radius, ConsoleColor color)
        {
            Radius = radius;
            Color = color;
            Accuracy = radius / 35.0;//0.3;//1 / 10.0;
        }

        public override IEnumerable<Line> GetLines()
        {
            FigureState state = this.GetCurrentFrame();
            VectorDouble radius = new VectorDouble(Radius * state.Size, 0);
            double rotation = 1 / Accuracy;
            int dots = (int)Math.Round(360 * Accuracy);
            for(int i = 0; i <= dots; i++)
            {
                VectorDouble nextVector = new RotMatrix(rotation) * radius;
                yield return new Line(state.Center + radius, state.Center + nextVector);
                radius = nextVector;
            }
        }
    }
}
