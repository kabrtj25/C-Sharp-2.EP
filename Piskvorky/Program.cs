// Piškvorky 3x3 pro dva hráče (pole, cykly)
Console.OutputEncoding = System.Text.Encoding.UTF8;

char[] pole = new char[9];
for (int i = 0; i < 9; i++)
    pole[i] = (char)('1' + i);

int[][] vyherniRady =
{
    new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
    new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
    new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
};

Console.WriteLine("Piškvorky pro 2 hráče. Zadej číslo políčka 1-9 (b = konec).");
char hrac = 'X';

while (true)
{
    Vykresli();

    if (Vyhral('X')) { Console.WriteLine("Vyhrál X!"); break; }
    if (Vyhral('O')) { Console.WriteLine("Vyhrálo O!"); break; }
    if (pole.All(c => c == 'X' || c == 'O')) { Console.WriteLine("Remíza!"); break; }

    Console.Write($"Hraje {hrac}. Vyber políčko (1-9) nebo b: ");
    string? vstup = Console.ReadLine()?.Trim().ToLower();

    if (vstup == "b")
        break;
    if (!int.TryParse(vstup, out int cislo) || cislo < 1 || cislo > 9)
    {
        Console.WriteLine("Neplatná volba.");
        continue;
    }
    if (pole[cislo - 1] == 'X' || pole[cislo - 1] == 'O')
    {
        Console.WriteLine("Políčko je už obsazené.");
        continue;
    }

    pole[cislo - 1] = hrac;
    hrac = hrac == 'X' ? 'O' : 'X';
}

void Vykresli()
{
    Console.WriteLine();
    Console.WriteLine($" {pole[0]} | {pole[1]} | {pole[2]}");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {pole[3]} | {pole[4]} | {pole[5]}");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {pole[6]} | {pole[7]} | {pole[8]}");
    Console.WriteLine();
}

bool Vyhral(char znak)
{
    foreach (int[] rada in vyherniRady)
    {
        if (pole[rada[0]] == znak && pole[rada[1]] == znak && pole[rada[2]] == znak)
            return true;
    }
    return false;
}
