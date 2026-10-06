// Šibenice (soubory): slova se načítají ze souboru slovnicek.txt
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

string cesta = Path.Combine(AppContext.BaseDirectory, "slovnicek.txt");
string[] slovicka = File.ReadAllLines(cesta)
    .Where(s => !string.IsNullOrWhiteSpace(s))
    .ToArray();

Random nahoda = new Random();
string slovo = slovicka[nahoda.Next(slovicka.Length)].Trim().ToLower();

HashSet<char> hadana = new HashSet<char>();
int zivoty = 7;

Console.WriteLine("Šibenice. Hádej písmena slova. (b = konec)");

while (zivoty > 0)
{
    string zobrazeni = string.Concat(slovo.Select(c => hadana.Contains(c) ? c : '_'));
    Console.WriteLine($"\n{string.Join(' ', zobrazeni.ToCharArray())}   (životy: {zivoty})");

    if (!zobrazeni.Contains('_'))
    {
        Console.WriteLine("Vyhrál jsi!");
        return;
    }

    Console.Write("Hádej písmeno: ");
    string? vstup = Console.ReadLine()?.Trim().ToLower();

    if (vstup == "b")
        return;
    if (string.IsNullOrEmpty(vstup) || vstup.Length != 1 || !char.IsLetter(vstup[0]))
    {
        Console.WriteLine("Zadej právě jedno písmeno.");
        continue;
    }

    char pismeno = vstup[0];
    if (!hadana.Add(pismeno))
    {
        Console.WriteLine("To už jsi zkoušel.");
    }
    else if (!slovo.Contains(pismeno))
    {
        zivoty--;
        Console.WriteLine("Tam není.");
    }
}

Console.WriteLine($"\nProhrál jsi. Slovo bylo: {slovo}");
