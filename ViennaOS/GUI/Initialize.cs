using System;
using System.Collections.Generic;
using System.Text;
using SysG = Cosmos.System.Graphics;
using GUI = ViennaOS.GUI;
using Canvas = Cosmos.System.Graphics.Canvas;

namespace ViennaOS.GUI
{
    public class Main
    {
        public void Initialize()
        {
            Console.WriteLine("Graphic Mode initializing.");

            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.Blue);

            GUI.Graphics();
        }
    }
}
