//Strings

#region String concatenation and escaping

string fName = "David";
string lName = "Todorovski";

//String Concatenaction
string hello1 = "Hello " + fName;//konkatanacija

//metoda Format
string hello2 = string.Format("Hello there {0} {1}", fName, lName); //na 15 razlicni kombinacii na input parametri
Console.WriteLine(hello2);

//String Intepolacija
//najednostavno so interpolacija//direkt ime na parametri
string hello3 = $"Hello there again {fName} {lName}";
Console.WriteLine(hello3);


//Escaping Characters in a string using \
//character vo programiranjeto escape carater slediov kod ne go racunaj kako kod tuku kako string
string message = "Check your c:\\ drive  ";
Console.WriteLine(message);

string fairElectionMessage = "We will have a \"fair\" election";
Console.WriteLine(fairElectionMessage);
// \pa" sekogas prvo \ back slash
//desno od \ ima vrska so programiranjeto;

string newLineMessage = "The \\n sign means new line in C#";
Console.WriteLine(newLineMessage);


string folderPath = "C:\\Users\\David\\AvengaAcademy\\C#Basics";
Console.WriteLine(folderPath);

//za da ne mora da koristime \ se koristi eden karakter @
//vo stringov kje ima specijalni karakteri escapeni gi site od start;
string folderParhNew = @"C:\Users\David\AvengaAcademy\C#Basics";
Console.WriteLine(folderParhNew);

//dinamicki da napravime string;
string avengaFolderName = "AvengaProjects";
string userName = "davidtodorovski";
//i davara odednas mozat da se koristat;
string pathToFolder = $@"C:\Users\{userName}\{avengaFolderName}";
Console.WriteLine(pathToFolder);

#endregion



#region String Formating

string myPercentageString = string.Format("This is {0:P}", 0.5);
Console.WriteLine(myPercentageString);

string myCurrencyValue = string.Format("It will cost me {0:C}", 125.45);
Console.WriteLine(myCurrencyValue);

string myStringNumber = string.Format("{0:N}", 190);
Console.WriteLine(myStringNumber);

string cardNumber = string.Format("{0:####-####-####-####}", 1234123412341234);
Console.WriteLine(cardNumber);

string phoneNumber = string.Format("{0:0##/###-###}", 072233212);
Console.WriteLine(phoneNumber);

string myCustomAllinedString = string.Format("| {0,10} | {1,10} |", "Id", "Order");
string myCustomAllinedString2 = string.Format("| {0,10} | {1,10} |", 23, "Iphone 17 Pro Max");

Console.WriteLine(myCustomAllinedString);
Console.WriteLine(myCustomAllinedString2);


#endregion



#region String Methods

string msg = "     We are learning C# and it is FUN and EASY. Okay maybe just FUN.   ";
Console.WriteLine(msg);

//da se izbrisat praznite mesta od stringot
Console.WriteLine(msg.Length);//71 
Console.WriteLine(msg.Trim().Length);//63= 71- prazni mesta(8)

string lower = msg.ToLower();
string upper = msg.ToUpper();

Console.WriteLine(lower);
Console.WriteLine(upper);

//string[], var;
string[] splittedString = msg.Split('.');
//niza od stringovi
Console.WriteLine(splittedString[0]);
Console.WriteLine(splittedString[1]);
Console.WriteLine(splittedString[2]);


bool doesStringStartsWith = msg.StartsWith("     W");
bool doesStringStartsWith1 = msg.Trim().StartsWith("W");
Console.WriteLine(doesStringStartsWith);
Console.WriteLine(doesStringStartsWith1);

//dali vo stringot ima odreden strong;

int indexOfString = msg.IndexOf("FUN");
Console.WriteLine(indexOfString);

int nonExistingString = msg.IndexOf("nope");
Console.WriteLine(nonExistingString);//-1 ne postoi ni vrakja -1;


string substring = msg.Substring(0, 15);//start i lenght kolku karateri da zeme
Console.WriteLine(substring);

char[] toChars = msg.ToCharArray();
Console.WriteLine(toChars.Length);


//Join za da se dva parametri so sto da se Joine "-" i , koja niza
Console.WriteLine(string.Join("-",toChars));



#endregion





//#region String Methods2


//static void Substrings()
//{
//    string text = "Hello from Avenga Codecademy 2024";

//    Console.WriteLine("Enter a number n to get the first n characters:");

//    bool isParsed = int.TryParse(Console.ReadLine(), out int characters);

//    if (!isParsed)
//    {
//        Console.WriteLine("Invalid input! Please enter a valid number.");
//        return;
//    }

//    if (characters > text.Length)
//    {
//        Console.WriteLine($"Number too large! The string has only {text.Length} characters.");
//        characters = text.Length;
//    }

//    string result = text.Substring(0, characters);

//    Console.WriteLine($"Substring: {result}");
//    Console.WriteLine($"Length of substring: {result.Length}");
//}

//Substrings();

//#endregion