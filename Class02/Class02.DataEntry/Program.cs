
#region Data entries

Console.WriteLine("Please enter something:");
var userInput=Console.ReadLine();//se dodeka ne se vnese nesto;//komanda da se vnese nesto vo Console.
//read the next lone of cjaracters from the standard;
Console.WriteLine("User input"+userInput.GetType());

//SEKOGAS SE VNESUVA STRING
//ZATOA SEKOGAS PRAVIME PARSE AKO SAKAME DA VNESEME INTEGER
//int number=int.Parse(Console.ReadLine());
Console.WriteLine("Please insert number 1:");
int number1 =int.Parse(Console.ReadLine());//formatExeption ako vneseme string vo int readLine
//Unhandle exeption se prekinuva aplikacijata, posle continue zavrsuva aplikacijata

Console.WriteLine("Please insert number 2:");
string number2 = Console.ReadLine();

Console.WriteLine(number1+number2);


//int test = 10;//breakpoint ovde da mi zastane kodot.


#endregion

#region Data Conversion

int number3 = Convert.ToInt32(Console.ReadLine());

//kako da go izbegneme flranjeto ne exeptions;
bool isParsedNum4 = int.TryParse(Console.ReadLine(), out int number4);//KAKO DA DEKLALIRAME VARIJABLA SO NUMBER4 NOVO IME DAVAE
                                                                      //return true if s was converted succesfullt true ako uspesno go parse ili false ako ne uspee da go parsne

//integer defaulnta vrednost e 0;
//MNOGU VAZNO

#endregion


#region Branching, switch

Console.WriteLine("Enter day of the week and i will let you know if you have classes");
string dayOfTheWeek = Console.ReadLine();

switch (dayOfTheWeek.ToLower())
{
    case "monday":
        Console.WriteLine("You have classes on this day");
        break;
    case "tuesday":
        Console.WriteLine("No classes on this day");
        break;
    case "wednesday":
        Console.WriteLine("You have classes on this day");
        break;
    case "thursday":
    case "friday":
    case "saturday":
    case "sunday":
        Console.WriteLine("No classes on this day");
        break;
    default:
        Console.WriteLine("No such day of the week! Try again!");
        break;
}

//case sensitive

#endregion