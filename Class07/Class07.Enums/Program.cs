//predefinirani integer vrednosti vo tekstualen prikaz
//setovi sto se predefinirani integer vresnoti vo tekstualen prikaz


using Class07.Enums.Enums;

Console.WriteLine(DaysOfWeek.Monday);

Console.WriteLine(Convert.ToInt16(DaysOfWeek.Monday));//broj na vresnot//defualt e 0 


//ako sakam od 1;

Console.WriteLine("Please enter day of week:");
string input = Console.ReadLine();

//Bad way
//if(input=="Saturday" || input == "Sunday")
//{
//    Console.WriteLine("Yeey! It is a weekend!");
//}

//Better way// koga imame potreba tamu kade sto ne menuvame vrednost tamu mozat da se napravat greski!!!
if (input == DaysOfWeek.Saturday.ToString() || input == DaysOfWeek.Sunday.ToString())
{
    Console.WriteLine("Yeey! It is a weekend!");
}

//ToString so ConvertTo ILI Parse ili Cast
