using System;
using System.IO;
using static System.Console;
namespace dtp5_contacts_0
{
    class MainClass
    {
        static Person[] contactList = new Person[100];
        public class Person
        {
            public string persname, surname, phone, address, birthdate;
        }
        public static Person[] Load(string input, string lastFileName)
        {
            if (input.Length < 2)
            {
                string[] commandLine;
                if (input.StartsWith("load ")) { commandLine = new string[] { "load", input.Substring(5) }; lastFileName = commandLine[1]; }

                using (StreamReader infile = new StreamReader(lastFileName))
                {
                    string line;
                    while ((line = infile.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] attrs = line.Split('|');
                        Person p = new Person();
                        p.persname = attrs[0];
                        p.surname = attrs[1];
                        string[] phones = attrs[2].Split(';');
                        p.phone = phones[0];
                        string[] addresses = attrs[3].Split(';');
                        p.address = addresses[0];
                        for (int ix = 0; ix < contactList.Length; ix++)
                        {
                            if (contactList[ix] == null)
                            {
                                contactList[ix] = p;
                                break;
                            }
                        }
                    }
                }
            }
            return contactList;
        }
        public static void Main(string[] args)
        {
            string lastFileName = "address.lis";
            string input;
            WriteLine("Hello and welcome to the contact list");
            WriteLine("Avaliable commands: ");
            WriteLine("  load        - load contact list data from the file address.lis");
            WriteLine("  load /file/ - load contact list data from the file");
            WriteLine("  new        - create new person");
            WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
            WriteLine("  quit        - quit the program");
            WriteLine("  save         - save contact list data to the file previously loaded");
            WriteLine("  save /file/ - save contact list data to the file");
            WriteLine();
            do // Switch below
            {
                Console.Write($"> ");
                input = ReadLine();
                if (input.StartsWith("load ")) { string[] commandLine = new string[] { "load", input.Substring(5) }; }
                switch (input)
                {
                    case "quit":
                        {
                            // NYI!
                            Console.WriteLine("Not yet implemented: safe quit");
                        }
                        break;
                    case "load":
                        Load(input, lastFileName);
                        break;
                    case "save":
                        if (input.Length < 2)
                        {
                            using (StreamWriter outfile = new StreamWriter(lastFileName))
                            {
                                foreach (Person p in contactList)
                                {
                                    if (p != null)
                                        outfile.WriteLine($"{p.persname};{p.surname};{p.phone};{p.address};{p.birthdate}");
                                }
                            }
                        }
                        else
                        {
                            // NYI!
                            Console.WriteLine("Not yet implemented: save /file/");
                        }
                        break;
                    case "new":
                        if (input.Length < 2)
                        {
                            Console.Write("personal name: ");
                            string persname = Console.ReadLine();
                            Console.Write("surname: ");
                            string surname = Console.ReadLine();
                            Console.Write("phone: ");
                            string phone = Console.ReadLine();
                        }
                        else
                        {
                            // NYI!
                            Console.WriteLine("Not yet implemented: new /person/");
                        }
                        break;
                    case "help":
                        Console.WriteLine("Avaliable commands: ");
                        Console.WriteLine("  delete       - emtpy the contact list");
                        Console.WriteLine("  delete /persname/ /surname/ - delete a person");
                        Console.WriteLine("  load        - load contact list data from the file address.lis");
                        Console.WriteLine("  load /file/ - load contact list data from the file");
                        Console.WriteLine("  new        - create new person");
                        Console.WriteLine("  new /persname/ /surname/ - create new person with personal name and surname");
                        Console.WriteLine("  quit        - quit the program");
                        Console.WriteLine("  save         - save contact list data to the file previously loaded");
                        Console.WriteLine("  save /file/ - save contact list data to the file");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine($"Unknown command: '{input}'");
                        break;
                }
            } while (input != "quit"); //C.6
        }
    }
}
