using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.ConsoleHelper
{
    public class Cell
    {
        private const char CELL_CHAR = '▄';

        private ConsoleState.Color color;

        public ConsoleColor Top { set => color = new ConsoleState.Color(color.Foreground, value); }
        public ConsoleColor Bottom { set => color = new ConsoleState.Color(value, color.Background); }

        public Cell() => color = new ConsoleState.Color(ConsoleColor.Black, ConsoleColor.Black);

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
            ConsoleState.Instance.SetColor(color); //!!!
            Console.Write(CELL_CHAR);
            ConsoleState.Instance.UndoColor(); //!!!
            return this;
        }
    }
}
