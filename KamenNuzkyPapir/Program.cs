// Kámen-nůžky-papír (podmínky if)
Console.OutputEncoding = System.Text.Encoding.UTF8;

Random nahoda = new Random();
string[] nazvy = { "kámen", "nůžky", "papír" };
int skorHrac = 0, skorPocitac = 0;

Console.WriteLine("Kámen, nůžky, papír. Zadej 1 = kámen, 2 = nůžky, 3 = papír. (b = konec)");

while (true)
{
    Console.Write("\nTvůj tah (1/2/3 nebo b): ");
    string? vstup = Console.ReadLine()?.Trim().ToLower();

    if (vstup == "b")
        break;
    if (!int.TryParse(vstup, out int volba) || volba < 1 || volba > 3)
    {
        Console.WriteLine("Neplatná volba. Zadej 1, 2, 3 nebo b.");
        continue;
    }

    int hrac = volba - 1;          // 0 = kámen, 1 = nůžky, 2 = papír
    int hod = nahoda.Next(3);      // tah počítače
    Console.WriteLine($"Ty: {nazvy[hrac]}, počítač: {nazvy[hod]}");

    if (hrac == hod)
    {
        Console.WriteLine("Remíza.");
    }
    else if ((hrac == 0 && hod == 1) || (hrac == 1 && hod == 2) || (hrac == 2 && hod == 0))
    {
        skorHrac++;
        Console.WriteLine("Vyhrál jsi toto kolo!");
    }
    else
    {
        skorPocitac++;
        Console.WriteLine("Toto kolo vyhrál počítač.");
    }

    Console.WriteLine($"Skóre -> ty: {skorHrac}, počítač: {skorPocitac}");
}
