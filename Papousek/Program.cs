// Papoušek: zopakuje, co mu napíšeš (ReadLine / WriteLine)
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Papoušek. Napiš něco a já to zopakuju. (b = konec)");

while (true)
{
    Console.Write("Řekni něco: ");
    string? radek = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(radek))
        continue;
    if (radek.Trim().ToLower() == "b")
        break;

    Console.WriteLine("Papoušek: " + radek);
}
