using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Environment
{
    public abstract class AbstractPrinter : IPrinter
    {
        private static readonly Dictionary<Type, IEnvironmentState> environmentStates; //IDisposable?
        public IEnvironmentState EnvironmentState
        {
            get { return environmentStates[this.GetType()]; }
            set { environmentStates[this.GetType()] = value; }
        }

        static AbstractPrinter() { environmentStates = new Dictionary<Type, IEnvironmentState>(); }

        public abstract void Print(Point point, ConsoleColor color, bool saveCursor = true);

        public void Print(Line line, ConsoleColor color, bool saveCursor = true)
        {
            if (saveCursor)
                environmentStates[this.GetType()].SaveCurrentCursor();
            foreach (Point point in line.BreakeIntoPoints())
                Print(point, color, false);
            if (saveCursor)
                environmentStates[this.GetType()].UndoCursor();
        }

        public void Print(AbstractPrintableFigure figure, ConsoleColor color)
        {
            environmentStates[this.GetType()].SaveCurrentCursor();
            foreach (Line line in figure.GetLines())
                Print(line, color, false);
            environmentStates[this.GetType()].UndoCursor();
        }
    }
}
