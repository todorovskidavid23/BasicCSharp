//static void NumberStats(double number)
//{
//    Console.WriteLine($"Stats for number: {number}");

//    if (number >= 0)
//        Console.WriteLine("Positive");
//    else
//        Console.WriteLine("Negative");

//    if (number %1 == 0)
//        Console.WriteLine("Integer");
//    else
//        Console.WriteLine("Decimal");

//    //if (number % 1 == 0)
//    //{
//    //    if (number % 2 == 0)
//    //        Console.WriteLine("Even");
//    //    else
//    //        Console.WriteLine("Odd");
//    //}

//    int  wholeNumber= (int)number;

//    if (wholeNumber % 2 == 0)
//        Console.WriteLine("Even");
//    else
//        Console.WriteLine("Odd");


//}



//do
//{
//    Console.WriteLine("Enter a number:");
//    string input = Console.ReadLine();

//    if (!double.TryParse(input, out double number))
//    {
//        Console.WriteLine("Invalid input! Please enter a valid number.");
//    }
//    else
//    {
//        NumberStats(number);
//    }

//    Console.WriteLine("Press Y to try again or X to exit:");
//    string choice = Console.ReadLine();

//    if (choice=="x" || choice == "X")
//    {
//        break;
//    }

//} while (true);


#region Task1 - NumberStats

static void NumberStats(double number)
{
    bool isNegative = number > 0 ? false : true;
    //vo slucaj na e pogolem od nula imame false ako ne true
    bool isDecimal = number % 1 > 0 ? true : false;
    bool isEven = number % 2 == 0 ? true : false;

    Console.WriteLine($"Stats for number: {number}");
    Console.WriteLine(string.Format("{0}", isNegative ? "Negative" : "Positive"));
    Console.WriteLine(string.Format("{0}", isDecimal ? "Decimal" : "Integer"));
    Console.WriteLine(string.Format("{0}", isEven ? "Even" : "Odd"));

    if (isDecimal)
    {
        Console.WriteLine("Not even not odd as wrll! Decimal Number");
        return;
    }
    else if(isEven)
    {
        Console.WriteLine("Even");
    }
    else
    {
        Console.WriteLine("Odd");
    }
}

//inf loop validacija
bool UserInterface()
{
    Console.WriteLine("Enter a number:");
    bool isNumber = double.TryParse(Console.ReadLine(), out double userInput);
    if (!isNumber)
    {
        Console.WriteLine("That was not a number ! Please try agina!");
        return false;
    }
    NumberStats(userInput);
    Console.WriteLine("Press any key to try again or X to exit");
    if (Console.ReadLine().ToUpper() == "X")
        return true;
    return false;

}while (!UserInterface()) ;

//infinite loop so metoda
//se dodeka ne mi vrati true
//se dodeka mi vrakja false me drzi vo loop

#endregion
//New comment
//
// else if (choice == "2")
// {
//     Console.Write("Enter new ID: ");
//     int newId;
//     while (!int.TryParse(Console.ReadLine(), out newId))
//     {
//         Console.Write("Please enter a valid integer ID: ");
//     }
//
//     Console.Write("Enter new Username: ");
//     string newUsername = Console.ReadLine();
//
//     Console.Write("Enter new Password: ");
//     string newPassword = Console.ReadLine();
//
//     bool usernameExists = false;
//     foreach (var user in users)
//     {
//         if (user.Username == newUsername)
//         {
//             usernameExists = true;
//             break;
//         }
//     }
//
//     if (usernameExists)
//     {
//         Console.WriteLine("Error: There is already a user called like that.");
//     }
//     else
//     {
//         User[] newUsersArray = new User[users.Length + 1];
//         for (int i = 0; i < users.Length; i++)
//             newUsersArray[i] = users[i];
//
//         newUsersArray[newUsersArray.Length - 1] = new User(newId, newUsername, newPassword, new string[] { });
//         users = newUsersArray;
//
//         Console.WriteLine("Registration complete! Users:");
//         foreach (var user in users)
//         {
//             Console.WriteLine($"{user.Id} {user.Username}");
//         }
//     }
// }
//
//
//
//
// //novo so resize
// else if (choice == "2")
// {
//     Console.Write("Enter ID: ");
//     int id = int.Parse(Console.ReadLine());
//     Console.Write("Enter Username: ");
//     string username = Console.ReadLine();
//     Console.Write("Enter Password: ");
//     string password = Console.ReadLine();
//
//     // Проверка дали корисничкото име веќе постои
//     bool exists = false;
//     foreach (var user in users)
//     {
//         if (user.Username == username)
//         {
//             exists = true;
//             break;
//         }
//     }
//
//     if (exists)
//     {
//         Console.WriteLine("Error: A user with this username already exists.");
//     }
//     else
//     {
//         // Додавање на нов корисник во массивот
//         Array.Resize(ref users, users.Length + 1);
//         users[users.Length - 1] = new User(id, username, password, new string[] { });
//
//         Console.WriteLine("Registration complete! Users:");
//         foreach (var user in users)
//         {
//             Console.WriteLine($"{user.Id} {user.Username}");
//         }
//     }
// }
