using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Geometry.Maths;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableRect : AbstractPrintableFigure
    {
        //+ center, size and rot
        public int Width { get; set; }
        public int Height { get; set; }

        public PrintableRect() { }
        public PrintableRect(int width, int height, ConsoleColor color) { Width = width; Height = height; Color = color; }

        public override IEnumerable<Line> GetLines()
        {
            FigureState state = this.GetCurrentFrame();
            RotMatrix rotMatrix = new RotMatrix(state.Rotation);
            VectorDouble widthVector = rotMatrix * new VectorDouble((Width / 2.0) * state.Size, 0);
            VectorDouble heightVector = rotMatrix * new VectorDouble(0, Height / 2 * state.Size);

            yield return new Line(state.Center + widthVector + heightVector, state.Center + widthVector - heightVector);
            yield return new Line(state.Center + widthVector - heightVector, state.Center - widthVector - heightVector);
            yield return new Line(state.Center - widthVector - heightVector, state.Center - widthVector + heightVector);
            yield return new Line(state.Center - widthVector + heightVector, state.Center + widthVector + heightVector);
        }
    }
}
