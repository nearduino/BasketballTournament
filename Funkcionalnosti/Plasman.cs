using BasketballTournament.Entiteti;
using BasketballTournament.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Funkcionalnosti
{
    public class Plasman
    {
        public Plasman()
        {
            foreach (var t in Kolekcije.timovi)
            {
                Kolekcije.plasmanPoTimu.Add(t.Key, new PlasmanUGrupi()
                {
                    Team = t.Key
                });
            }
        }

        public void OsveziPlasman(PraviMec mec)
        {
            Kolekcije.plasmanPoTimu[mec.Tim_1].PostignutiKosevi += mec.Tim_1_kosevi;
            Kolekcije.plasmanPoTimu[mec.Tim_2].PostignutiKosevi += mec.Tim_2_kosevi;

            Kolekcije.plasmanPoTimu[mec.Tim_1].PrimljeniKosevi += mec.Tim_2_kosevi;
            Kolekcije.plasmanPoTimu[mec.Tim_2].PrimljeniKosevi += mec.Tim_1_kosevi;

            Kolekcije.plasmanPoTimu[mec.Tim_1].KosRazlika += mec.Tim_1_kosevi - mec.Tim_2_kosevi;
            Kolekcije.plasmanPoTimu[mec.Tim_2].KosRazlika += mec.Tim_2_kosevi - mec.Tim_1_kosevi;

            if (mec.Tim_1_kosevi > mec.Tim_2_kosevi)
            {
                Kolekcije.plasmanPoTimu[mec.Tim_1].Bodovi += 2;
                Kolekcije.plasmanPoTimu[mec.Tim_2].Bodovi += 1;

                Kolekcije.plasmanPoTimu[mec.Tim_1].Pobede += 1;
                Kolekcije.plasmanPoTimu[mec.Tim_2].Porazi += 1;
            }
            else if (mec.Tim_1_kosevi < mec.Tim_2_kosevi)
            {
                Kolekcije.plasmanPoTimu[mec.Tim_1].Bodovi += 1;
                Kolekcije.plasmanPoTimu[mec.Tim_2].Bodovi += 2;

                Kolekcije.plasmanPoTimu[mec.Tim_1].Porazi += 1;
                Kolekcije.plasmanPoTimu[mec.Tim_2].Pobede += 1;
            }
        }

        public void OdrediPlasman()
        {
            foreach (var g in Kolekcije.grupe)
            {
                List<PlasmanUGrupi> plasman = new();

                foreach (var mec in g.Value)
                {
                    plasman.Add(Kolekcije.plasmanPoTimu[mec.ISOCode]);
                }

                List<PlasmanUGrupi> sortiraniPlasman = plasman.OrderByDescending(b => b.Bodovi).ToList();

                for (int i = 0; i < sortiraniPlasman.Count - 1; i++)
                {
                    if (sortiraniPlasman[i].Bodovi == sortiraniPlasman[i + 1].Bodovi)
                    {
                        if (Kolekcije.timovi[sortiraniPlasman[i].Team].MedjusobniSusreti[sortiraniPlasman[i + 1].Team] < 0)
                        {
                            sortiraniPlasman = ZameniPlasmane(sortiraniPlasman, i, i + 1);
                        }
                    }
                }

                for (int i = 0; i < sortiraniPlasman.Count - 2;  i++)
                {
                    if (sortiraniPlasman[i].Bodovi == sortiraniPlasman[i + 2].Bodovi)
                    {
                        int[] razlike = new int[3]; 
                        for (int j = 0; j < 3; j++)
                        {
                            razlike[j] = Kolekcije.timovi[sortiraniPlasman[i + j].Team].MedjusobniSusreti[sortiraniPlasman[i + j + 1].Team] +
                            Kolekcije.timovi[sortiraniPlasman[i + j].Team].MedjusobniSusreti[sortiraniPlasman[i + j + 2].Team];
                        }
                        for (int j = 0;j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (razlike[k] < razlike[k + 1])
                                {
                                    sortiraniPlasman = ZameniPlasmane(sortiraniPlasman, i + k, i + k + 1);
                                }
                            }
                        }
                        
                    }
                }
                Kolekcije.grupniPlasmani.Add(g.Key, sortiraniPlasman);
            }
        }

        public List<PlasmanUGrupi> ZameniPlasmane(List<PlasmanUGrupi> plasmani, int gornji, int donji)
        {
            PlasmanUGrupi temp = plasmani[gornji];
            plasmani[gornji] = plasmani[donji];
            plasmani[donji] = temp;
            return plasmani;
        }
    }
}
