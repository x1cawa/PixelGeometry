﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleGeometry.ConsoleHelper;

namespace ConsoleGeometry.Geometry.Printable
{
    public abstract class AbstractPrintableFigure : IAnimatable, IPrintableAnimation
    {
        private FigureState currState;
        private FigureState nextState;
        private readonly List<FigureState> frames;
        private int currFrame;

        public virtual ConsoleColor Color { get; set; }

        public AbstractPrintableFigure()
        {
            currFrame = 0;
            currState = new FigureState();
            nextState = new FigureState();
            frames = new List<FigureState>();
        }

        public virtual IAnimatable ConfirmFrame()
        {
            currState = (FigureState)nextState.Clone();
            frames.Add(currState);
            return this;
        }

        public virtual IAnimatable MoveHorizontal(int range)
        {
            nextState.Center.Left += range;
            return this;
        }

        public virtual IAnimatable MoveVertical(int range)
        {
            nextState.Center.Top += range;
            return this;
        }

        public virtual IAnimatable Resize(float size)
        {
            nextState.Size *= size;
            return this;
        }

        public virtual IAnimatable Rotate(int grad)
        {
            nextState.Rotation += grad;
            return this;
        }

        public virtual IAnimatable SetRotation(int grad)
        {
            nextState.Rotation = grad;
            return this;
        }

        public virtual IAnimatable SetSize(float size)
        {
            nextState.Size = size;
            return this;
        }

        public virtual bool NextFrame()
        {
            if (currFrame < frames.Count - 1)
            {
                currFrame++;
                return true;
            }
            else
                return false;
        }

        public virtual FigureState GetLastFrame() => frames[frames.Count - 1];

        public virtual void Print() => ConsolePrinter.Print(this, Color);
        public virtual void Eraze() => ConsolePrinter.Print(this, ConsoleColor.Black);

        public virtual void ResetAnimation()
        {
            this.ToFirstFrame();
            currState.Reset();
            nextState.Reset();
            frames.Clear();
        }

        public virtual void ToFirstFrame() => currFrame = 0;
        public virtual void ToZeroFrame() => currFrame = -1;

        public virtual FigureState GetCurrentFrame() => frames[currFrame];

        public abstract IEnumerable<Line> GetLines();
    }
}
