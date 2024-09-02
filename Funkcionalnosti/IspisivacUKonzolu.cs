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
                string tim_1 = Kolekcije.mecevi[kolo][i].Tim_1;
                string tim_2 = Kolekcije.mecevi[kolo][i].Tim_2;
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
                Console.WriteLine($"\t\t{Kolekcije.timovi[tim_1].Team} - {Kolekcije.timovi[tim_2].Team} ({Kolekcije.mecevi[kolo][i].Rezultat})");
            }
        }

        public void IspisiPlasmanUGrupama()
        {
            Console.WriteLine("\nKonacan plasman u grupama:");
            foreach(var g in Kolekcije.grupniPlasmani)
            {
                switch (g.Key)
                {
                    case "A":
                        Console.WriteLine("\tGrupa A (Ime - pobede/porazi/bodovi/postignuti kosevi/primljeni kosevi/ kos razlika):");
                        break;
                    case "B":
                        Console.WriteLine("\tGrupa B (Ime - pobede/porazi/bodovi/postignuti kosevi/primljeni kosevi/ kos razlika):");
                        break;
                    case "C":
                        Console.WriteLine("\tGrupa C (Ime - pobede/porazi/bodovi/postignuti kosevi/primljeni kosevi/ kos razlika):");
                        break;
                }
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("\t\t" + 
                        $"{i + 1}. " +
                        $"{Kolekcije.timovi[g.Value[i].Team].Team} " +
                        $"\t{g.Value[i].Pobede} " +
                        $"{g.Value[i].Porazi} " +
                        $"{g.Value[i].Bodovi} " +
                        $"{g.Value[i].PostignutiKosevi} " +
                        $"{g.Value[i].PrimljeniKosevi} " +
                        $"{g.Value[i].KosRazlika}"
                    );
                }
            }
        }

        public void IspisiRangove()
        {
            Console.WriteLine("\nTimovi koji su prosli grupnu fazu:");
            for (int i = 0; i < Kolekcije.plasmaniPoRangu.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}." + Kolekcije.timovi[Kolekcije.plasmaniPoRangu[i].Team].Team);
            }
        }

        public void IspisiSesire()
        {
            Console.WriteLine("\nSesiri");
            foreach (var s in Kolekcije.sesiri)
            {
                Console.WriteLine($"\t{s.Key}:");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("\t\t" + s.Value[i].Team);
                }
            }
        }
    }
}
