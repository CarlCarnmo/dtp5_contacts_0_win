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
        public static void Load(string lastFileName)
        {
                using (StreamReader infile = new StreamReader(lastFileName))
                {
                    int i = 0;
                    string line = null;
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
                        for (i = 0; i < contactList.Length; i++)
                        {
                            if (contactList[i] == null)
                            {
                                contactList[i] = p;
                                i++;
                                if (i >= contactList.Length)
                                {
                                    Console.WriteLine($"Address file contains more than {contactList.Length} entries, can't load all of them");
                                    break;
                                }
                            }
                        }
                    }
                    for (; i < contactList.Length; i++)
                        contactList[i] = null;
                }
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
                string[] command = input.Split(' ', 2);
                //if (input.StartsWith("load ")) { string[] commandLine = new string[] { "load", input.Substring(5) }; }
                switch (command[0])
                {
                    case "quit":
                        {
                            // NYI!
                            Console.WriteLine("Not yet implemented: safe quit");
                        }
                        break;
                    case "load": // Load -------------------------------------------------
                        if (command.Length > 1)
                            lastFileName = command[1];
                        else
                            lastFileName = "address.lis";
                        Load(lastFileName);
                        //foreach(var p in contactList) { Console.WriteLine(p); }
                        break;
                    case "save": //Save ---------------------------------------------------
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
                        goto case "help";
                }
            } while (input != "quit"); //C.6
        }
    }
}
