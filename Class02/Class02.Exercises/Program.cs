#region Exercise1
using System.Data;
using System.Threading.Channels;

double first1 = 10;
double second1 = 20;
var resut1 = first1 / second1;
Console.WriteLine(resut1);

int first2 = 10;
int second2 = 20;
var result2 = first2 / second2;
Console.WriteLine(result2);

string first3 = "David";
string second3 = "Todorovski";
var result3 = first3 + second3;
Console.WriteLine(result3);

string first4 = "9";
string second4 = "3";
var result4 = first4 + second4;
Console.WriteLine(result4);


///////
int num3 = 10;
double num4 = 0;
double div2 = num3 / num4;
//runtime greska deka ne moze so 0  da se deli RUNTIME ERROR;
//double divByZero = 10 / 0;//compileTimeError ne moze da se kompajlira
//NEMA NI DA POCNE DA KOMPAJLIRA
Console.WriteLine($"div 2 : {div2}");
/////

#endregion


#region Exercise2

int x = 10;
string y = "David";
var result5 = x+" "+ y;
Console.WriteLine(result5);

#endregion


#region Exercise3
int mobilePhoneC = 102;
int smsCost = 5;
var numberOfSMS = mobilePhoneC / smsCost;
Console.WriteLine($"Mobile phone {mobilePhoneC} and SMS cost of {smsCost} you can spend {numberOfSMS} SMS messages");


#endregion
//na solution add new project i pravime set as starup project
//imam class








#region Exercise4


int treeApples = 12 * 8;//96
int basketApples = 5;
Console.WriteLine("Enter number of trees");
int numberOfTrees = int.Parse(Console.ReadLine());
int totalApples = treeApples * numberOfTrees;

int basket = totalApples / basketApples;

if (totalApples % basketApples != 0)
{
    basket++;
}

Console.WriteLine("Potrebni ni se "+basket+" baskets");

//int treeApples = 8;
//int basketApples = 5;

//Console.Write("Enter number of trees: ");
//int trees = int.Parse(Console.ReadLine());

//int applesPerTree = 12 * treeApples;
//int totalApples = trees * applesPerTree;
//int baskets = totalApples / basketApples;

//if (totalApples % basketApples != 0)
//{
//    baskets++;
//}

//Console.WriteLine("You need " + baskets + " baskets.");

#endregion

//#region Exercise5

//Console.WriteLine("Vnesi aa:");
//int aa = int.Parse(Console.ReadLine());
//Console.WriteLine("Vnesi bb:");
//int bb = int.Parse(Console.ReadLine());
//int largerNum;

//if (aa > bb)
//{
//    largerNum = aa;
//}
//else
//{
//    largerNum = bb;
//}

//Console.WriteLine($"The lager Number is {largerNum}");

//if (largerNum % 2 == 0)
//{
//    Console.WriteLine("Even");
//}
//else
//{
//    Console.WriteLine("Odd");
//}


//#endregion