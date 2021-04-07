using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Color = System.Drawing.Color;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using ConsoleGeometry.Environment;

namespace ConsoleGeometry.ConsoleHelper
{
    public class ConsolePrinter : AbstractPrinter
    {
        private static ConsolePrinter instance;
        public static ConsolePrinter Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConsolePrinter();
                return instance;
            }
        }

        private readonly Dictionary<ConsoleState.Cursor, Cell> repo;

        //public static char TopSquare { get => '▀'; }
        //public static char DoubleSquare { get => '█'; }
        //public static char BottomSquare { get => '▄'; }

        private ConsolePrinter()
        {
            repo = new Dictionary<ConsoleState.Cursor, Cell>();
            EnvironmentState = ConsoleState.Instance;
        }

        public override void Print(IPoint point, Color color, bool savePoint = true)
        {
            var cursor = new ConsoleState.Cursor(point);
            EnvironmentState.SetPoint(point, savePoint);
            //ConsoleState.Instance.SetCursor(cursor, saveCursor); //!!!! EnvironmentState.SetCursor(cursor, saveCursor);
            bool bottom = point.Top % 2 == 1;
            if (repo.ContainsKey(cursor))
                repo[cursor].Set(color.ToConsoleColor(), bottom).Print();
            else
                repo.Add(cursor, new Cell(cursor, color.ToConsoleColor(), bottom).Print());
            if(savePoint)
                EnvironmentState.UndoPoint();
        }
    }
}
