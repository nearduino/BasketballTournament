using BasketballTournament.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Podaci
{
    public static class Kolekcije
    {
        public static Dictionary<string, List<Tim>> grupe = [];
        public static Dictionary<string, Tim> timovi = [];
        public static Dictionary<string, List<EgzibicioniMec>> egzibicije = [];
        public static Dictionary<string, List<PraviMec>> mecevi = [];

        public static Dictionary<string, PlasmanUGrupi> plasmanPoTimu = [];
        public static Dictionary<string, List<PlasmanUGrupi>> grupniPlasmani = [];
        public static List<PlasmanUGrupi> plasmaniPoRangu = [];
        public static Dictionary<string, List<Tim>> sesiri = [];

        public static List<PraviMec> cetvrtfinala = [];
        public static List<PraviMec> polufinala = [];
        public static PraviMec zaTreceMesto = new PraviMec();
        public static PraviMec finale = new PraviMec();

        public static string[] medalje = new string[3];
    }
}
