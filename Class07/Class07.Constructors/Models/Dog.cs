using System;
using System.Collections.Generic;
using System.Text;

namespace Class07.Inheritance.Models
{
    public class Dog : Animal//Dog class naleduva od Animal class
    {
        public string Race { get; set; }

        public Dog()
        {
            Console.WriteLine("A new instance of a dog is created and also called the default(empty) Parent Constructor");
            Thread.Sleep(2000);
        }
        public void Bark()
        {
            Console.WriteLine("Woof woof woof!");
        }


        //ova od virtual
        public override void Eat()
        {
            //    base.Eat();//defult ako ne dades nesto novo kje si go dade istoto
            Console.WriteLine($"Hi people! I am {Name} the {Type} and I am eating!");
        //VIRTUAL VO PARENT A VO SEKOE DETE SAMO OVERRIDE PRED VOID IST RETURN DA NE PRIMA PARAMAETRI
        }



    }
}
