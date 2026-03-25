namespace Class05.Classes.Models//namsespace e folder vo conosleapp imame models i vnatre imame person class
{
    //public class Person// accessible only inside the same project za internal
    //{

    //}
    public class Person
    {
        //properties vo klasa
        //acces modifier, tip na proeprties// ime na properties {get; set;}
        //defult get i set
        public string FirstName { get; set; }//read//write
        public string LastName { get; set; }
        //So golema bukva PaskacCaseNotation FirstName
        //propertie i metodi se so pascal case
        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string[] Hobbies { get; set; }

        public bool IsStudent { get; set; }

        //prop tab
        private long SSN { get; set; }//samo ovde se gleda ova property

        //Defualt constructor and it is parameterless

        public Person()
        {
            SSN = GenerateSSN();
        }

        //kolku sakame razlicni konstruktori
        //Constructor With Parameters
        //ctor
        public Person(string fName, string lName, string phoneNumber, int age, string[] hobbies, bool isStudent)
        {
            FirstName = fName;
            LastName = lName;
            PhoneNumber = phoneNumber;
            Age = age;
            Hobbies = hobbies;
            IsStudent = isStudent;
            SSN = GenerateSSN();//dostapna si e ovde deka e vo ista klasa vo ist scope
        }


        public Person(string fName)
        {
            FirstName = fName;
            LastName = "N/A";//not applied
            PhoneNumber = "N/A";
        }

        private long GenerateSSN()
        {
            return new Random().Next(100000,9999999);//radnom broj od ovoj opseg// Get a random number between the values;
        }

        public void Talk(string text)
        {
            Console.WriteLine($"The human name {this.FirstName} (SSN:{SSN}) is saying {text}");
        }

        public long GetSSNValue()
        {
            return SSN;
        }


    }
}
