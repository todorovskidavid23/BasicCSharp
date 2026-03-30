//saat120-150evra
//saat 80-120evra


using Class06.Task2;

User[] users = new User[]//referenten tip koga ne postoi nesto moze da vrakjame null
{
    new User(1,"todorovskidavid","test123",new string[]{"Hello David!","How are you"}),
    new User(2, "greggreg", "password123", new string[] { "Hi Greg!", "How are you" }),
    new User(3, "johnJohn", "password12345", new string[] { "Hey Charlie"})
};

while (true)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1 - Log in");
    Console.WriteLine("2 - Register");
    Console.WriteLine("0 - Exit");
    
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Username: ");
        string username = Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();

        User foundUser = null;
        foreach (var user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                foundUser = user;
                break;
            }
        }

        if (foundUser != null)
        {
            Console.WriteLine($"Welcome {foundUser.Username}. Here are your messages:");
            foreach (var message in foundUser.Messages)
            {
                Console.WriteLine(message);
            }
        }
        else
        {
            Console.WriteLine("Error Inavil Username or Password");
        }
        
    }else if (choice == "2")
    {
        Console.Write("Enter ID: ");
        int newId = int.Parse(Console.ReadLine());
        Console.Write("Enter Username: ");
        string newUsername = Console.ReadLine();
        Console.Write("Enter Password: ");
        string newPassword = Console.ReadLine();

        bool usernameExists = false;
        foreach (var user in users)
        {
            if (user.Username == newUsername)
            {
                usernameExists = true;
                break;
            }
        }



    }

    
    else if (choice == "0")
    {
        break;
    }
    else
    {
        Console.WriteLine("Invalid option, try again.");
    }

    
}