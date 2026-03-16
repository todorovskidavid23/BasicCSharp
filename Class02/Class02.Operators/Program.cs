using System.Reflection.Metadata;

double a = 10;
double b = 202;

double sum = a + b;
var diff = a - b;

var multiply = a * b;
double division = (double)a / b;
//da si stavime site so var deka kje si znae sto kje bide rezultatot

var complexExpression = ((a + b) / (a - b)) * multiply;
//hover na complexExpression i ni dava deka e double





Console.WriteLine(sum);
Console.WriteLine(diff);
Console.WriteLine(multiply);
Console.WriteLine(division);
Console.WriteLine(complexExpression);

var reminder = a % 7;//ostatok 1 10 so 3 1 ostatok
Console.WriteLine(reminder);

Console.WriteLine(++b);//na istoto mesto ze sobira
Console.WriteLine(b++);//posle ova se sobira
Console.WriteLine(b);



double first1 = 10;
double second1 = 20;
var resut1