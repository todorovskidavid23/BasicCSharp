using System;
using System.Collections.Generic;
using System.Text;

namespace Class07.Inheritance.Models
{
    public class Cat : Animal
    {
        public string Lazyness { get; set; }
        //public string Lazyness { get; set; } = "Very";


        public Cat() : base("Cat")//defualt prazen konstructor// nalsedi od base construtor sto zima type
        {
            Console.WriteLine("A new instance of cat is created using the parent constructor that requires a string!");
            Thread.Sleep(2000);
        }

        public void Meow()
        {
            Console.WriteLine("Meow, Meow!");
        }

        public override void Eat()
        {
            Console.WriteLine("You don't tell a cat when to eat. A CAR EATS WHEN IT WANTS");
        }

    }
}
