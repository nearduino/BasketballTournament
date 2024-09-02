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
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < j; k++)
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

        public void OdrediRang()
        {
            List<PlasmanUGrupi> prvoplasirani = [], drugoplasirani = [], treceplasirani = [];
            foreach (var gp in Kolekcije.grupniPlasmani)
            {
                prvoplasirani.Add(gp.Value[0]);
                drugoplasirani.Add(gp.Value[1]);
                treceplasirani.Add(gp.Value[2]);
            }

            prvoplasirani = prvoplasirani.OrderByDescending(p => p.Bodovi).ThenByDescending(p => p.KosRazlika).ThenByDescending(p => p.PostignutiKosevi).ToList();
            drugoplasirani = drugoplasirani.OrderByDescending(p => p.Bodovi).ThenByDescending(p => p.KosRazlika).ThenByDescending(p => p.PostignutiKosevi).ToList();
            treceplasirani = treceplasirani.OrderByDescending(p => p.Bodovi).ThenByDescending(p => p.KosRazlika).ThenByDescending(p => p.PostignutiKosevi).ToList();

            Kolekcije.plasmaniPoRangu.AddRange(prvoplasirani);
            Kolekcije.plasmaniPoRangu.AddRange(drugoplasirani);
            Kolekcije.plasmaniPoRangu.AddRange(treceplasirani);
            Kolekcije.plasmaniPoRangu.RemoveAt(8);
        }

        public void PopuniSesire()
        {
            List<Tim> sesirD = [], sesirE = [], sesirF = [], sesirG = [];
            
            for (int i = 0; i < 2; i++)
            {
                sesirD.Add(Kolekcije.timovi[Kolekcije.plasmaniPoRangu[i].Team]);
                sesirE.Add(Kolekcije.timovi[Kolekcije.plasmaniPoRangu[i + 2].Team]);
                sesirF.Add(Kolekcije.timovi[Kolekcije.plasmaniPoRangu[i + 4].Team]);
                sesirG.Add(Kolekcije.timovi[Kolekcije.plasmaniPoRangu[i + 6].Team]);
            }

            Kolekcije.sesiri.Add("Sesir D", sesirD);
            Kolekcije.sesiri.Add("Sesir E", sesirE);
            Kolekcije.sesiri.Add("Sesir F", sesirF);
            Kolekcije.sesiri.Add("Sesir G", sesirG);
        }

        public void PopuniCetvrtfinala()
        {
            Tuple<int, int>[] parovi = new Tuple<int, int>[4];
            List<Tim> timoviPoPlasmanu = [];

            foreach(var ppr in Kolekcije.plasmaniPoRangu)
            {
                timoviPoPlasmanu.Add(Kolekcije.timovi[ppr.Team]);
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (timoviPoPlasmanu[i].MedjusobniSusreti.ContainsKey(timoviPoPlasmanu[6 + j].ISOCode))
                    {
                        parovi[0] = Tuple.Create(i, 6 + (j + 1) % 2);
                        parovi[2] = Tuple.Create((i + 1) % 2, 6 + j);
                    }
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (timoviPoPlasmanu[i + 2].MedjusobniSusreti.ContainsKey(timoviPoPlasmanu[4 + j].ISOCode))
                    {
                        parovi[1] = Tuple.Create(i + 2, 4 + (j + 1) % 2);
                        parovi[3] = Tuple.Create((i + 1) % 2 + 2, 4 + j);
                    }
                }
            }

            PraviMec mec_1 = new()
            {
                Tim_1 = timoviPoPlasmanu[parovi[0].Item1].ISOCode,
                Tim_2 = timoviPoPlasmanu[parovi[0].Item2].ISOCode
            };
            Kolekcije.cetvrtfinala.Add(mec_1);

            PraviMec mec_2 = new()
            {
                Tim_1 = timoviPoPlasmanu[parovi[1].Item1].ISOCode,
                Tim_2 = timoviPoPlasmanu[parovi[1].Item2].ISOCode
            };
            Kolekcije.cetvrtfinala.Add(mec_2);

            PraviMec mec_3 = new()
            {
                Tim_1 = timoviPoPlasmanu[parovi[2].Item1].ISOCode,
                Tim_2 = timoviPoPlasmanu[parovi[2].Item2].ISOCode
            };
            Kolekcije.cetvrtfinala.Add(mec_3);

            PraviMec mec_4 = new()
            {
                Tim_1 = timoviPoPlasmanu[parovi[3].Item1].ISOCode,
                Tim_2 = timoviPoPlasmanu[parovi[3].Item2].ISOCode
            };
            Kolekcije.cetvrtfinala.Add(mec_4);
        }
    }
}
