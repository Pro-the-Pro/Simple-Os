using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Simple_Os.Apps
{
    public class calculator
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("___Simple Calculator___");
            decimal num1 = 0, num2 = 0, result = 0;
            string operation = "";
            bool running = true;
            while (running)
            {
                string input = "";
                bool calcValid = false;
                decimal[] nums = null;
                while (!calcValid)
                {
                    Console.WriteLine("Enter your Calculation");
                    input = Console.ReadLine() ?? "";
                    if (input.Trim() == "exit")
                    {
                        Console.WriteLine("Exiting Calculator");
                        running = false;
                        break;
                    }
                    if (input.Trim() == "clear")
                    {
                        Console.Clear();
                    }
                    try
                    {
                        nums = Array.ConvertAll(input.Split(new char[] { '+', '-', '/', '*' }, StringSplitOptions.RemoveEmptyEntries), decimal.Parse);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Calculation Entered");
                    }
                    if (nums.Length != 2)
                    {
                        Console.WriteLine("Calculation either has too many or too little Operations");
                    }
                    else
                    {
                        num1 = nums[0];
                        num2 = nums[1];
                        calcValid = true;
                    }
                    if (input.Contains("+")){operation = "+";}
                    else if (input.Contains("-")) { operation = "-"; }
                    else if (input.Contains("*")) { operation = "*"; }
                    else if (input.Contains("/")) { operation = "/"; }
                    switch (operation)
                    {
                        case "+":
                            result = num1 + num2;
                            Console.WriteLine(result);
                            break;
                        case "-":
                            result = num1 - num2;
                            Console.WriteLine(result);
                            break;
                        case "/":
                            try
                            {
                                result = num1 / num2;

                            }
                            catch
                            {
                                Console.WriteLine("Error Dividing Number");
                            }
                            Console.WriteLine(result);
                            break;
                        case "*":
                            result = num1 * num2;
                            Console.WriteLine(result);
                            break;
                    }
                }
            }
        }
    }
}
