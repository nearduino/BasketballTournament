using BasketballTournament.Entiteti;
using BasketballTournament.Funkcionalnosti;

Dictionary<string, List<Tim>>? grupe = [];
Dictionary<string, Tim>? timovi = [];
Dictionary<string, List<EgzibicioniMec>> egzibicije = [];
Dictionary<string, List<PraviMec>> mecevi = [];

string currentPath = Directory.GetCurrentDirectory();
string projectPath = Path.GetFullPath(Path.Combine(currentPath, @"..\..\..\"));
string resourcesPath = Path.Combine(projectPath, @"Resources\");

string grupePath = Path.Combine(resourcesPath, @"groups.json");
string egzibicijePath = Path.Combine(resourcesPath, @"exibitions.json");

CitacIzFajla citacIzFajla = new CitacIzFajla();

grupe = citacIzFajla.UcitajGrupe(grupePath);
egzibicije = citacIzFajla.UcitajEgzibicije(egzibicijePath);

foreach (var g in grupe)
{
    foreach (var tim in g.Value)
    {
        timovi.Add(tim.ISOCode, tim);
    }
}

foreach (var tim in timovi)
{
    Console.WriteLine(tim.Value.Team);
}

foreach (var e in egzibicije)
{
    Console.WriteLine($"{e.Key} vs {e.Value[0].Opponent} ({e.Value[0].Result})");
    Console.WriteLine($"{e.Key} vs {e.Value[1].Opponent} ({e.Value[1].Result})");
}

