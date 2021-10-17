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
                        response = "The file " + args[1] + " was sucessfully created.";
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
                        response = "The file " + args[1] + " was sucessfully deleted.";
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
                        response = "Succesfully created " + args[1] + " directory.";
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
                        response = "Sucessfully deleted " + args[1] + " directory.";
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
                            Byte[] data = Encoding.ASCII.GetBytes(args[2]);

                            fs.Write(data, 0, data.Length);
                            fs.Close();
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

                default:
                    Console.WriteLine("This argument is not valid, please try again with an valid argument.\n" + "(Not like Twitter)\n");

                    break;


            }

            return response;
        }
    }
}
