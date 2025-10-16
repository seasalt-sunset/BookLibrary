using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.IO
{
    public static class InputOutput
    {
        public static void ChooseFormat(ReadOrWrite select)
        {
            string pathAuthors = "";
            string pathBooks = "" 

            if (select == ReadOrWrite.Write)
            {
                Console.WriteLine("Write the full path where you want to save the Authors (including file name and extention):");
                pathAuthors = Console.ReadLine();
                Console.WriteLine("Write the full path where you want to save the Books (including file name and extention):");
                pathBooks = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Write the full path of the file you want to read Authors from (including file name and extention):");
                pathAuthors = Console.ReadLine();
                Console.WriteLine("Write the full path where you want to read the Books from (including file name and extention):");
                pathBooks = Console.ReadLine();
            }
            Console.WriteLine("You can choose one of the following extensions:" +
                            "\n .csv" +
                            "\n.json" +
                            "\n.xml");

            Format choice = pathAuthors.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ? Format.Csv :
                            pathAuthors.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ? Format.Json :
                            pathAuthors.EndsWith(".xml", StringComparison.OrdinalIgnoreCase) ? Format.Xml : Format.NotSupported;
            if (select == ReadOrWrite.Write)
            {
                switch (choice)
                {
                    case Format.Csv:
                        WriteToFile.WriteToCsv(pathAuthors);
                        break;
                    case Format.Json:
                        WriteToFile.WriteToJson(pathAuthors);
                        break;
                    case Format.Xml:
                        WriteToFile.WriteToXml(pathAuthors);
                        break;
                }
            }
            else
            {
                switch (choice)
                {
                    case Format.Csv:
                        WriteToFile.WriteToCsv(pathAuthors);
                        break;
                    case Format.Json:
                        WriteToFile.WriteToJson(pathAuthors);
                        break;
                    case Format.Xml:
                        WriteToFile.WriteToXml(pathAuthors);
                        break;
                }
            }
        }
    }
}
