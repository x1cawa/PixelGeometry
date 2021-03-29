using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry.Printable
{
    public interface IPrintableAnimation : IPrintable
    {
        public bool NextFrame();
        public void ToFirstFrame();
        public void ResetAnimation();
    }
}
