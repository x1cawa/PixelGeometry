using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.Environment;
using Color = System.Drawing.Color;

namespace ConsoleGeometry.Geometry.Printable
{
    public class PrintableSquare : AbstractPrintableFigure
    {
        private PrintableRect rect;
        public int Width { get => rect.Width; set { rect.Width = value; rect.Height = value; } }
        public override Color Color { get => rect.Color; set => rect.Color = value; }

        public PrintableSquare(int width, Color color, IPrinter printer) : base(printer) { rect = new PrintableRect(width, width, color, printer); }

        public override IEnumerable<Line> GetLines() => rect.GetLines();
        public override void Print() => rect.Print();
        public override void Eraze() => rect.Eraze();

        public override IAnimatable ConfirmFrame() => rect.ConfirmFrame();
        public override IAnimatable MoveHorizontal(int range) => rect.MoveHorizontal(range);
        public override IAnimatable MoveVertical(int range) => rect.MoveVertical(range);
        public override IAnimatable SetPosition(int left, int top) => rect.SetPosition(left, top);
        public override IAnimatable Resize(float size) => rect.Resize(size);
        public override IAnimatable Rotate(int grad) => rect.Rotate(grad);
        public override IAnimatable SetRotation(int grad) => rect.SetRotation(grad);
        public override IAnimatable SetSize(float size) => rect.SetSize(size);
        public override bool NextFrame() => rect.NextFrame();
        public override FigureState GetLastFrame() => rect.GetLastFrame();
        public override void ResetAnimation() => rect.ResetAnimation();
        public override void ToFirstFrame() => rect.ToFirstFrame();
        public override void ToZeroFrame() => rect.ToZeroFrame();
        public override FigureState GetCurrentFrame() => rect.GetCurrentFrame();
    }
}
