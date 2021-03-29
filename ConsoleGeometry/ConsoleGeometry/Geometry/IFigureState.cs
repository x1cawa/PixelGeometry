using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    interface IFigureState
    {
        public Point Center { get; }
        public float Size { get; }
        public int Rotation { get; }
    }
}
