using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Geometry.Maths;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableCircle : AbstractPrintableFigure
    {
        public int Radius { get; set; }
        public PrintableCircle(int radius, Color color, IPrinter printer) : base(printer)
        {
            Radius = radius;
            Color = color;
        }

        public override IEnumerable<Line> GetLines()
        {
            FigureState state = this.GetCurrentFrame();
            VectorDouble radius = new VectorDouble(Radius * state.Size, 0);
            double accuracy = Radius * state.Size / 100.0;
            double rotation = 1 / accuracy;
            int dots = (int)Math.Round(360 * accuracy);
            for(int i = 0; i <= dots; i++)
            {
                VectorDouble nextVector = new RotMatrix(rotation) * radius;
                yield return new Line(state.Center + radius, state.Center + nextVector);
                radius = nextVector;
            }
        }
    }
}
