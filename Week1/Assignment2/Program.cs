﻿using System;
using System.Collections.Generic;
using System.IO;

// TODO: Fill in your name and student number.
// Assignment 2a
// NAME: Jianpeng Jiao
// STUDENT NUMBER: 1940153

//Grade: 84/100

namespace Assignment2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Variables and flags

            // The path to the input file to load.
            string inputFile = string.Empty;

            // The path of the output file to save.
            string outputFile = string.Empty;

            // The flag to determine if we overwrite the output file or append to it.
            bool appendToFile = false;

            // The flag to determine if we need to display the number of entries
            bool displayCount = false;

            // The flag to determine if we need to sort the results via name.
            bool sortEnabled = false;

            // The column name to be used to determine which sort comparison function to use.
            string sortColumnName = string.Empty;

            // The results to be output to a file or to the console
            WeaponCollection results = new WeaponCollection();

            for (int i = 0; i < args.Length; i++)
            {
                // h or --help for help to output the instructions on how to use it
                if (args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine("-i <path> or --input <path> : loads the input file path specified (required)");
                    Console.WriteLine("-o <path> or --output <path> : saves result in the output file path specified (optional)");

                    // TODO: include help info for count
                    //"-c or --count : displays the number of entries in the input file (optional).";
                    Console.WriteLine("-c or --count : displays the number of entries in the input file (optional).");
                    // TODO: include help info for append
                    //"-a or --append : enables append mode when writing to an existing output file (optional)";
                    Console.WriteLine("-a or --append : enables append mode when writing to an existing output file (optional)");
                    // TODO: include help info for sort
                    //"-s or --sort <column name> : outputs the results sorted by column name";
                    Console.WriteLine("-s or --sort <column name> : outputs the results sorted by column name");
                    break;
                }
                else if (args[i] == "-i" || args[i] == "--input")
                {
                    // Check to make sure there's a second argument for the file name.
                    if (args.Length > i + 1)
                    {
                        // stores the file name in the next argument to inputFile
                        ++i;
                        inputFile = args[i];

                        if (string.IsNullOrEmpty(inputFile))
                        {
                            Console.WriteLine("no input file specified.");
                            // TODO: print no input file specified.
                        }
                        else if (!File.Exists(inputFile))
                        {
                            // TODO: print the file specified does not exist.
                            Console.WriteLine("the file does not exist.");
                        }
                        else
                        {
                            // This function returns a List<Weapon> once the data is parsed.
                            results.Load(inputFile);
                        }
                    }
                }
                else if (args[i] == "-s" || args[i] == "--sort")
                {
                    if (args.Length > i + 1)//make sure there is next args
                    {
                        sortEnabled = true;
                        sortColumnName = args[i + 1];
                        i++;
                    }
                    // TODO: set the sortEnabled flag and see if the next argument is set for the column name
                    // TODO: set the sortColumnName string used for determining if there's another sort function.
                }
                else if (args[i] == "-c" || args[i] == "--count")
                {
                    displayCount = true;
                }
                else if (args[i] == "-a" || args[i] == "--append")
                {
                    // TODO: set the appendToFile flag
                    appendToFile = true;
                }
                else if (args[i] == "-o" || args[i] == "--output")
                {
                    // validation to make sure we do have an argument after the flag
                    if (args.Length > i + 1)
                    {
                        // increment the index.
                        ++i;
                        string filePath = args[i];
                        if (string.IsNullOrEmpty(filePath))
                        {
                            // TODO: print No output file specified.
                            Console.WriteLine("No output file specified");
                        }
                        else
                        {
                            // TODO: set the output file to the outputFile
                            outputFile = filePath;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument Arg[{0}] = [{1}] is invalid", i, args[i]);
                }
            }

            //ERROR: -3. Why are you not using the SortBy method that you created for weaponCollection?
            //replace all of this by: results.SortBy(columnName
            if (sortEnabled)
            {

                // TODO: add implementation to determine the column name to trigger a different sort. (Hint: column names are the 4 properties of the weapon class)

                // print: Sorting by <column name> e.g. BaseAttack
                Console.WriteLine($@"Sorting by {sortColumnName}");

                // Sorts the list based off of the Weapon name.
                switch (sortColumnName)
                {
                    case "Name":
                        {
                            results.Sort(Weapon.CompareByName);
                            break;
                        }
                    case "Type":
                        {
                            results.Sort(Weapon.CompareByType);
                            break;
                        }
                    case "Rarity":
                        {
                            results.Sort(Weapon.CompareByRarity);
                            break;
                        }
                    case "BaseAttack":
                        {
                            results.Sort(Weapon.CompareByBaseAttack);
                            break;
                        }
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }



            //    if (sortColumnName == "Name")
            //    {
            //        results.Sort(Weapon.CompareByName);
            //    }
            //    else if (sortColumnName == "Type")
            //    {
            //        results.Sort(Weapon.CompareByType);
            //    }
            //    else if (sortColumnName == "Rarity")
            //    {
            //        results.Sort(Weapon.CompareByRarity);
            //    }
            //    else if (sortColumnName == "BaseAttack")
            //    {
            //        results.Sort(Weapon.CompareByBaseAttack);
            //    }
            //    else
            //    {
            //        Console.WriteLine("invalid");
            //    }


            if (displayCount)
            {
                Console.WriteLine("There are {0} entries", results.Count);
            }


            //ERROR: -5. You have a Save function, why you didn't replace here?
            //if(appendToFile){
            //  results.Save(outputfile)
            //}
            if (results.Count > 0)
            {
                if (!string.IsNullOrEmpty(outputFile))
                {
                    FileStream fs;

                    // Check if the append flag is set, and if so, then open the file in append mode; otherwise, create the file to write.
                    if (appendToFile && File.Exists(outputFile))
                    {
                        fs = File.Open(outputFile, FileMode.Append);
                    }
                    else
                    {
                        fs = File.Open(outputFile, FileMode.Create);
                    }

                    // opens a stream writer with the file handle to write to the output file.
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // Hint: use writer.WriteLine
                        // TODO: write the header of the output "Name,Type,Rarity,BaseAttack"
                        writer.WriteLine("Name,Type,Rarity,BaseAttack");
                        // TODO: use the writer to output the results.
                        foreach (var line in results)
                        {
                            writer.WriteLine(line);
                        }
                        // TODO: print out the file has been saved.
                        Console.WriteLine("The file has been saved");
                    }
                }
                else
                {
                    // prints out each entry in the weapon list results.
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                }
            }

            Console.WriteLine("Done!");
        }
    }
}
