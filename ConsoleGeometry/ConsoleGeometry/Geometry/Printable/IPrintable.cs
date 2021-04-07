using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Geometry.Printable
{
    public interface IPrintable
    {
        public Color Color { get; set; }
        public IPrinter Printer { get; set; }

        public void Print();
        public void Eraze();
    }
}
