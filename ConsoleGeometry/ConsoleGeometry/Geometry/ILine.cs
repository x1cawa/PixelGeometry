﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public interface ILine
    {
        public Point StartPoint { get; set; }
        public Vector Vector { get; set; }
        public Point EndPoint { get; set; }

        public void SetLine(Point startPoint, Vector vector);
    }
}
