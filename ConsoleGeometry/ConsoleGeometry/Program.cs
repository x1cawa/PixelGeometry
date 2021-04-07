using System;
using System.Threading;

using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using ConsoleGeometry.ConsoleHelper;
using System.Threading.Tasks;
using ConsoleGeometry.Action;

using Color = System.Drawing.Color;

namespace ConsoleGeometry
{
    class Program
    {
        //static bool stop = false;
        static bool stopped = false;
        static CancellationTokenSource tokenSource;

        static void Main(string[] args)
        {
            //TODO: Function for amount of circle dots
            //TODO: Animation FPS set
            //TODO: Class Actions
            tokenSource = new CancellationTokenSource();
            Animate();
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
            tokenSource.Cancel();
            //stop = true;
            while (!stopped) ;
        }

        public static async void Animate()
        {
            ConsoleState.Instance.HideCursor();

            AbstractPrintableFigure figure = new PrintableTriangle(5, Color.Green, ConsolePrinter.Instance);
            AbstractPrintableFigure circle = new PrintableCircle(5, Color.Red, ConsolePrinter.Instance);

            circle.MoveHorizontal(50)
                .MoveVertical(40)
                .SetSize(1)
                .ConfirmFrame();
            figure.MoveHorizontal(50)
                .MoveVertical(40)
                .SetSize(1)
                .ConfirmFrame();

            for (int i = 0; i < 360; i += 5)
            {
                if (i < 180)
                {
                    circle.Resize(1.03f).MoveHorizontal(1).ConfirmFrame();
                    figure.Rotate(5).Resize(1.03f).MoveHorizontal(1).ConfirmFrame();
                }
                else
                {
                    circle.Resize(0.97f).MoveHorizontal(-1).ConfirmFrame();
                    figure.Rotate(-5).Resize(0.97f).MoveHorizontal(-1).ConfirmFrame();
                }
            }

            Actions actions = new Actions();
            actions.Add(circle);
            actions.Add(figure);

            await Task.Run(() => actions.Action(tokenSource.Token));
            

            /*AbstractPrintableFigure circle = new PrintableCircle(30, Color.Green, ConsolePrinter.Instance);
            circle.SetPosition(50, 30);
            for (int i = 0; i < 25; i++)
                circle.Resize(0.9f).ConfirmFrame();
            Actions actions = new Actions();
            actions.Add(circle);
            await Task.Run(() => actions.Action(tokenSource.Token));*/

            stopped = true;
        }
    }
}
