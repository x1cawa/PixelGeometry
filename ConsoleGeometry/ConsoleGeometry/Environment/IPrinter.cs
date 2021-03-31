using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;

namespace ConsoleGeometry.Environment
{
    public interface IPrinter
    {
        public void Print(Point point, ConsoleColor color, bool saveCursor = true);
        public void Print(Line line, ConsoleColor color, bool saveCursor = true);
        public void Print(AbstractPrintableFigure figure, ConsoleColor color);
    }
}
