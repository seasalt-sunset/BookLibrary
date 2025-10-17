using LibraryApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.IO
{
    public static class InputOutput
    {
        public static void ChooseFormat(LibraryAppDbContext context, ReadOrWrite select)
        {
            Format choiceAuthors = Format.NotSupported;
            Format choiceBooks = Format.NotSupported;
            do
            {

                string pathAuthors = "";
                string pathBooks = "";

                if (select == ReadOrWrite.Write)
                {
                    Console.WriteLine("You can choose one of the following extensions:" +
                                "\n.csv" +
                                "\n.json" +
                                "\n.xml");
                    Console.WriteLine("Write the full path where you want to save the Authors (including file name and extention):");
                    pathAuthors = Console.ReadLine();
                    Console.WriteLine("Write the full path where you want to save the Books (including file name and extention):");
                    pathBooks = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("You can choose one of the following extensions:" +
                                "\n.csv" +
                                "\n.json" +
                                "\n.xml");
                    do
                    {
                        Console.WriteLine("Write the full path of the file you want to read Authors from (including file name and extention):");
                        pathAuthors = Console.ReadLine();
                        if (!File.Exists(pathAuthors)) Console.WriteLine("\nThe file does not exist.\n");
                    } while (!File.Exists(pathAuthors));

                    do
                    {
                        Console.WriteLine("Write the full path where you want to read the Books from (including file name and extention):");
                        pathBooks = Console.ReadLine();
                        if (!File.Exists(pathBooks)) Console.WriteLine("\nThe file does not exist.\n");
                    } while (!File.Exists(pathBooks));
                }


                choiceAuthors = pathAuthors.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ? Format.Csv :
                                pathAuthors.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ? Format.Json :
                                pathAuthors.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ? Format.Xml : Format.NotSupported;

                choiceBooks = pathBooks.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ? Format.Csv :
                                pathBooks.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ? Format.Json :
                                pathBooks.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ? Format.Xml : Format.NotSupported;


                if (select == ReadOrWrite.Write)
                {
                    if(choiceAuthors == Format.NotSupported || choiceBooks == Format.NotSupported)
                    {
                        Console.WriteLine("Format not supported.");
                        continue;
                    }

                    switch (choiceAuthors)
                    {
                        case Format.Csv:
                            WriteToFile.WriteToCsvAuthors(context, pathAuthors);
                            break;
                        case Format.Json:
                            WriteToFile.WriteToJsonAuthors(context, pathAuthors);
                            break;
                        case Format.Xml:
                            WriteToFile.WriteToXmlAuthors(context, pathAuthors);
                            break;
                    }

                    switch (choiceBooks)
                    {
                        case Format.Csv:
                            WriteToFile.WriteToCsvBooks(context, pathBooks);
                            break;
                        case Format.Json:
                            WriteToFile.WriteToJsonBooks(context, pathBooks);
                            break;
                        case Format.Xml:
                            WriteToFile.WriteToXmlBooks(context, pathBooks);
                            break;
                    }
                }
                else
                {
                    switch (choiceAuthors)
                    {
                        case Format.Csv:
                            ReadFromFile.ReadFromCsvAuthors(context, pathAuthors);
                            break;
                        case Format.Json:
                            ReadFromFile.ReadFromJsonAuthors(context, pathAuthors);
                            break;
                        case Format.Xml:
                            ReadFromFile.ReadFromXmlAuthors(context, pathAuthors);
                            break;
                    }

                    switch (choiceBooks)
                    {
                        case Format.Csv:
                            ReadFromFile.ReadFromCsvBooks(context, pathBooks);
                            break;
                        case Format.Json:
                            ReadFromFile.ReadFromJsonBooks(context, pathBooks);
                            break;
                        case Format.Xml:
                            ReadFromFile.ReadFromXmlBooks(context, pathBooks);
                            break;
                    }
                }
            } while (choiceAuthors == Format.NotSupported || choiceBooks == Format.NotSupported);
        }
    }
}
