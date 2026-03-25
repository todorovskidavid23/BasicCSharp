using System;
using System.Collections.Generic;
using System.Text;

namespace Class05.Classes.Models
{
    internal class Student
    {
        public string FullName { get; set; }//simple type
        public int Age { get; set; }
        public Group Group { get; set; }//klasite se tipovi od tip Group od Group klasa//complex Referenten tip sto pokazuva na druga klasa
        //SEKOGAS KOGA IMAME OD COMPLEX TIP NA NAPRAVIME ISTANCA OD DEFAULT CONSTRUCTOR
        //na new Group da go stavime
        public Student(string fullName, int age, Group group)
        {
            FullName = fullName;
            Age = age;
            //The same as the following if else but using null coalescing operator ?? 
            //na property Group sto kje vleze vo Gropu NO PROVERI ako e null dodeli ja ovaa vrednost kako ternaly operator a ova vazi za null
            //
            Group = group ?? new Group("Unknown", 0, "Unknown");

            //if(group != null)
            //{
            //    Group = group;
            //}
            //else
            //{
            //    Group = new Group("Unknown",0,"Unknown");//bitno da ne mi e null//SO DEFAULT CONSTRUKTOR za string defult e null
            //}
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"{FullName} from {Group.GroupName}");//NullReferenceExeption
            //Object reference not set to an instance of an object Group e null i staka da mu pristapi GroupName ne moze od nesto sto e null i da baras property GroupName
        }

    }
}
