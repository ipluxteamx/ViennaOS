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
                Console.WriteLine("This argument isn't valid, please try again with a word or more.");
            } else {
                Console.WriteLine(args[0]);
            }

            return response;
        }
    }
}
