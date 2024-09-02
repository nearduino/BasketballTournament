using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTournament.Entiteti
{
    public class Tim
    {
        public string? Team { get; set; }
        public string? ISOCode { get; set; }
        public int FIBARanking { get; set; }
        public int Form { get; set; } = 5;
        public Dictionary<string, int> MedjusobniSusreti = new Dictionary<string, int>();
    }
}
