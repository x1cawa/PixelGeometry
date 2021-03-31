using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintablePoint : Point, IPrintable
    {
        public ConsoleColor Color { get; set; }

        public PrintablePoint() : this(0, 0) { }
        public PrintablePoint(int left, int top) : this(left, top, ConsoleColor.Gray) { }

        public PrintablePoint(int left, int top, ConsoleColor color) : base(left, top) { Color = color; }

        public void Print()
        {
            ConsolePrinter.Instance.Print(this, Color); //!!!!!!!!
        }

        public void Eraze()
        {
            ConsolePrinter.Instance.Print(this, ConsoleColor.Black); //!!!!!!!!!!
        }

        public override object Clone() => new PrintablePoint(Left, Top, Color);
    }
}
