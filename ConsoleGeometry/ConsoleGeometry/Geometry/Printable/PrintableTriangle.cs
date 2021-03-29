using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Geometry.Maths;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableTriangle : AbstractPrintableFigure
    {
        public int CircumscribedRadius { get; set; }
        public PrintableTriangle(int circumscribedRadius, ConsoleColor color) { CircumscribedRadius = circumscribedRadius; Color = color; }

        public override IEnumerable<Line> GetLines()
        {
            FigureState state = this.GetCurrentFrame();
            RotMatrix rotMatrix = new RotMatrix(120);
            VectorDouble vector = new RotMatrix(state.Rotation) * new VectorDouble(CircumscribedRadius * state.Size, 0);
            VectorDouble nextVector = rotMatrix * vector;
            for (int i = 0; i < 3; i++)
            {
                yield return new Line(state.Center + vector, state.Center + nextVector);
                (vector, nextVector) = (nextVector, rotMatrix * nextVector);
            }
        }
    }
}
