using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Environment
{
    public interface IPrinter
    {
        public void Print(IPoint point, Color color, bool savePoint = true);
        public void Print(ILine line, Color color, bool savePoint = true);
        public void Print(AbstractPrintableFigure figure, Color color);
    }
}
