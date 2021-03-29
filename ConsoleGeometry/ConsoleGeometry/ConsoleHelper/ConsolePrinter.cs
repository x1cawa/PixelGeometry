using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;

namespace ConsoleGeometry.ConsoleHelper
{
    public static class ConsolePrinter
    {
        private static Dictionary<ConsoleState.Cursor, Cell> repo;

        //public static char TopSquare { get => '▀'; }
        //public static char DoubleSquare { get => '█'; }
        //public static char BottomSquare { get => '▄'; }

        static ConsolePrinter()
        {
            repo = new Dictionary<ConsoleState.Cursor, Cell>();
        }

        public static void Print(Point point, ConsoleColor color, bool saveCursor = true)
        {
            var cursor = new ConsoleState.Cursor(point);
            ConsoleState.SetCursor(cursor, saveCursor);
            bool bottom = point.Top % 2 == 1;
            if (repo.ContainsKey(cursor))
                repo[cursor].Set(color, bottom).Print();
            else
                repo.Add(cursor, new Cell().Set(color, bottom).Print());
            if(saveCursor)
                ConsoleState.UndoCursor();
        }

        public static void Print(Line line, ConsoleColor color, bool saveCursor = true)
        {
            if(saveCursor)
                ConsoleState.SaveCurrentCursor();
            foreach (Point point in line.BreakeIntoPoints())
                Print(point, color, false);
            if(saveCursor)
                ConsoleState.UndoCursor();
        }
        
        public static void Print(AbstractPrintableFigure figure, ConsoleColor color)
        {
            ConsoleState.SaveCurrentCursor();
            foreach (Line line in figure.GetLines())
                Print(line, color, false);
            ConsoleState.UndoCursor();
        }
    }
}
