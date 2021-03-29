using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public interface IPoint
    {
        public int Left { get; set; }
        public int Top { get; set; }

        public void SetLeftTop(int left, int top);
    }
}
