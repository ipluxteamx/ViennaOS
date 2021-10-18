using System;
using System.Collections.Generic;
using System.Text;

namespace ViennaOS.Commands
{
    public class CommandManager
    {
        private List<Command> commands;
        public CommandManager()
        {
            this.commands = new List<Command>(1);
            this.commands.Add(new Help("help"));
            this.commands.Add(new RS("rs"));
            this.commands.Add(new CLR("clr"));
            this.commands.Add(new File("f"));
        }

        public String processInput(String input)
        {
            String[] split = input.Split(" ");
            String label = split[0];
            List<String> args = new List<String>();

            int ctr = 0;

            foreach (String s in split)
            {
                if (ctr != 0)
                {
                    args.Add(s);
                }

                ++ctr;
            }

            foreach (Command cmd in this.commands)
            {
                if (cmd.name == label)
                {
                    return cmd.execute(args.ToArray());
                }
            }

            return "The command: \"" + label + "\" does not exist.";
        }
    }
}
