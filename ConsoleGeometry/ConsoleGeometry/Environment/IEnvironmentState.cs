using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Environment
{
    public interface IEnvironmentState
    {
        public void SaveCurrentColor();
        public void SaveCurrentCursor();

        public void UndoColor();
        public void UndoCursor();
        public void ResetColor(bool savePrevious = true);
        public void ResetCursor(bool savePrevious = true);
        public void ClearColorsStack();
        public void ClearCursorStack();
        public void UndoBoth();

        public void SaveState();
        public void UndoToSaved();

        //set/get IColor/ICursor
    }
}
