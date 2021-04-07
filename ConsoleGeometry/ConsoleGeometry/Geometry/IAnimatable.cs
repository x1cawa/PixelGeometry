using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGeometry.Geometry
{
    public interface IAnimatable
    { 
        public IAnimatable SetSize(float size);
        public IAnimatable Resize(float size);

        public IAnimatable MoveHorizontal(int range);
        public IAnimatable MoveVertical(int range);
        public IAnimatable SetPosition(int left, int top);

        public IAnimatable Rotate(int grad);
        public IAnimatable SetRotation(int grad);

        public IAnimatable ConfirmFrame();
    }
}
