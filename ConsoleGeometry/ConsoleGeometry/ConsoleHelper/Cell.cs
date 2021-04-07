using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.ConsoleHelper
{
    public class Cell
    {
        private const char CELL_CHAR = '▄';

        public ConsoleState.Cursor Postion { get; set; }
        public ConsoleColor Top { get; set; }
        public ConsoleColor Bottom { get; set; }

        public Cell(ConsoleState.Cursor cursor, ConsoleColor color, bool bottom)
        {
            Postion = cursor;
            Top = ConsoleColor.Black;
            Bottom = ConsoleColor.Black;
            if (bottom)
                Bottom = color;
            else
                Top = color;
        }

        public Cell Set(ConsoleColor color, bool bottom)
        {
            if (bottom)
                Bottom = color;
            else
                Top = color;
            return this;
        }

        public Cell Print()
        {
            ConsoleState.Instance.SetConsoleColors(Top, Bottom);
            Postion.WriteConsole();
            Console.Write(CELL_CHAR);
            return this;
        }
    }
}
