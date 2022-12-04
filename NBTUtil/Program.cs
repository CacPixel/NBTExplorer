using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NBTUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0 && args[0] == "--remove-all-tile-entities")
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("You must specify a path.\nUsage: NBTUtil --remove-all-tile-entities <path>");
                    return;
                }

                args[1].Replace("\"", "");
                Console.WriteLine("\nPath: " + args[1] + "\n");
                string path = args[1];
                //string path = "E:\\Documents\\GitHub\\NBTExplorer\\NBTUtil\\bin\\Debug";
                string[] files = Directory.GetFiles(@path, "*.mca", SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    Console.WriteLine(files[i]);
                }
                Console.WriteLine("Press any key to remove all TileEntities in .mca files above...");
                Console.ReadKey(true);
                ConsoleRunner runner = new ConsoleRunner();

                for (int i = 0; i < files.Length; i++)
                {
                    string[] arg = new string[2];
                    arg[0] = "--path=" + files[i] + "/*/Level/TileEntities";
                    Console.WriteLine(arg[0]);
                    arg[1] = "--setlist=\"\"";
                    runner.Run(arg);
                }
                Console.WriteLine("Done.");
                //Console.ReadKey(true);
            }
            else
            {
                ConsoleRunner runner = new ConsoleRunner();
                runner.Run(args);
            }
        }
    }
}
