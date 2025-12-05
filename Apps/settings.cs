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
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case '2':
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case '3':
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case '4':
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            default:
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
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case '2':
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case '3':
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case '4':
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            default:
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
