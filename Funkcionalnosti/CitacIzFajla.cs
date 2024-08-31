using BasketballTournament.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasketballTournament.Funkcionalnosti
{
    public class CitacIzFajla
    {
        public Dictionary<string, List<Tim>> UcitajGrupe(string path)
        {
            string json = File.ReadAllText(path);

            Dictionary<string, List<Tim>>? grupe = [];
            grupe = JsonSerializer.Deserialize<Dictionary<string, List<Tim>>>(json);

            return grupe;
        }

        public Dictionary<string, List<EgzibicioniMec>> UcitajEgzibicije(string path)
        {
            string json = File.ReadAllText(path);

            Dictionary<string, List<EgzibicioniMec>>? egzibicije = [];
            egzibicije = JsonSerializer.Deserialize<Dictionary<string, List<EgzibicioniMec>>>(json);

            return egzibicije;
        }
    }
}
