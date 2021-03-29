using ConsoleGeometry.ConsoleHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableLine : Line, IPrintable
    {
        public ConsoleColor Color { get; set; }

        public PrintableLine() : this(new Point(), new Vector()) { }
        public PrintableLine(ConsoleColor color) : this(new Point(), new Vector()) { Color = color; }
        public PrintableLine(Point startPoint, Vector vector) : this(startPoint, vector, ConsoleColor.Gray) { }
        public PrintableLine(Point startPoint, Vector vector, ConsoleColor color) : base(startPoint, vector) { Color = color; }
        public PrintableLine(Point startPoint, Point endPoint) : this(startPoint, endPoint, ConsoleColor.Gray) { }
        public PrintableLine(Point startPoint, Point endPoint, ConsoleColor color) : base(startPoint, endPoint) { Color = color; }

        public void Print()
        {
            ConsolePrinter.Print(this, Color);
        }

        public void Eraze()
        {
            ConsolePrinter.Print(this, ConsoleColor.Black);
        }

        public override object Clone() => new PrintableLine(StartPoint, Vector, Color);
    }
}
