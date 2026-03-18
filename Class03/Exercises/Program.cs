#region Exercises

//1
int n = int.Parse(Console.ReadLine());
Console.WriteLine("1.");
for (int i = 1; i <= n; i++)
{
    Console.Write(" "+i);
}

Console.WriteLine("\n2.");
for (int i = n; i >= 1; i--)
{
    Console.Write(" " + i);
}

Console.WriteLine("\n3.");
for (int i = 2; i <= n; i += 2)
{
    Console.Write(" " + i);
}
Console.WriteLine("\n4.");
for (int i = 1; i <= n; i += 2)
{
    Console.Write(" " + i);
}



//2

int input = int.Parse(Console.ReadLine());
for(int i = 1; i <= input; i++)
{
    if(i%3==0 || i % 7 == 0)
    {
        continue;
    }

    if (i == 100)
    {
        Console.WriteLine("The limit is reached");
        break;
    }

    Console.WriteLine(i);
}

#endregion



