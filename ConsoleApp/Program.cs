using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ConsoleApp6lotto2
{
    internal class Program
    {
        static void Main(string[] args)
        {


            List<string> szoveg = new List<string>();
            //beolvasás
            //itt most éppen relatív útvonalat adtam meg, fontos hogy legyen a file a debug mappában
            StreamReader sr = new StreamReader("sorsolas.txt");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            //Beolvasás másképp:
            List<Sorsolas> sorsolasok = new List<Sorsolas>();
            List<Szam> szamok = new List<Szam>();

            string[] lines = File.ReadAllLines("sorsolas.txt");
            foreach (var item in lines)
            {
                string[] values = item.Split(';');
                Sorsolas sorsolasok_object = new Sorsolas(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[2]));
                sorsolasok.Add(sorsolasok_object);
            }

            foreach (var item in sorsolasok)
            {
                Console.WriteLine($"{item.het} {item.szam1}  {item.szam2} {item.szam3} {item.szam4} {item.szam5}");
            }

            Console.WriteLine("Enter a number:");
            string numberinput = Console.ReadLine();
            int inputToNumber = Convert.ToInt32(numberinput);
            Console.WriteLine(inputToNumber);

            foreach (var item in sorsolasok)

            {
                if (inputToNumber == item.het)
                {
                    Console.WriteLine($"Feladat1: {item.het}. hét: {item.szam1}, {item.szam2}, {item.szam3}, {item.szam4}, {item.szam5}");
                }

            }
            int db = 0;
            for (int i = 1; i < 91; i++)
            {
                foreach (var item in sorsolasok)
                {
                    if (i == item.szam1 ||i == item.szam2 ||i == item.szam3 || i == item.szam4 || i == item.szam5)
                    {
                        db++;
                    }
                }
                Szam szam_object = new Szam(i, db);
                szamok.Add(szam_object);
                db=0;
            }
            int max_db = 999;
            int max_szam = 999;
            foreach (var item in szamok)
            {
                if (item.db < max_db)
                {
                    max_db =item.db;
                    max_szam = item.szam;
                }
            }
            Console.WriteLine($"legkevesebbszer kihúzva: {max_szam},ennyi alkalommal:{max_db}");
            foreach (var item in szamok)
            {
                if (item.szam %2 == 0)
                {
                    db++;
                }

            }
            Console.WriteLine($"páros: {db}db");

            foreach (var item in szamok)
            {
                if (item.szam ==5)
                {
                    Console.WriteLine($"5: {item.db}db");
                }
            }
            foreach (var item in szamok)
            {
                if (item.szam ==46)
                {
                    Console.WriteLine($"46: {item.db}db");
                }
            }
            foreach (var item in szamok)
            {
                Console.WriteLine($"db:{item.db}, szam:{item.szam}");
            }


        }

    }
}

