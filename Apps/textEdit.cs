using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Transactions;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace Simple_Os.Apps
{
    public class textEdit
    {
        private List<string> content = new List<string>();
        private string filename;
        private string input;
        private string fileDir;

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("___Simple Text Editor___");
            Console.WriteLine("Type your text. Use ::exitSave to save. ::exitNoSave to quit.\n::about for info about textEditor. Or ::backline to del the last line ");
            Console.WriteLine("Info: Nothing to Show");
            bool running = true;

            while (running)
            {
                input = Console.ReadLine() ?? "";

                if (input == "::exitSave")
                {
                    bool isSavedName = false;
                    while (!isSavedName)
                    {
                        Console.Write("Enter filename to save (with .txt extension): ");
                        filename = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(filename) && (filename.EndsWith(".txt") || filename.EndsWith(".csv")))
                        {
                            isSavedName = true;
                        }
                        else
                        {
                            Console.WriteLine("Filename must end with .txt or .csv and cannot be empty.");
                        }

                    }
                    bool isSavedDir = false;
                    while (!isSavedDir)
                    {
                        Console.Write("Enter directory to save (e.g., 0:\\ or 0:\\MyFolder\\): ");
                        fileDir = Console.ReadLine() ?? "";
                        if (!string.IsNullOrWhiteSpace(fileDir))
                        {
                            if (!Directory.Exists(fileDir))
                            {
                                Directory.CreateDirectory(fileDir);
                            }
                            isSavedDir = true;
                        }
                        else
                        {
                            Console.WriteLine("Directory cannot be empty. Please try again.");
                        }

                    }
                    string fullPath = Path.Combine(fileDir, filename);
                    string fileContent = "";
                    foreach (var line in content)
                    {
                        fileContent += line + "\n";
                    }                   
                    File.WriteAllText(fullPath, fileContent);
                    Console.WriteLine($"File saved as {fullPath}");
                    running = false;
                }
                else if (input == "::exitNoSave")
                {
                    Console.WriteLine("Exiting without saving.");
                    running = false;
                }
                else if (input == "::backline")
                {
                    if (content.Count > 0)
                    {
                        content.RemoveAt(content.Count - 1);
                        Console.Clear();
                        Console.WriteLine("___Simple Text Editor___");
                        Console.WriteLine("Type your text. Use ::exitSave to save. ::exitNoSave to quit.\n::about for info about textEditor. Or ::backline to del the last line ");
                        Console.WriteLine("Info: Last line deleted.");
                        foreach (var line in content)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("___Simple Text Editor___");
                        Console.WriteLine("Type your text. Use ::exitSave to save. ::exitNoSave to quit.\n::about for info about textEditor. Or ::backline to del the last line ");
                        Console.WriteLine("Info: No lines to Delete");
                    }
                }

                else if (input == "::about")
                {
                    Console.WriteLine("Simple Text Editor v0.2");
                    Console.WriteLine("Created by Pro the Pro");
                    Console.WriteLine("A basic text editor for Simple OS.");
                }



                else
                {
                    content.Add(input);
                }

            }
        }
    }
}
