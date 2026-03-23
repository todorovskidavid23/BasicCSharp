//methodi interpolacija i metodi DaeTime tip vo C#


//Methodi ili co class i funkcijata se vika metodata (methods)
//pak sme na nivo klass Program.cs Program.csharp
//nivo na klasa
//TOP LEVEL STATEMENTS executable program si ima vo pozadina program.cs 
//na nivo na klasa sme .NET znae deka sme nie vo klasa
//
//Zosto ni se dobri metodite
//metoda e resuable peace code odredena logika sto treba na povekje mesta
//Decouple responsibilitiies
//Karakteristicno za STRONGLY TYPED LANGUAGE
//nacin i pravilo na posuvanje
//moraat da imaat return type
//A method name mora da imame ime na metodata 
//Parametars type tip na input parameri deklarirame metoda mora da znaeme od koj  tip se
//void ako ne vrakja nisto mora da vrakja void taa e oznaka za nisto.

#region Methods declarations and usage
//Method that print in console does not return value or it returs 'void'
//Does not accept input parametars
using System.Data;

static void SaySomething()
{
    Console.WriteLine("Hello there i am learning C# Methods!");
    Console.ReadLine();//da ni stoi kodot za da ne ide nadole
}

//slabosti se Local Function moze da bide static
//Progarm.cs e staticka klasa i mora da imame static
//Static za da ne morame da kreirame objekt od niv, tuku direkto so niv da rabotime
//Staticki void main metod sekogas static taa se kreira istanca od Program.cs klasata vo toj moment se pravi istanca

//tipovi na klasi tamu podetalno

SaySomething();

//Method that print in cosnole
//Does not return avalue or it returns void
//Accept input parametar and type string
static void SayHelloToSomeone(string person)//mora person da se znae od koj tip e parametarot
{
    Console.WriteLine("Hello there " + person + " I have to tell you something");
    Console.ReadLine();
}

SayHelloToSomeone("David");//si prima input parametar
SayHelloToSomeone("Mario");


static void SendEmail(bool isSenderValid, string message)
{
    if (isSenderValid)
    {
        Console.WriteLine("The message was send ! Message: "+message);
    }
    else
    {
        Console.WriteLine("The message was not sent ! Message: "+message);
    }
    Console.ReadLine();
}
SendEmail(true, "Hi David, here is my C# homework");
SendEmail(false, "Hi David, here is my JS project ");


//Method that returns a value
//Returns value of 'int'
//Accept input parameters a dn b also of type 'int'

static int Sum(int a, int b)
{
    return a + b;
}
Console.WriteLine(Sum(10,3));


static int Substract(int a, int b)
{
    return a - b;
}
Console.WriteLine(Substract(10, 7));


static void PrintSomething()
{
    Console.WriteLine("Hello There");
}





#endregion


#region Exercise1

Console.Write("Enter operation (* or /): ");
string operation = Console.ReadLine();

Console.Write("Enter first number: ");
double num1 = double.Parse(Console.ReadLine());

Console.Write("Enter second number: ");
double num2 = double.Parse(Console.ReadLine());

double result;



if (operation == "*")
{
    result = Multiply(num1, num2);
}
else if (operation == "/")
{
    if (num2 == 0)
    {
        Console.WriteLine("You cannot divide by 0!");
    }
    result = Divide(num1, num2);
}
else
{
    Console.WriteLine("Invalid operation.");
    return;
}

Console.WriteLine("Result: " + result);
    
static double Multiply(double a, double b)
{
    return a * b;
}

static double Divide(double a, double b)
{
    return a / b;
}


#endregion

#region Exercise1.Prof

static double Multiplyy(double a, double b)
{
    return a * b;
}

static double Dividee(double a, double b)
{
    return a / b;
}

Console.WriteLine("Enter operation * or /: ");
string operationn = Console.ReadLine();

Console.WriteLine("Enter the first number");
bool isParsedNum1 = double.TryParse(Console.ReadLine(), out double num11);

Console.WriteLine("Enter the second number");
bool isParsedNum2 = double.TryParse(Console.ReadLine(), out double num22);

if(!isParsedNum1 || !isParsedNum2)
{
    Console.WriteLine("Please enter only number values");
}
else
{
    if (operationn == "*")
    {
        double resultt = Multiplyy(num11, num22);
        Console.WriteLine("The result is: "+resultt);
    }
    else if (operationn == "/")
    {
        if (num2 == 0)
        {
            Console.WriteLine("Cannot divide by 0. Please try again");
        }
        else
        {
            double resultt=Divide(num11, num22);
            Console.WriteLine("The result is: "+resultt);
        }
    }
    else
    {
        Console.WriteLine("Please insert valid operator!!!");
    }
}




#endregion