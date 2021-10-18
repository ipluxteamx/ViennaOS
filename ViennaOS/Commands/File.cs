using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace ViennaOS.Commands
{
    public class File : Command
    {
        public File (String name) : base (name) { }

        public override string execute(String[] args)
        {
            //file mkf MyFile.txt
            //file mkd MyFolder

            string response = "";

            switch (args[0])
            {
                case "mkf":

                    try {
                        Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
                        response = "The file \"" + args[1] + "\" was sucessfully created.";
                    }
                    catch (Exception ex) {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rmf":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
                        response = "The file \"" + args[1] + "\" was sucessfully deleted.";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "mkd":

                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
                        response = "Succesfully created \"" + args[1] + "\" directory.";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rmd":
                    try
                    {
                        Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1], true);
                        response = "Sucessfully deleted \"" + args[1] + "\" directory.";
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "wrstr":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanWrite)
                        {
                            int ctr = 0;
                            StringBuilder sb = new StringBuilder();

                            foreach (String s in args)
                            {
                                if (ctr > 1)
                                    sb.Append(s + ' ');

                                ++ctr;
                            }

                            String txt = sb.ToString();
                            Byte[] data = Encoding.ASCII.GetBytes(txt.Substring(0, txt.Length - 1));

                            fs.Write(data, 0, data.Length);
                            fs.Close();
                            response = "Successfully written \"" + args[2] + "\" to file \"" + args[1] + "\".\n";
                        } 
                        else
                        {
                            response = "Unable to write to file. Not open for writing.";
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "rdstr":
                    try
                    {
                        FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

                        if (fs.CanRead)
                        {
                            Byte[] data = new Byte[256];

                            fs.Read(data, 0, data.Length);
                            response = Encoding.ASCII.GetString(data);
                        }
                        else
                        {
                            response = "Unable to read from file. Not open for reading.";
                            break;
                        }
                    }
                    
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "ls":

                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(Kernel.currentDirectory);

                    try
                    {
                        Console.WriteLine("\n");

                        foreach (var directoryEntry in directory_list)
                        {
                            Console.WriteLine(directoryEntry.mName);
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                case "cd":
                    try
                    {
                        if (Sys.FileSystem.VFS.VFSManager.DirectoryExists(args[1])) {
                            Kernel.currentDirectory = args[1];
                            Console.WriteLine("\nSuccessfully changed to \"" + Kernel.currentDirectory + args[1] + "\".\n");
                        } 
                        else
                        {
                            Console.WriteLine(args[1] + " does not exist.\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        response = ex.ToString();
                        break;
                    }

                    break;

                default:
                    Console.WriteLine("This argument is not valid, please try again with an valid argument.\n" + "(Not like Twitter)\n");

                    break;


            }

            return response;
        }
    }
}
