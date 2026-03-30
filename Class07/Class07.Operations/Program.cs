using Class07.MathLibrary;
//desen klik Operations,defpendencies add project references i klikame

double num1 = 10.15;
double num2 = 123.43;

double num3 = 1500;
double num4 = 1890;

Console.WriteLine(MathOperations.Sum(num1, num2));
Console.WriteLine(MathOperations.Diff(num3, num4));


Console.WriteLine(MathOperations.Multiply(num2, num4));
Console.WriteLine(MathOperations.Divide(num1, num3));

Console.WriteLine(MathOperations.Pi);
