using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using ViennaOS.Commands;
using Cosmos.System.FileSystem;

namespace ViennaOS {
    public class Kernel : Sys.Kernel {
        public static string current_directory = @"0:\";
        private CommandManager commandManager;
        private CosmosVFS viennaFS;

        protected override void BeforeRun() {
            this.viennaFS = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.viennaFS);
            this.commandManager = new CommandManager();

            Console.Clear();
            Console.WriteLine("ViennaOS beta 1 M1 \nTeamX 2021\n\n");
            Sys.Kernel.PrintDebug("[OK] ViennaOS has started correctly.");
        }

        protected override void Run() {
            Console.Write(current_directory);
            String response;
            String input = Console.ReadLine();
            response = this.commandManager.processInput(input);
            Console.WriteLine(response);
        }
    }
}
