using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;

namespace ConsoleGeometry.ConsoleHelper
{
    public static class ConsoleState
    {
        public struct Color
        {
            public readonly ConsoleColor Foreground;
            public readonly ConsoleColor Background;

            public Color(ConsoleColor foreground, ConsoleColor background) { Foreground = foreground; Background = background; }

            public static Color ReadConsole() => new Color(Console.ForegroundColor, Console.BackgroundColor);
            public static Color Default() => new Color(ConsoleColor.Gray, ConsoleColor.Black);
            public override string ToString() => $"(f:{Foreground}, b:{Background})";
            public void WriteConsole()
            {
                Console.ForegroundColor = Foreground;
                Console.BackgroundColor = Background;
            }
        }

        public struct Cursor
        {
            public readonly int Left;
            public readonly int Top;

            public Cursor(int left, int top) { Left = left; Top = top; }
            public Cursor(Point point) { Left = point.Left; Top = point.Top / 2; }

            public static Cursor ReadConsole() => new Cursor(Console.CursorLeft, Console.CursorTop);
            public static Cursor Default() => new Cursor();
            public override string ToString() => $"({Left}, {Top})";

            public void WriteConsole()
            {
                Console.CursorLeft = Left;
                Console.CursorTop = Top;
            }
        }

        private static readonly Stack<Color> colors;
        private static readonly Stack<Cursor> cursors;
        private static int colorChanges;
        private static int cursorChanges;

        static ConsoleState()
        {
            colors = new Stack<Color>();
            cursors = new Stack<Cursor>();
            colorChanges = 0;
            cursorChanges = 0;
        }

        public static void SaveCurrentColor()
        {
            colorChanges++;
            colors.Push(Color.ReadConsole());
        }
        public static void SaveCurrentCursor()
        {
            cursorChanges++;
            cursors.Push(Cursor.ReadConsole());
        }


        public static void HideCursor() => Console.CursorVisible = false;
        public static void ShowCursor() => Console.CursorVisible = true;
        public static void UndoColor()
        {
            colorChanges--;
            colors.Pop().WriteConsole();
        }
        public static void UndoCursor()
        {
            cursorChanges--;
            cursors.Pop().WriteConsole();
        }
        public static void SetColor(Color color, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentColor();
            color.WriteConsole();
        }
        public static void SetCursor(Cursor cursor, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            cursor.WriteConsole();
        }
        public static Color GetColor() => Color.ReadConsole();
        public static Cursor GetCursor() => Cursor.ReadConsole();
        public static void ResetColor(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentColor();
            SetColor(Color.Default());
        }
        public static void ResetCursor(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            SetCursor(Cursor.Default());
        }
        public static void ClearColorsStack()
        {
            colorChanges = 0;
            colors.Clear();
        }
        public static void ClearCursorStack()
        {
            cursorChanges = 0;
            cursors.Clear();
        }
        public static void SetBoth(Color color, Cursor cursor, bool savePrevious = true)
        {
            SetColor(color, savePrevious);
            SetCursor(cursor, savePrevious);
        }
        public static void UndoBoth()
        {
            UndoColor();
            UndoCursor();
        }

        public static void SaveState()
        {
            cursorChanges = 0;
            colorChanges = 0;
        }

        public static void UndoToSaved()
        {
            while (colors.Count > colors.Count - colorChanges)
                colors.Pop();
            while (cursors.Count > cursors.Count - cursorChanges)
                cursors.Pop();
        }
        /*
        public static void MoveUp(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorTop++;
        }

        public static void MoveRight(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorLeft++;
        }

        public static void MoveDown(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorTop--;
        }

        public static void MoveLeft(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorLeft--;
        }

        public static void MoveHorizontal(int move, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorLeft += move;
        }

        public static void MoveVertical(int move, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentCursor();
            Console.CursorTop += move;
        }
        */
    }
}
