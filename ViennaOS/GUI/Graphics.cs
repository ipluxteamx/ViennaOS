using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;

namespace ViennaOS.GUI
{
    public class Graphics
    {
        public void Run()
        {
            try
            {
                Pen pen = new Pen(Color.Red);
                canvas.DrawPoint(pen, 69, 69);

                
                pen.Color = Color.GreenYellow;
                canvas.DrawLine(pen, 250, 100, 400, 100);

                
                pen.Color = Color.IndianRed;
                canvas.DrawLine(pen, 350, 150, 350, 250);

                
                pen.Color = Color.MintCream;
                canvas.DrawLine(pen, 250, 150, 400, 250);

                
                pen.Color = Color.PaleVioletRed;
                canvas.DrawRectangle(pen, 350, 350, 80, 60);

                Console.ReadKey();

                
                canvas.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);

                
                pen.Color = Color.LimeGreen;
                canvas.DrawRectangle(pen, 450, 450, 80, 60);

                Stop();
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                mDebugger.Send(e.Message);
                Stop();
            }
        }
    }
}
