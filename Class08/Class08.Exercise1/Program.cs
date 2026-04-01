Dictionary<string, string> phoneBook = new Dictionary<string, string>()
{
    {"David1","072233211" },
    {"David2","072233212" },
    {"David3","072233213" },
    {"David4","072233214" },
};
Console.WriteLine("Enter a name: ");
string name = Console.ReadLine();

//if (phoneBook.ContainsKey(name))
//{
//    Console.WriteLine($"{name} phone number is {phoneBook[name]}");
//}

if(phoneBook.TryGetValue(name, out string phoneNumber))
{
    Console.WriteLine($"{name} phone number is {phoneNumber}");
}
else 
{
    Console.WriteLine("Name not found");
}