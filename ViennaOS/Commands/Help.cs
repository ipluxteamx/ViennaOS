using System;
using System.Collections.Generic;
using System.Text;

namespace ViennaOS.Commands
{
    public class Help:Command
    {
        public Help(String name) : base(name)
        {

        }
        public override String execute(String[] args)
        {
            return "ViennaOS beta 1 M1 Help command.\n\nHelp shows all the commands and their function." + "RS repeats a string.\n" + "CLR clears the screen.\n" + "F\n";
        }
    }
}
