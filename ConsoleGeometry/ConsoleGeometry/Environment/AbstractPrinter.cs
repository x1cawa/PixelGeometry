using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using System;
using System.Collections.Generic;
using System.Text;
using Color = System.Drawing.Color;

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

        public abstract void Print(IPoint point, Color color, bool savePoint = true);

        public void Print(ILine line, Color color, bool savePoint = true)
        {
            if (savePoint)
                environmentStates[this.GetType()].SaveCurrentPoint();
            foreach (Point point in line.BreakeIntoPoints())
                Print(point, color, false);
            if (savePoint)
                environmentStates[this.GetType()].UndoPoint();
        }

        public void Print(AbstractPrintableFigure figure, Color color)
        {
            environmentStates[this.GetType()].SaveCurrentPoint();
            foreach (Line line in figure.GetLines())
                Print(line, color, false);
            environmentStates[this.GetType()].SaveCurrentPoint();
        }
    }
}
