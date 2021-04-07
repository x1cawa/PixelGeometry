using ConsoleGeometry.ConsoleHelper;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableLine : Line, IPrintable
    {
        public Color Color { get; set; }
        public IPrinter Printer { get; set; }

        public PrintableLine(IPrinter printer) : this(new Point(), new Vector(), printer) { }
        public PrintableLine(Color color, IPrinter printer) : this(new Point(), new Vector(), printer) { Color = color; }
        public PrintableLine(Point startPoint, Vector vector, IPrinter printer) : this(startPoint, vector, Color.Gray, printer) { }
        public PrintableLine(Point startPoint, Vector vector, Color color, IPrinter printer) : base(startPoint, vector) { Color = color; Printer = printer; }
        public PrintableLine(Point startPoint, Point endPoint, IPrinter printer) : this(startPoint, endPoint, Color.Gray, printer) { }
        public PrintableLine(Point startPoint, Point endPoint, Color color, IPrinter printer) : base(startPoint, endPoint) { Color = color; Printer = printer; }

        public void Print() => Printer.Print(this, Color);

        public void Eraze() => Printer.Print(this, Color.Black);

        public override object Clone() => new PrintableLine(StartPoint, Vector, Color, Printer);
    }
}
