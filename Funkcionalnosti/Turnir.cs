using BasketballTournament.Entiteti;
using BasketballTournament.Podaci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Funkcionalnosti
{
    public class Turnir
    {
        private Racunaljka racunaljka = new Racunaljka();
        private List<PraviMec> mecevi = new List<PraviMec>();
        private Plasman plasman = new Plasman();

        public void OdigrajKolo(string kolo)
        {
            mecevi = [];

            foreach (var g in Kolekcije.grupe)
            {
                Tim tim_1 = g.Value[0];
                Tim tim_2 = g.Value[1];
                Tim tim_3 = g.Value[2];
                Tim tim_4 = g.Value[3];

                PraviMec praviMec_1 = new();
                PraviMec praviMec_2 = new();

                switch (kolo)
                {
                    case "Kolo1":
                        praviMec_1.Tim_1 = tim_1.ISOCode;
                        praviMec_1.Tim_2 = tim_2.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_1);
                        racunaljka.IzracunajFormu(praviMec_1);
                        plasman.OsveziPlasman(praviMec_1);
                        mecevi.Add(praviMec_1);
                        Kolekcije.timovi[praviMec_1.Tim_1].MedjusobniSusreti.Add(praviMec_1.Tim_2, praviMec_1.Tim_1_kosevi - praviMec_1.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_1.Tim_2].MedjusobniSusreti.Add(praviMec_1.Tim_1, praviMec_1.Tim_2_kosevi - praviMec_1.Tim_1_kosevi);

                        praviMec_2.Tim_1 = tim_3.ISOCode;
                        praviMec_2.Tim_2 = tim_4.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_2);
                        racunaljka.IzracunajFormu(praviMec_2);
                        plasman.OsveziPlasman(praviMec_2);
                        mecevi.Add(praviMec_2);
                        Kolekcije.timovi[praviMec_2.Tim_1].MedjusobniSusreti.Add(praviMec_2.Tim_2, praviMec_2.Tim_1_kosevi - praviMec_2.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_2.Tim_2].MedjusobniSusreti.Add(praviMec_2.Tim_1, praviMec_2.Tim_2_kosevi - praviMec_2.Tim_1_kosevi);
                        break;

                    case "Kolo2":
                        praviMec_1.Tim_1 = tim_1.ISOCode;
                        praviMec_1.Tim_2 = tim_3.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_1);
                        racunaljka.IzracunajFormu(praviMec_1);
                        plasman.OsveziPlasman(praviMec_1);
                        mecevi.Add(praviMec_1);
                        Kolekcije.timovi[praviMec_1.Tim_1].MedjusobniSusreti.Add(praviMec_1.Tim_2, praviMec_1.Tim_1_kosevi - praviMec_1.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_1.Tim_2].MedjusobniSusreti.Add(praviMec_1.Tim_1, praviMec_1.Tim_2_kosevi - praviMec_1.Tim_1_kosevi);

                        praviMec_2.Tim_1 = tim_2.ISOCode;
                        praviMec_2.Tim_2 = tim_4.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_2);
                        racunaljka.IzracunajFormu(praviMec_2);
                        plasman.OsveziPlasman(praviMec_2);
                        mecevi.Add(praviMec_2);
                        Kolekcije.timovi[praviMec_2.Tim_1].MedjusobniSusreti.Add(praviMec_2.Tim_2, praviMec_2.Tim_1_kosevi - praviMec_2.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_2.Tim_2].MedjusobniSusreti.Add(praviMec_2.Tim_1, praviMec_2.Tim_2_kosevi - praviMec_2.Tim_1_kosevi);
                        break;

                    case "Kolo3":
                        praviMec_1.Tim_1 = tim_1.ISOCode;
                        praviMec_1.Tim_2 = tim_4.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_1);
                        racunaljka.IzracunajFormu(praviMec_1);
                        plasman.OsveziPlasman(praviMec_1);
                        mecevi.Add(praviMec_1);
                        Kolekcije.timovi[praviMec_1.Tim_1].MedjusobniSusreti.Add(praviMec_1.Tim_2, praviMec_1.Tim_1_kosevi - praviMec_1.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_1.Tim_2].MedjusobniSusreti.Add(praviMec_1.Tim_1, praviMec_1.Tim_2_kosevi - praviMec_1.Tim_1_kosevi);

                        praviMec_2.Tim_1 = tim_2.ISOCode;
                        praviMec_2.Tim_2 = tim_3.ISOCode;
                        racunaljka.IzracunajRezultat(praviMec_2);
                        racunaljka.IzracunajFormu(praviMec_2);
                        plasman.OsveziPlasman(praviMec_2);
                        mecevi.Add(praviMec_2);
                        Kolekcije.timovi[praviMec_2.Tim_1].MedjusobniSusreti.Add(praviMec_2.Tim_2, praviMec_2.Tim_1_kosevi - praviMec_2.Tim_2_kosevi);
                        Kolekcije.timovi[praviMec_2.Tim_2].MedjusobniSusreti.Add(praviMec_2.Tim_1, praviMec_2.Tim_2_kosevi - praviMec_2.Tim_1_kosevi);
                        break;
                }   
            }
            Kolekcije.mecevi.Add(kolo, mecevi);
        }

        public void OdigrajCetvrtfinala()
        {
            string[] pobednici = new string[4];
            
            for (int i = 0; i < 4; i++)
            {
                racunaljka.IzracunajRezultat(Kolekcije.cetvrtfinala[i]);
                racunaljka.IzracunajFormu(Kolekcije.cetvrtfinala[i]);

                if (Kolekcije.cetvrtfinala[i].Tim_1_kosevi > Kolekcije.cetvrtfinala[i].Tim_2_kosevi)
                {
                    pobednici[i] = Kolekcije.cetvrtfinala[i].Tim_1;
                }
                else if (Kolekcije.cetvrtfinala[i].Tim_1_kosevi < Kolekcije.cetvrtfinala[i].Tim_2_kosevi)
                {
                    pobednici[i] = Kolekcije.cetvrtfinala[i].Tim_2;
                }
                else
                {
                    Random r = new Random();
                    if (r.Next(0, 1) == 0)
                    {
                        pobednici[i] = Kolekcije.cetvrtfinala[i].Tim_1;
                    }
                    else
                    {
                        pobednici[i] = Kolekcije.cetvrtfinala[i].Tim_2;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                PraviMec mec = new PraviMec()
                {
                    Tim_1 = pobednici[i * 2],
                    Tim_2 = pobednici[i * 2 + 1]
                };
                Kolekcije.polufinala.Add(mec);
            }
        }

        public void OdigrajPolufinala()
        {
            string[] pobednici = new string[2];
            string[] gubitnici = new string[2];

            for (int i = 0; i < 2; i++)
            {
                racunaljka.IzracunajRezultat(Kolekcije.polufinala[i]);
                racunaljka.IzracunajFormu(Kolekcije.polufinala[i]);

                if (Kolekcije.polufinala[i].Tim_1_kosevi > Kolekcije.polufinala[i].Tim_2_kosevi)
                {
                    pobednici[i] = Kolekcije.polufinala[i].Tim_1;
                    gubitnici[i] = Kolekcije.polufinala[i].Tim_2;
                }
                else if (Kolekcije.polufinala[i].Tim_1_kosevi < Kolekcije.polufinala[i].Tim_2_kosevi)
                {
                    pobednici[i] = Kolekcije.polufinala[i].Tim_2;
                    gubitnici[i] = Kolekcije.polufinala[i].Tim_1;
                }
                else
                {
                    Random r = new Random();
                    if (r.Next(0, 1) == 0)
                    {
                        pobednici[i] = Kolekcije.polufinala[i].Tim_1;
                        gubitnici[i] = Kolekcije.polufinala[i].Tim_2;
                    }
                    else
                    {
                        pobednici[i] = Kolekcije.polufinala[i].Tim_2;
                        gubitnici[i] = Kolekcije.polufinala[i].Tim_1;
                    }
                }
            }

            Kolekcije.zaTreceMesto.Tim_1 = gubitnici[0];
            Kolekcije.zaTreceMesto.Tim_2 = gubitnici[1];

            Kolekcije.finale.Tim_1 = pobednici[0];
            Kolekcije.finale.Tim_2 = pobednici[1];
        }

        public void OdigrajZaTreceMesto()
        {
            string pobednik;

            racunaljka.IzracunajRezultat(Kolekcije.zaTreceMesto);
            racunaljka.IzracunajFormu(Kolekcije.zaTreceMesto);

            if (Kolekcije.zaTreceMesto.Tim_1_kosevi > Kolekcije.zaTreceMesto.Tim_2_kosevi)
            {
                pobednik = Kolekcije.timovi[Kolekcije.zaTreceMesto.Tim_1].Team;
            }
            else if (Kolekcije.zaTreceMesto.Tim_1_kosevi < Kolekcije.zaTreceMesto.Tim_2_kosevi)
            {
                pobednik = Kolekcije.timovi[Kolekcije.zaTreceMesto.Tim_2].Team;
            }
            else
            {
                Random r = new Random();
                if (r.Next(0, 1) == 0)
                {
                    pobednik = Kolekcije.timovi[Kolekcije.zaTreceMesto.Tim_1].Team;
                }
                else
                {
                    pobednik = Kolekcije.timovi[Kolekcije.zaTreceMesto.Tim_2].Team;
                }
            }
            Kolekcije.medalje[2] = pobednik;
        }

        public void OdigrajFinale()
        {
            string pobednik;
            string gubitnik;

            racunaljka.IzracunajRezultat(Kolekcije.finale);
            racunaljka.IzracunajFormu(Kolekcije.finale);

            if (Kolekcije.finale.Tim_1_kosevi > Kolekcije.finale.Tim_2_kosevi)
            {
                pobednik = Kolekcije.timovi[Kolekcije.finale.Tim_1].Team;
                gubitnik = Kolekcije.timovi[Kolekcije.finale.Tim_2].Team;
            }
            else if (Kolekcije.finale.Tim_1_kosevi < Kolekcije.finale.Tim_2_kosevi)
            {
                pobednik = Kolekcije.timovi[Kolekcije.finale.Tim_2].Team;
                gubitnik = Kolekcije.timovi[Kolekcije.finale.Tim_1].Team;
            }
            else
            {
                Random r = new Random();
                if (r.Next(0, 1) == 0)
                {
                    pobednik = Kolekcije.timovi[Kolekcije.finale.Tim_1].Team;
                    gubitnik = Kolekcije.timovi[Kolekcije.finale.Tim_2].Team;
                }
                else
                {
                    pobednik = Kolekcije.timovi[Kolekcije.finale.Tim_2].Team;
                    gubitnik = Kolekcije.timovi[Kolekcije.finale.Tim_1].Team;
                }
            }
            Kolekcije.medalje[1] = gubitnik;
            Kolekcije.medalje[0] = pobednik;
        }

        public void OdrediPlasmanUGrupama()
        {
            plasman.OdrediPlasman();
        }

        public void OdrediRangZaSesire()
        {
            plasman.OdrediRang();
        }

        public void PopuniSesireZaEliminacije()
        {
            plasman.PopuniSesire();
        }

        public void PopuniMeceveCetvrtfinala()
        {
            plasman.PopuniCetvrtfinala();
        }
    }
}
