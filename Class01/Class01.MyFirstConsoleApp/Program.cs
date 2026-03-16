Console.WriteLine("Hello, World!");
int n = 5;

for (int i = 0; i < n; i++)
{
    for (int s = 1; s <= n - i; s++)
        Console.Write(" ");

    for (int star = 1; star <= 2 * i - 1; star++)
        Console.Write("*");

    Console.WriteLine();
}


Console.WriteLine("David");

Console.WriteLine("*********");
Console.WriteLine("Hello David");

//New class
Console.WriteLine("NEW CLASS");