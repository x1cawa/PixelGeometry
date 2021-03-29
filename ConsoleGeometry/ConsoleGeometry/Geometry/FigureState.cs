using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public class FigureState : IFigureState, ICloneable
    {
        private int rotation;

        public Point Center { get; set; }
        public float Size { get; set; }
        public int Rotation { get => rotation; set => rotation = value % 360; }

        public FigureState() : this(new Point(0,0), 1, 0) { }

        public FigureState(Point center, float size, int rotation)
        {
            Center = center;
            Size = size;
            Rotation = rotation;
        }

        public void Reset()
        {
            Center.Left = 0;
            Center.Top = 0;
            Size = 1;
            Rotation = 0;
        }

        public object Clone() => new FigureState((Point)Center.Clone(), Size, Rotation);
    }
}
