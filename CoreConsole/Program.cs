using CoreConsole.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personen = new List<Person>();
            string[] content = File.ReadAllLines(@"D:\TestFolder\personen.csv");
            for (int i = 0; i < content.Length; i++)
            {
                personen.Add(Person.Parse(content[i]));
            }
            bool beenden = false;
            while (!beenden)
            {
                Console.Clear();
                Console.WriteLine("a...Person hinzufügen");
                Console.WriteLine("l...Person auflisten");
                Console.WriteLine("q...Beenden");
                string command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "a":
                        Person newPerson = new Person();
                        Console.Write("Vorname:");
                        newPerson.Vorname = Console.ReadLine();
                        Console.Write("Nachname:");
                        newPerson.Nachname = Console.ReadLine();
                        Console.Write("Alter:");
                        newPerson.Alter = int.Parse(Console.ReadLine());
                        Console.Write("Geschlecht(m/w):");
                        string geschlecht = Console.ReadLine();
                        if (geschlecht == "m")
                        {
                            newPerson.Geschlecht = GeschlechtEnum.Maennlich;
                        }
                        else
                        {
                            newPerson.Geschlecht = GeschlechtEnum.Weiblich;
                        }
                        personen.Add(newPerson);
                        break;
                    case "l":
                        foreach (var item in personen)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "q":
                        beenden = true;
                        break;
                    default:
                        Console.Write("Kein gültiger Befehl. ");
                        break;
                }
                Console.Write("Drücken Sie eine beliebige Taste zum Fortfahren!");
                Console.ReadKey();

            }
            string[] persString = new string[personen.Count];
            for (int i = 0; i < persString.Length; i++)
            {
                persString[i] = personen[i].ToDateiString();
            }
            File.WriteAllLines(@"D:\TestFolder\personen.csv", persString);
        }
    }


}
