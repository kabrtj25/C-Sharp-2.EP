// Volná disciplína (na co si troufneš).
// Ukázka na rozjezd: hádání čísla. Klidně to přepiš na vlastní nápad.
Console.OutputEncoding = System.Text.Encoding.UTF8;

Random nahoda = new Random();
int cislo = nahoda.Next(1, 101);
int pokusy = 0;

Console.WriteLine("Myslím si číslo od 1 do 100. Hádej! (b = konec)");

while (true)
{
    Console.Write("Tvůj tip: ");
    string? vstup = Console.ReadLine()?.Trim().ToLower();

    if (vstup == "b")
        break;
    if (!int.TryParse(vstup, out int tip))
    {
        Console.WriteLine("Zadej číslo.");
        continue;
    }

    pokusy++;
    if (tip < cislo)
        Console.WriteLine("Víc.");
    else if (tip > cislo)
        Console.WriteLine("Míň.");
    else
    {
        Console.WriteLine($"Trefa! Zvládl jsi to na {pokusy}. pokus.");
        break;
    }
}
