using System;
using System.Linq;
using System.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem.Listing;
using System.Reflection.Metadata.Ecma335;
using Simple_Os.Apps;

namespace Simple_Os
{
    public class CLI
    {
        public string currentDir = @"0:\";


        public void Run()
        {
            Console.WriteLine("Welcome to BeginnerCLI");


            while (true)
            {
                Console.Write($"{currentDir}> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input == "exit")
                {
                    Console.Clear();
                    return;
                }

                else if (input.StartsWith("cd"))
                {
                    if (input.Length == 2 || string.IsNullOrWhiteSpace(input.Substring(2).Trim()))
                    {
                        Console.WriteLine("Usage: cd <path>");
                        continue;
                    }

                    else if (input == "cd ..")
                    {
                        if (currentDir == @"0:\")
                        {
                            Console.WriteLine("Already at root directory.");
                            continue;
                        }
                        else
                        {
                            int LastSlash = currentDir.LastIndexOf('\\');
                            if (LastSlash == 2)
                            {
                                currentDir = currentDir.Substring(0, 3);
                                continue;
                            }
                            else if (LastSlash > 2)
                            {
                                currentDir = currentDir.Substring(0, LastSlash);
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Already at root directory.");
                                continue;
                            }
                        }
                    }

                    string path = input.Substring(3).Trim();

                    try
                    {
                        var dir = VFSManager.GetDirectoryListing(path);
                        currentDir = path;
                        Console.WriteLine("Changed directory to " + currentDir);
                    }
                    catch
                    {
                        try
                        {
                            bool dirFound = false;
                            var entries = VFSManager.GetDirectoryListing(currentDir);
                            foreach (var entry in entries)
                            {
                                if (entry.mEntryType == DirectoryEntryTypeEnum.Directory)
                                {

                                    string localDir = entry.mName;
                                    if (path == localDir)
                                    {
                                        currentDir = currentDir + localDir + "\\";
                                        Console.WriteLine("Changed directory to " + currentDir);
                                        dirFound = true;
                                        break;
                                    }
                                }
                            }
                            if (!dirFound)
                            {
                                Console.WriteLine("Directory not found.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error changing directory.");
                        }
                    }
                }


                else if (input == "list" || input == "dir" || input == "ls")
                {
                    try
                    {
                        var entries = VFSManager.GetDirectoryListing(currentDir);
                        foreach (var entry in entries)
                        {
                            if (entry.mEntryType == DirectoryEntryTypeEnum.Directory)
                                Console.WriteLine("<DIR> " + entry.mName);
                            else
                                Console.WriteLine(entry.mName);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error listing directory.");
                    }
                }
                else if (input.StartsWith("echo"))
                {
                    string[] echoArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (echoArray.Length < 2)
                    {
                        Console.WriteLine("When Using echp put the thing you want to change to after cd eg: cd 0:\\yourdirectory");
                    }
                    else if (!string.IsNullOrEmpty(echoArray[1]))
                    {
                        string message = input.Substring(5);
                        Console.WriteLine(message);
                    }

                }
                else if (input == "help")
                {
                    Console.WriteLine("Commands: cd, list, echo, exit, help");
                }


                else if (input == "clear" || input == "cls")
                {
                    Console.Clear();
                }

                else if (input.StartsWith("readfile"))
                {
                    string fileToRead = input.Substring(9).Trim();
                    string fileToReadExt = Path.GetExtension(fileToRead).ToLower();
                    if (string.IsNullOrEmpty(fileToRead) || (fileToReadExt != ".txt" && fileToReadExt != ".csv"))
                    {
                        Console.WriteLine("Usage: readfile <filename> Only txt and csv");
                        continue;
                    }
                    else
                    {
                        try
                        {
                            string fullFilePath = currentDir + fileToRead;
                            string fileContent = File.ReadAllText(fullFilePath);
                            Console.WriteLine(fileContent);
                        }
                        catch
                        {
                            Console.WriteLine("Error reading file. Make sure the file exists.");
                        }
                    }
                }

                else if (input.StartsWith("createfile"))
                {
                    if (input.Length <= 11)
                    {
                        input = input + " ";
                    }
                    string fileName = input.Substring(11).Trim();
                    string fileExt = Path.GetExtension(currentDir + fileName).ToLower();

                    if (string.IsNullOrWhiteSpace(fileName) || (fileExt != ".txt" && fileExt != ".csv"))
                    {
                        Console.WriteLine("Usage: createfile <filename> Only txt and csv");
                        continue;
                    }
                    else
                    {
                        try
                        {
                            string fullFilePath = currentDir + fileName;
                            if (File.Exists(fullFilePath))
                            {
                                Console.WriteLine("File already exists.");
                                Console.WriteLine("Overwrite y/n?");
                                input = Console.ReadLine();
                                if (input.ToLower() == "y")
                                {
                                    Console.WriteLine("Enter new content for the file. Only One Line (Press Enter/Return to Finish):");
                                    string filecontent = Console.ReadLine();
                                    File.WriteAllText(fullFilePath, filecontent);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter content for the file. Only One Line (Press Enter/Return to Finish):");
                                string filecontent = Console.ReadLine();
                                File.WriteAllText(fullFilePath, filecontent);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error creating file: " + ex.Message);
                        }
                    }
                }

                else if (input.StartsWith("mkdir") || input.StartsWith("makedir"))
                {
                    if (input.StartsWith("makedir"))
                    {
                        input = input.Substring(7).Trim();
                    }
                    else
                    {
                        input = input.Substring(5).Trim();
                    }
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Usage: mkdir <directory_name>");
                        continue;
                    }
                    if (input.Any(char.IsDigit) || input.Contains("."))
                    {
                        Console.WriteLine(@"Directory name cannot contain numbers or '.' and \ will create a subfoler");
                        continue;
                    }
                    try
                    {
                        Directory.CreateDirectory(currentDir + input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }

                else if (input.StartsWith("deldir") || input.StartsWith("rmdir"))
                {
                    if (input.StartsWith("rmdir"))
                    {
                        input = input.Substring(5).Trim();
                    }
                    else
                    {
                        input = input.Substring(6).Trim();
                    }
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Usage: deldir <directory_name>");
                        continue;
                    }
                    try
                    {
                        Directory.Delete(currentDir + input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

                else if (input.StartsWith("delfile") || input.StartsWith("rmfile"))
                {
                    if (input.StartsWith("rmfile"))
                    {
                        input = input.Substring(6).Trim();
                    }
                    else
                    {
                        input = input.Substring(7).Trim();
                    }
                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Usage: delfile <filename>");
                        continue;
                    }
                    try
                    {
                        File.Delete(currentDir + input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else if (input.StartsWith("run"))
                {
                    string programName = input.Substring(3).Trim();
                    programName = programName.ToLower();
                    if (string.IsNullOrEmpty(programName))
                    {
                        Console.WriteLine("Usage: run <program_name>");
                        continue;
                    }
                    else
                    {
                        if (programName == "texteditor" || programName == "textedit" || programName == "te")
                        {
                            var textEditor = new Apps.textEdit();
                            textEditor.Run();
                        }
                        else if (programName == "calculator" || programName == "calc" || programName == "calculatorapp")
                        {
                            var calculator = new Apps.calculator();
                            calculator.Run();
                        }
                        else if (programName == "settings" || programName == "set")
                        {
                            var settingsApp = new Apps.settings();
                            settingsApp.Run();
                        }
                        else
                        {
                            Console.WriteLine("Program not found.");
                            continue;
                        }
                    }
                }
                else if ("pwd" == input)
                {
                    Console.WriteLine(currentDir);
                }

                else if (input == "time")
                {
                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                }

                else if (input == "date")
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
                }

                else if (input == "te" || input == "textedit" || input == "textEdit")
                {
                    var textEdit = new Apps.textEdit();
                    textEdit.Run();    
                }

                else if (input == "calc" || input == "calculator")
                {
                    var calculator = new Apps.calculator();
                    calculator.Run();
                }

                else
                {
                    Console.WriteLine("Unknown command.");
                }
            }
        }
    }
}