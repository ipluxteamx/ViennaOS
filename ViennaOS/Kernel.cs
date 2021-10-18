using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using ViennaOS.Commands;
using Cosmos.System.FileSystem;
using SysG = Cosmos.System.Graphics;
using Canvas = Cosmos.System.Graphics.Canvas;

namespace ViennaOS {
    public class Kernel : Sys.Kernel {
        Canvas canvas;

        public static string currentDirectory = @"0:\";
        public static string beforeText = " | ";
        public static string version = "0.2.7";
        public static string Consolemode = "VGATextmode";

        private CommandManager commandManager;
        private CosmosVFS viennaFS;

        protected override void BeforeRun() {
            Console.ForegroundColor = ConsoleColor.Green;

            this.viennaFS = new CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.viennaFS);
            this.commandManager = new CommandManager();

            long available_space = Sys.FileSystem.VFS.VFSManager.GetAvailableFreeSpace("0:/");
            string fs_type = Sys.FileSystem.VFS.VFSManager.GetFileSystemType("0:/");
            var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing("0:/");

            //Set console colors
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Cosmos.HAL.Global.PIT.Wait(7500);
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            //Text
            Console.WriteLine("ViennaOS beta 1 M1 \n (C)TeamX 2021\n\n");
            Console.WriteLine("The current count of volumes are " + this.viennaFS.GetVolumes().Count + " volume(s).");
            Console.WriteLine("Available Free Space: " + available_space + " kb.");
            Console.WriteLine("File System Type: " + fs_type + "\n\n");


            Sys.Kernel.PrintDebug("[OK] ViennaOS has started correctly.");
        }

        protected override void Run() {
            Console.Write(currentDirectory + beforeText);
            String response;
            String input = Console.ReadLine();
            response = this.commandManager.processInput(input);
            Console.WriteLine(response);
        }
    }
}
