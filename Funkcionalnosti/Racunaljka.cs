using BasketballTournament.Entiteti;
using BasketballTournament.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Funkcionalnosti
{
    public class Racunaljka
    {
        public void IzracunajPocetnuFormu()
        {
            foreach (var e in Kolekcije.egzibicije)
            {
                for (int i = 0; i < 2; i++)
                {
                    var poeni = e.Value[i].Result.Split("-");
                    int poeni_1 = int.Parse(poeni[0]);
                    int poeni_2 = int.Parse(poeni[1]);

                    if (poeni_1 > poeni_2)
                    {
                        if (poeni_1 - 20 > poeni_2)
                        {
                            Kolekcije.timovi[e.Key].Form += 2;
                        }
                        Kolekcije.timovi[e.Key].Form += 1;
                    }
                    else if (poeni_1 < poeni_2)
                    {
                        if (poeni_1 + 20 < poeni_2)
                        {
                            Kolekcije.timovi[e.Key].Form -= 2;
                        }
                        Kolekcije.timovi[e.Key].Form -= 1;
                    }

                    if (Kolekcije.timovi.ContainsKey(e.Value[i].Opponent))
                    {
                        if (Kolekcije.timovi[e.Key].FIBARanking - Kolekcije.timovi[e.Value[i].Opponent].FIBARanking > 3)
                        {
                            Kolekcije.timovi[e.Key].Form += 1;
                        }
                        else if (Kolekcije.timovi[e.Value[i].Opponent].FIBARanking - Kolekcije.timovi[e.Key].FIBARanking > 3)
                        {
                            Kolekcije.timovi[e.Key].Form -= 1;
                        }
                    }   
                }            
            }
        }

        public void IzracunajFormu(PraviMec mec)
        {
            if (mec.Tim_1_kosevi > mec.Tim_2_kosevi)
            {
                if (mec.Tim_1_kosevi - 20 > mec.Tim_2_kosevi)
                {
                    Kolekcije.timovi[mec.Tim_1].Form += 2;
                    Kolekcije.timovi[mec.Tim_2].Form -= 2;
                }
                Kolekcije.timovi[mec.Tim_1].Form += 1;
                Kolekcije.timovi[mec.Tim_2].Form -= 1;
            }
            else if (mec.Tim_1_kosevi < mec.Tim_2_kosevi)
            {
                if (mec.Tim_1_kosevi + 20 < mec.Tim_2_kosevi)
                {
                    Kolekcije.timovi[mec.Tim_1].Form -= 2;
                    Kolekcije.timovi[mec.Tim_2].Form += 2;
                }
                Kolekcije.timovi[mec.Tim_1].Form -= 1;
                Kolekcije.timovi[mec.Tim_2].Form += 1;
            }

            if (Kolekcije.timovi[mec.Tim_1].FIBARanking - Kolekcije.timovi[mec.Tim_2].FIBARanking > 3)
            {
                Kolekcije.timovi[mec.Tim_1].Form += 1;
                Kolekcije.timovi[mec.Tim_2].Form -= 1;
            }
            else if (Kolekcije.timovi[mec.Tim_2].FIBARanking - Kolekcije.timovi[mec.Tim_1].FIBARanking > 3)
            {
                Kolekcije.timovi[mec.Tim_1].Form -= 1;
                Kolekcije.timovi[mec.Tim_2].Form += 1;
            }
        }

        public void IzracunajRezultat(PraviMec mec)
        {
            Random random = new Random();

            int varijacijaForme = Kolekcije.timovi[mec.Tim_1].Form - Kolekcije.timovi[mec.Tim_2].Form;
            int varijacijaRanga = Kolekcije.timovi[mec.Tim_2].FIBARanking - Kolekcije.timovi[mec.Tim_1].FIBARanking;

            mec.Tim_1_kosevi = random.Next(90, 110) + varijacijaForme + 3 * varijacijaRanga;
            if (mec.Tim_1_kosevi > 150) { mec.Tim_1_kosevi = 150; }
            if (mec.Tim_1_kosevi < 50) { mec.Tim_1_kosevi = 50; }

            mec.Tim_2_kosevi = random.Next(90, 110) - varijacijaForme - 3 * varijacijaRanga;
            if (mec.Tim_2_kosevi > 150) { mec.Tim_2_kosevi = 150; }
            if (mec.Tim_2_kosevi < 50) { mec.Tim_2_kosevi = 50; }

            if (mec.Tim_1_kosevi == mec.Tim_2_kosevi)
            {
                IzracunajRezultat(mec);
            }

            mec.Rezultat = mec.Tim_1_kosevi.ToString() + ":" + mec.Tim_2_kosevi.ToString();
        }
    }
}
