using Class05.Exercises;
using System.ComponentModel;

#region Exercise1

Console.Write("Enter first name: ");
string firstName = Console.ReadLine();

Console.Write("Enter last name: ");
string lastName = Console.ReadLine();

Console.Write("Enter age: ");
int age = int.Parse(Console.ReadLine());

Human human = new Human()
{
    FirstName = firstName,
    LastName = lastName,
    Age = age
};

Console.WriteLine(human.GetPersonStats());


#endregion



#region Exercise2

Console.WriteLine("Enter dog name:");
string name = Console.ReadLine();

Console.WriteLine("Enter dog race:");
string race = Console.ReadLine();

Console.WriteLine("Enter dog color:");
string color = Console.ReadLine();

Dog dog = new Dog()
{
    Name = name,
    Race = race,
    Color = color
};

Console.WriteLine("Choose an action:");
Console.WriteLine("1 - Eat");
Console.WriteLine("2 - Play");
Console.WriteLine("3 - Chase Tail");

int choice = int.Parse(Console.ReadLine());

switch (choice)
{
    case 1:
        dog.Eat();
        break;
    case 2:
        dog.Play();
        break;
    case 3:
        dog.ChaseTail();
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}

#endregion