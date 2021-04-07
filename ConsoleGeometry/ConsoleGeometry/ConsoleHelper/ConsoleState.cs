using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.ConsoleHelper
{
    public class ConsoleState : IEnvironmentState
    {
        #region Types
        /*public struct Color
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
        */
        public struct Cursor
        {
            public readonly int Left;
            public readonly int Top;

            public Cursor(int left, int top) { Left = left; Top = top; }
            public Cursor(IPoint point) { Left = point.Left; Top = point.Top / 2; }

            public static Cursor ReadConsole() => new Cursor(Console.CursorLeft, Console.CursorTop);
            public static Cursor Default() => new Cursor();
            public override string ToString() => $"({Left}, {Top})";

            public void WriteConsole()
            {
                Console.CursorLeft = Left;
                Console.CursorTop = Top;
            }
        }

        #endregion

        private static ConsoleState instance;
        public static ConsoleState Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConsoleState();
                return instance;
            }
        }

        private Color currColor;
        private IPoint currPoint;

        private readonly Stack<Color> colors;
        private readonly Stack<IPoint> points;
        private int colorChanges;
        private int pointChanges;

        private ConsoleState()
        {
            colors = new Stack<Color>();
            points = new Stack<IPoint>();
            colorChanges = 0;
            pointChanges = 0;
            currColor = Color.LightGray;
            currPoint = new Point();
        }

        public void SaveCurrentColor()
        {
            colorChanges++;
            colors.Push(currColor);
        }
        public void SaveCurrentPoint()
        {
            pointChanges++;
            points.Push((IPoint)currPoint.Clone());
        }


        public void HideCursor() => Console.CursorVisible = false;
        public void ShowCursor() => Console.CursorVisible = true;
        public void UndoColor()
        {
            colorChanges--;
            currColor = colors.Pop();
        }
        public void UndoPoint()
        {
            pointChanges--;
            currPoint = points.Pop();
        }
        public void SetColor(Color color, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentColor();
            currColor = color;
        }
        public void SetConsoleColors(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }
        public void SetPoint(IPoint point, bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentPoint();
            currPoint = (IPoint)point.Clone();
        }
        public Color GetColor() => currColor;
        public IPoint GetPoint() => currPoint;
        public Cursor GetCursor() => new Cursor(currPoint);
        public void ResetColor(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentColor();
            SetColor(Color.LightGray);
        }
        public void ResetPoint(bool savePrevious = true)
        {
            if (savePrevious)
                SaveCurrentPoint();
            SetPoint(new Point());
        }
        public void ClearColorsStack()
        {
            colorChanges = 0;
            colors.Clear();
        }
        public void ClearPointsStack()
        {
            pointChanges = 0;
            points.Clear();
        }
        public void SetBoth(Color color, IPoint point, bool savePrevious = true)
        {
            SetColor(color, savePrevious);
            SetPoint(point, savePrevious);
        }
        public void UndoBoth()
        {
            UndoColor();
            UndoPoint();
        }

        public void SaveState()
        {
            pointChanges = 0;
            colorChanges = 0;
        }

        public void UndoToSaved()
        {
            while (colors.Count > colors.Count - colorChanges)
                colors.Pop();
            while (points.Count > points.Count - pointChanges)
                points.Pop();
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
