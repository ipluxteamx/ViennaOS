using System;
using System.Collections.Generic;
using System.Text;

namespace ViennaOS.Commands
{
    public class RS : Command
    {
        public RS(String name) : base(name)
        {

        }
        public override String execute(String[] args)
        {
            string response = "";

            if (args[0] == null)
            {
                Console.WriteLine("This argument is not valid, please try again with an valid argument.\n" + "(Not like Twitter)\n");
            } else {
                Console.WriteLine(args[0]);
            }

            return response;
        }
    }
}
