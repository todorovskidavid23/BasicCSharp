using System;
using System.Collections.Generic;
using System.Text;

//IDE integrated development invironment
//da pravime razni aplikacii
//si imame odredeni templates
//Class proket razlikata e project da sodrzi vo nego shared raboti ne e runnable

//ne moze set as startip project deka ne moze da se startne
//is referenced from other projects// da imame shared logika vo nego
//da primime input vo user, toa vo metoda vo Class
//4 consolni e
//funcii sto se refeneciraat, za get input, matematicki operacii


namespace Class07.MathLibrary
{
    public static class MathOperations//klasata ako e static  mora i property da se static
    {
        public const double Pi = 3.14;
        public static double Sum(double a, double b)
        {
            return a + b;
        }
        public static double Diff(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero! Please enter valid value!");
            }
            return a / b;
        }



    }
}
