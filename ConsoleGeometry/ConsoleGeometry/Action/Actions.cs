using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ConsoleGeometry.Geometry.Printable;

namespace ConsoleGeometry.Action
{
    public class Actions
    {
        public int FPS { get; set; }

        private List<AbstractPrintableFigure> figures;

        public Actions()
        {
            figures = new List<AbstractPrintableFigure>();
            FPS = 24;
        }

        public void Add(AbstractPrintableFigure figure) => figures.Add(figure);
        public void Remove(AbstractPrintableFigure figure) => figures.Remove(figure);

        public void Action(CancellationToken token = default)
        {
            try
            {
                foreach (AbstractPrintableFigure figure in figures)
                    figure.ToZeroFrame();
                while (true)
                {
                    foreach (AbstractPrintableFigure figure in figures)
                    {
                        token.ThrowIfCancellationRequested();
                        if (!figure.NextFrame())
                            figure.ToFirstFrame();
                        figure.Print();
                    }

                    Thread.Sleep(1000 / FPS);

                    foreach (AbstractPrintableFigure figure in figures)
                        figure.Eraze();
                }
            }
            catch (OperationCanceledException ex) { }
        }
    }
}
