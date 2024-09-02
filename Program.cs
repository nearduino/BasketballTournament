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

Turnir turnir = new Turnir();

racunaljka.IzracunajPocetnuFormu();

turnir.OdigrajKolo("Kolo1");
turnir.OdigrajKolo("Kolo2");
turnir.OdigrajKolo("Kolo3");

ispisivacUKonzolu.IspisiKolo("Kolo1");
ispisivacUKonzolu.IspisiKolo("Kolo2");
ispisivacUKonzolu.IspisiKolo("Kolo3");

turnir.OdrediPlasmanUGrupama();
ispisivacUKonzolu.IspisiPlasmanUGrupama();

turnir.OdrediRangZaSesire();
ispisivacUKonzolu.IspisiRangove();

turnir.PopuniSesireZaEliminacije();
ispisivacUKonzolu.IspisiSesire();

turnir.PopuniMeceveCetvrtfinala();
ispisivacUKonzolu.IspisiCetvrtfinala();

turnir.OdigrajCetvrtfinala();
ispisivacUKonzolu.IspisiRezultateCetvrtfinala();

turnir.OdigrajPolufinala();
ispisivacUKonzolu.IspisiRezultatepolufinala();

turnir.OdigrajZaTreceMesto();
ispisivacUKonzolu.IspisiRezultatZaTreceMesto();

turnir.OdigrajFinale();
ispisivacUKonzolu.IspisiRezultatFinala();

ispisivacUKonzolu.IspisiMedalje();

//foreach (var tim in Kolekcije.timovi)
//{
//    Console.WriteLine(tim.Key);
//}

//foreach (var plasman in Kolekcije.plasmanPoTimu)
//{
//    Console.WriteLine($"{plasman.Key} {plasman.Value.Bodovi}");
//}
