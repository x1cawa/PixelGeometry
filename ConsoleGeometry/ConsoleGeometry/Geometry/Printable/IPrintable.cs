using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;

namespace ConsoleGeometry.Geometry.Printable
{
    public interface IPrintable
    {
        public ConsoleColor Color {get; set;}

        public void Print();
        public void Eraze();
    }
}
