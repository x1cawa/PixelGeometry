using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        public override void Print(Point point, ConsoleColor color, bool saveCursor = true)
        {
            var cursor = new ConsoleState.Cursor(point);
            ConsoleState.Instance.SetCursor(cursor, saveCursor); //!!!! EnvironmentState.SetCursor(cursor, saveCursor);
            bool bottom = point.Top % 2 == 1;
            if (repo.ContainsKey(cursor))
                repo[cursor].Set(color, bottom).Print();
            else
                repo.Add(cursor, new Cell().Set(color, bottom).Print());
            if(saveCursor)
                EnvironmentState.UndoCursor();
        }
    }
}
