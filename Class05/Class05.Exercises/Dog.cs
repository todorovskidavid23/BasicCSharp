using System;
using System.Collections.Generic;
using System.Text;

namespace Class05.Exercises
{
    public class Dog
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }


        public void Eat()
        {
            Console.WriteLine($"The {Name} with color {Color} and race {Race} is now eating");
        }

        public void Play()
        {
            Console.WriteLine($"The {Name} with color {Color} and race {Race} is now playing");
        }

        public void ChaseTail()
        {
            Console.WriteLine($"The {Name} with color {Color} and race {Race}is now chasing its tail");
        }



    }


}
