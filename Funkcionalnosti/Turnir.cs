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
    }
}
