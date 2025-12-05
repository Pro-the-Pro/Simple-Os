using System;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace Simple_Os
{
    public class Kernel : Sys.Kernel
    {
        private CosmosVFS fs;
        public static string bgColour;
        public static string fgColour;
        protected override void BeforeRun()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            bgColour = "blue";
            Console.ForegroundColor = ConsoleColor.White;
            fgColour = "white";
            Console.WriteLine("Mounting File System");
            fs = new CosmosVFS();
            VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.WriteLine("Simple OS Initialized");
        }

        protected override void Run()
        {
            Console.Clear();
            Console.WriteLine(@"      _                 _         ____                           ");
            Console.WriteLine(@"     (_)               | |       / __  \        ###              ");
            Console.WriteLine(@"  ___ _ _ __ ___  _ __ | | ___  | |  | |___        ###           ");
            Console.WriteLine(@" / __| | '_ ` _ \| '_ \| |/ _ \ | |  | / __|          ###        ");
            Console.WriteLine(@" \__ \ | | | | | | |_) | |  __/ | |__| \__ \             ###     ");
            Console.WriteLine(@" |___/_|_| |_| |_| .__/|_|\___|  \____/|___/          ###        ");
            Console.WriteLine(@"                 | |                               ###           ");
            Console.WriteLine(@"                 |_|                            ###______________");
            Console.WriteLine("1. Command Line");
            Console.WriteLine("2. Shutdown");
            Console.WriteLine("3. About");
            Console.WriteLine("4. Text Editor");
            Console.WriteLine("5. Calculator");
            Console.WriteLine("6. Settings");
            Console.Write("Select an option: ");

            var optionKey = Console.ReadKey(true);
            char option = optionKey.KeyChar;

            switch (option)
            {
                case '1':
                    Console.Clear();
                    var cli = new CLI();
                    cli.Run();
                    break;

                case '2':
                    Console.WriteLine("Shutting down...");
                    Sys.Power.Shutdown();
                    break;

                case '3':
                    Console.Clear();
                    Console.WriteLine("Simple OS Version 0.01");
                    Console.WriteLine("Developed using Cosmos");
                    Console.WriteLine("Created By Pro the Pro");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                    break;

                case '4':
                    Console.Clear();
                    var textEditor = new Apps.textEdit();
                    textEditor.Run();
                    break;
                case '5':
                    Console.Clear();
                    var calculator = new Apps.calculator();
                    calculator.Run();
                    break;

                case '6':
                    Console.Clear();
                    var settings = new Apps.settings();
                    settings.Run();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();

                    break;
            }
        }
    }
}
