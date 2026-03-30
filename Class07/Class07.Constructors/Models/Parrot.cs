using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Class07.Inheritance.Models
{
    public class Parrot : Animal
    {
        public string Color { get; set; }

        public Parrot()
        {
            
        }

        public Parrot(int id, string name, string type, string color)
            :base(id, name, type)
        {
            Color = color;
        }

        public void Fly()
        {
            Console.WriteLine("Wooow! I am flying");
        }

        public override void Eat()
        {
            Console.WriteLine($"I am {Name} and I am {Type} who don't have time to eat, beacause i speak all the time");
        }

    }
}
