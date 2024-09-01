using BasketballTournament.Entiteti;
using BasketballTournament.Funkcionalnosti;
using BasketballTournament.Podaci;

string currentPath = Directory.GetCurrentDirectory();
string projectPath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\"));
string resourcesPath = Path.Combine(projectPath, @"Resources\");

string grupePath = Path.Combine(resourcesPath, @"groups.json");
string egzibicijePath = Path.Combine(resourcesPath, @"exibitions.json");

CitacIzFajla citacIzFajla = new CitacIzFajla();
Racunaljka racunaljka = new Racunaljka();
Turnir turnir = new Turnir();
IspisivacUKonzolu ispisivacUKonzolu = new IspisivacUKonzolu();

Kolekcije.grupe = citacIzFajla.UcitajGrupe(grupePath);
Kolekcije.egzibicije = citacIzFajla.UcitajEgzibicije(egzibicijePath);

foreach (var g in Kolekcije.grupe)
{
    foreach (var tim in g.Value)
    {
        Kolekcije.timovi.Add(tim.ISOCode, tim);
    }
}

racunaljka.IzracunajPocetnuFormu();

turnir.OdigrajKolo("Kolo1");
turnir.OdigrajKolo("Kolo2");
turnir.OdigrajKolo("Kolo3");

ispisivacUKonzolu.IspisiKolo("Kolo1");
ispisivacUKonzolu.IspisiKolo("Kolo2");
ispisivacUKonzolu.IspisiKolo("Kolo3");



