using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Os.Apps
{
    internal class settings
    {
        public void Run()
        {
            
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("___Settings___");
                Console.WriteLine("1. Change Background Color");
                Console.WriteLine("2. Change Text Color");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Select an option: ");
                var input = Console.ReadKey();
                switch (input.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Select Background Color:");
                        Console.WriteLine("1. Black");
                        Console.WriteLine("2. Blue");
                        Console.WriteLine("3. Green");
                        Console.WriteLine("4. Red");
                        Console.Write("Select an option: ");
                        input = Console.ReadKey();
                        switch (input.KeyChar)
                        {
                            case '1':
                                
                                if (Kernel.fgColour == "black")
                                {
                                    Console.WriteLine("\nCannot Set Backgrougnd Colour as same a Foreground Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();Console.WriteLine("Cannot Set Foreground Colour as same a Background Colour");
                                    break;
                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Kernel.bgColour = "black";
                                break;
                            case '2':
                                if (Kernel.fgColour == "blue")
                                {
                                    Console.WriteLine("\nCannot Set Backgrougnd Colour as same a Foreground Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.bgColour = "blue";
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case '3':
                                if (Kernel.fgColour == "green")
                                {
                                    Console.WriteLine("\nCannot Set Backgrougnd Colour as same a Foreground Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.bgColour = "green";
                                Console.BackgroundColor = ConsoleColor.Green;  
                                break;
                            case '4':
                                if (Kernel.fgColour == "red")
                                {
                                    Console.WriteLine("\nCannot Set Backgrougnd Colour as same a Foreground Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.bgColour = "red";
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option");
                                break;
                        }
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Select Text Color:");
                        Console.WriteLine("1. White");
                        Console.WriteLine("2. Black");
                        Console.WriteLine("3. Cyan");
                        Console.WriteLine("4. Magenta");
                        Console.Write("Select an option: ");
                        input = Console.ReadKey();
                        switch (input.KeyChar)
                        {
                            case '1':
                                if (Kernel.bgColour == "white")
                                {
                                    Console.WriteLine("\nCannot Set Foreground Colour as same a Background Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Kernel.fgColour = "white";
                                break;
                            case '2':
                                if (Kernel.bgColour == "black")
                                {
                                    Console.WriteLine("\nCannot Set Foreground Colour as same a Background Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.fgColour = "black";
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case '3':
                                if (Kernel.bgColour == "cyan")
                                {
                                    Console.WriteLine("\nCannot Set Foreground Colour as same a Background Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.fgColour = "cyan";
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case '4':
                                if (Kernel.bgColour == "magenta")
                                {
                                    Console.WriteLine("\nCannot Set Foreground Colour as same a Background Colour");
                                    Console.WriteLine("Press Any Key To Continue");
                                    Console.ReadKey();
                                    break;
                                }
                                Kernel.fgColour = "magenta";
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            default:
                                Console.WriteLine("Enter a Valid Option");
                                break;
                        }
                        break;

                    case '3':
                        running = false;
                        break;
                       
                    default:
                        Console.WriteLine("Enter a Valid Option");
                        break;
                }
                    
            }
        }
    }
}
