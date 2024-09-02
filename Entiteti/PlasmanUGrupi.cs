using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Entiteti
{
    public class PlasmanUGrupi
    {
        public string Team { get; set; }
        public int Pobede { get; set; } = 0;
        public int Porazi { get; set; } = 0;
        public int Bodovi { get; set; } = 0;
        public int PostignutiKosevi { get; set; } = 0;
        public int PrimljeniKosevi { get; set; } = 0;
        public int KosRazlika { get; set; } = 0;
    }
}
