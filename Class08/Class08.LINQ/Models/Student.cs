using System;
using System.Collections.Generic;
using System.Text;

namespace Class08.LINQ.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public Academy Academy { get; set; }
        public List<string> Subjects{ get; set; }


        public Student(int id, string fName, string lName, int age, string group, Academy academy, List<string>subjects)
        {
            Id = id;
            FirstName = fName;
            LastName = lName;
            Age = age;
            Group = group;
            Academy = academy;
            Subjects = subjects ?? new List<string>();
            //ako nisto ne mi stavis stavi prazna lista vo subjects
                   
        }

    }
}
