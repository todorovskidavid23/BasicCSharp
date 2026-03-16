using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

//region i si davame ime na region vnatre i si zatvarame
#region DataTypes
//Declaration and initialization of variables

int number = 154;
int otherNumber = 10500;

short shortNumber = 150;
long bigNumber =12043340543;

double decimalNumber1 = 10.44;
float deciamlNUmber2 = 155.45F;
//ako dodademe bukva F ili f za da bide float
//double number sakas da go napravis float
decimal decmalNumber3 = 15545.32345m;
//side decimalni borevi gi tretira kako double;
//f za float m M za decimal


string fullName= "David Todorovski";
string lastName;//deklarirana
lastName = "Todorovski";//inicijalizacija
Console.WriteLine(lastName);
char character = 'D';

bool falsy = false;

Console.WriteLine(number);
Console.WriteLine(otherNumber);//so zelena boja varijablata sme ja deklariranje ne sme ja iskoristile
Console.WriteLine(decimalNumber1);
Console.WriteLine(falsy);


//Implicit Type Variable
//var go stavame ako stavime name so var nadoe celo vreme kje bide string, ne moze da se pro,eni
//kodot si znae deka prvata deklarirana e STRING



#endregion

#region Implicit Data Types

var academyName = "Avenga Academy";//ne moze da se menuva
//academyName = 10;//this will not work the application won't run until fixed;

var numberOfStudents = 20;
numberOfStudents = 339;
Console.WriteLine(numberOfStudents);


var isSunny = true;
isSunny = false;

#endregion


#region Check Data Type

Console.WriteLine(isSunny.GetType());
//System.Boolean

#endregion