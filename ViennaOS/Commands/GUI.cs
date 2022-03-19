using System;
using System.Collections.Generic;
using System.Text;
using SysG = Cosmos.System.Graphics;
using GUI = ViennaOS.GUI;
using Canvas = Cosmos.System.Graphics.Canvas;

namespace ViennaOS.Commands
{
    public class GUI : Command
    {
        public GUI(String name) : base(name)
        {

        }
        public override String execute(String[] args)
        {
            GUI.Initialize();
        }
    }
}
