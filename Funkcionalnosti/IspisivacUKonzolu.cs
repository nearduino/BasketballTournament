using BasketballTournament.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Funkcionalnosti
{
    public class IspisivacUKonzolu
    {
        public void IspisiKolo(string kolo)
        {
            switch (kolo)
            {
                case "Kolo1":
                    Console.WriteLine("Grupna faza - I kolo:");
                    break;
                case "Kolo2":
                    Console.WriteLine("Grupna faza - II kolo:");
                    break;
                case "Kolo3":
                    Console.WriteLine("Grupna faza - III kolo:");
                    break;
            }
            
            for (int i = 0; i < Kolekcije.mecevi[kolo].Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine("\tGrupa A:");
                        break;
                    case 2:
                        Console.WriteLine("\tGrupa B:");
                        break;
                    case 4:
                        Console.WriteLine("\tGrupa C:");
                        break;
                }
                Console.WriteLine($"\t\t{Kolekcije.mecevi[kolo][i].Tim_1} - {Kolekcije.mecevi[kolo][i].Tim_2} ({Kolekcije.mecevi[kolo][i].Rezultat})");
            }
        }
    }
}
