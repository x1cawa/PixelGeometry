using System;
using System.Threading;

using ConsoleGeometry.Geometry;
using ConsoleGeometry.Geometry.Printable;
using ConsoleGeometry.ConsoleHelper;
using System.Threading.Tasks;

namespace ConsoleGeometry
{
    class Program
    {
        static bool stop = false;
        static bool stopped = false;

        static void Main(string[] args)
        {
            //TODO: console printer to IPrinter + Singleton
            //TODO: ConsoleState to IEnvironmentState + Singleton
            //TODO: Algorhithm for circle
            //TODO: figures (triangle)
            //TODO: Animation FPS set
            Animate();
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
            stop = true;
            while (!stopped) ;
        }

        public static async void Animate()
        {
            ConsoleState.HideCursor();

            //AbstractPrintableFigure figure = new PrintableRect(5, 10, ConsoleColor.Green);
            //AbstractPrintableFigure figure = new PrintableSquare(10, ConsoleColor.Green);
            AbstractPrintableFigure circle = new PrintableCircle(5, ConsoleColor.Red);
            AbstractPrintableFigure triangle = new PrintableTriangle(5, ConsoleColor.Green);
            /*figure.MoveHorizontal(50)
                .MoveVertical(40)
                .SetSize(1)
                .ConfirmFrame();*/
            circle.MoveHorizontal(50)
                .MoveVertical(40)
                .SetSize(1)
                .ConfirmFrame();
            triangle.MoveHorizontal(50)
                .MoveVertical(40)
                .SetSize(1)
                .ConfirmFrame();

            for (int i = 0; i < 360; i += 5)
            {
                if (i < 180)
                {
                    circle.Resize(1.03f).MoveHorizontal(1).ConfirmFrame();
                    triangle.Rotate(5).Resize(1.03f).MoveHorizontal(1).ConfirmFrame();
                    //figure.Rotate(5).Resize(1.03f).MoveHorizontal(1).ConfirmFrame();
                }
                else
                {
                    circle.Resize(0.97f).MoveHorizontal(-1).ConfirmFrame();
                    triangle.Rotate(-5).Resize(0.97f).MoveHorizontal(-1).ConfirmFrame();
                    //figure.Rotate(-5).Resize(0.97f).MoveHorizontal(-1).ConfirmFrame();
                }
            }

            int FPS = 1000 / 24;
            await Task.Run(() => { });
            while(!stop)
            {
                //figure.ToFirstFrame();
                //figure.Print();
                circle.ToZeroFrame();
                triangle.ToZeroFrame();
                Thread.Sleep(FPS);
                //figure.Eraze();
                while (circle.NextFrame() & triangle.NextFrame() && !stop)
                {
                    //figure.Print();
                    circle.Print();
                    triangle.Print();
                    Thread.Sleep(FPS);
                    circle.Eraze();
                    triangle.Eraze();
                    //figure.Eraze();
                }

                /*for (int i = 0; i < 20; i++)
                {
                    if (stop)
                        break;
                    line.Print();
                    line2.Print();
                    Thread.Sleep(FPS);
                    line.Eraze();
                    line2.Eraze();
                    line.Vector.X++;
                    line.Vector.Y--;
                    line2.Vector.X++;
                }
                for (int i = 0; i < 19; i++)
                {
                    if (stop)
                        break;
                    line.Print();
                    line2.Print();
                    Thread.Sleep(FPS);
                    line.Eraze();
                    line2.Eraze();
                    line.Vector.X--;
                    line.Vector.Y++;
                    //line.Vector.Y--;
                    line2.Vector.Y++;
                }
                for (int i = 0; i < 19; i++)
                {
                    if (stop)
                        break;
                    line.Print();
                    line2.Print();
                    Thread.Sleep(FPS);
                    line.Eraze();
                    line2.Eraze();
                    line.Vector.X++;
                    line.Vector.Y--;
                    //line.Vector.Y++;
                    line2.Vector.Y--;
                }
                for (int i = 0; i < 20; i++)
                {
                    if (stop)
                        break;
                    line.Print();
                    line2.Print();
                    Thread.Sleep(FPS);
                    line.Eraze();
                    line2.Eraze();
                    line.Vector.X--;
                    line.Vector.Y++;
                    //line.Vector.X--;
                    line2.Vector.X--;
                }*/
            }
            //line.Print();
            //line2.Print();
            stopped = true;
        }
    }
}
