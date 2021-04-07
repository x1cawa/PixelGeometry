using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Geometry;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Environment
{
    public interface IEnvironmentState
    {
        public void SaveCurrentColor();
        public void SaveCurrentPoint();

        public void UndoColor();
        public void UndoPoint();
        public void SetColor(Color color, bool savePrevious = true);
        public void SetPoint(IPoint point, bool savePrevious = true);
        public Color GetColor();
        public IPoint GetPoint();
        public void ResetColor(bool savePrevious = true);
        public void ResetPoint(bool savePrevious = true);
        public void ClearColorsStack();
        public void ClearPointsStack();
        public void SetBoth(Color color, IPoint point, bool savePrevious = true);
        public void UndoBoth();

        public void SaveState();
        public void UndoToSaved();
    }
}
