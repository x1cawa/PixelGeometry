using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintablePoint : Point, IPrintable
    {
        public Color Color { get; set; }
        public IPrinter Printer { get; set; }

        public PrintablePoint(IPrinter printer) : this(0, 0, printer) { }
        public PrintablePoint(int left, int top, IPrinter printer) : this(left, top, Color.Gray, printer) { }

        public PrintablePoint(int left, int top, Color color, IPrinter printer) : base(left, top) { Color = color; Printer = printer; }

        public void Print() => Printer.Print(this, Color);

        public void Eraze() => Printer.Print(this, Color.Black);

        public override object Clone() => new PrintablePoint(Left, Top, Color, Printer);
    }
}
