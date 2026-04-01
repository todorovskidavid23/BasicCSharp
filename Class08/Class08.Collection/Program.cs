//Collections
//Generic Collections
//Prethodno so nizi sega so Collections

//dynamics
//Arrays nizi se korisni

//Generic Collections
//type safe, ili integer,double string,boolean, ne se mesaat vresnostite, dimanicni se nemaat fiksen size
// < > 
// Built In metodi ,Add, Remove, prv ,posleden, sort, itn.

//Collections are not one-size-fits-all 
//List nizi fleksibilni.genericka indeksirana 0 based, moze da bide povekje namenska,
//Dictionary genericka kolekcija, vazi za koj bilo tip GENERALNO SE UPOTREBENI, Key-Value parovi ,
//Queue First In First Out ,
//Stack Last In First Out
//

using Class08.Collection.Models;
using System.Collections;
using System.Runtime.CompilerServices;

//IEnumerable tip na struktura na Interface SITE GENERICKI Collections nasleduvaat od IEnumerable
//List<int> collections
//Za site listi sto kje gi pokazeme koristime Interface 
static void PrintCollection(IEnumerable collection, string name)
{
    Console.WriteLine($"Collection {name} items: ");
	foreach (var item in collection)
	{
        Console.Write($"{item} ");
	}
    Console.WriteLine();
    Console.WriteLine("-----------------------------");
}


static void PrintUsers(List<User> collection, string name)
{
    Console.WriteLine($"Collection {name} items: ");
    foreach (var item in collection)
    {
        Console.WriteLine($"{item.FullName} - {item.Age} ");
    }
    Console.WriteLine("-----------------------------");
}

#region Generic Collections - List<>

List<int> numbers = new List<int>();//definiranje na prazna lista so 0 elementi
numbers.Add(1);
numbers.Add(10);
numbers.Add(123);
numbers.AddRange(11, 22, 32, 43, 54);//dodavanje elementi
//Remove(int number)
numbers.Remove(32);
numbers.Remove(1234);//This will not throw exeption, it will give false


PrintCollection(numbers, "List<int>");

List<string> names = new List<string>()//definirame odnapred
{
    "David",
    "Mario",
    "Klementina",
    "Dragan"
};
PrintCollection(names, "List<string>");


//List of User List of Object

List<User> users = new List<User>()
{
    new User() {Id=1, FullName="David Todorovski",Age=23},
    new User() {Id=2, FullName="Jill Wayne",Age=22},
    new User() {Id=3, FullName="Joe Doe",Age=18},

};

//Remove(User item)
users.Remove(users[2]);
users.Count();
PrintUsers(users, "List<Object>");

#endregion




#region ArrayList

ArrayList mixedArray = new ArrayList() { 1, 10, true, false, new User(), "David" };
mixedArray.Add(false);
mixedArray.Remove("David");//NotSupportedExeptions

//ne se genericki kolekcii
//Obicna kolekcija so mesani tipovi

#endregion

#region Generic Collections - Dictionary
//genericka kolekcija dve vresnosti Bara :Tip za key i Tip za Value
Dictionary<string, string> songList = new Dictionary<string, string>()
{
    { "Song1","Winds of Change"},
    { "Song2","Nothing else matters"},
    { "Song3","Living on a prayer"},

};
Console.WriteLine(songList["Song1"]);//daj mi ja vrednosta so ovoj kluc
//PrintCollection(songList, "DictionaryList");

if (songList.ContainsKey("Song3")) 
{
    Console.WriteLine(songList["Song3"]);
}
else
{
    Console.WriteLine("Key 'song3' does not exist in the dictionary");
}


bool item = songList.TryGetValue("Song3", out string songValue);
//ova kako TryParse ako se najde song3 zacuvaj ja vo songValue

if (item)
{
    Console.WriteLine($"Here you are your song: {songValue}");
}
else
{
    Console.WriteLine("Something went wront! No such song available");
}

//Podredeni parovi
Dictionary<int, string> students = new Dictionary<int, string>()
{
    {1,"David" },
    {2,"Mario" },
    {3,"Martin" },
};
PrintCollection(students, "Dictionary of students");
//[1, David] [2, Mario] [3, Martin],
//ako sakame vrednosta na poseben kluc

foreach (var student in students)
{
    Console.WriteLine($"{student.Key} {student.Value}");
}
//1 David
//2 Mario
//3 Martin

Dictionary<int, User> trainers = new Dictionary<int, User>()
{
    {1, new User(){Id=1,FullName="David Todorovski",Age=23} },
    {2, new User(){Id=2,FullName="Bob Bobsky",Age=22} },
    {3, new User(){Id=3,FullName="John Doe",Age=18} },
};


foreach (var trainer in trainers)
{
    Console.WriteLine($"{trainer.Key} {trainer.Value.FullName}");
}

#endregion


#region Generic Collections - Queue First In First Out

Queue<int> numbersQueue = new Queue<int>();
numbersQueue.Enqueue(1);
numbersQueue.Enqueue(2);
numbersQueue.Enqueue(3);
numbersQueue.Enqueue(4);
numbersQueue.Enqueue(5);

numbersQueue.Dequeue();//brisenje na prviot
numbersQueue.Dequeue();
Console.WriteLine();
numbersQueue.Peek();//go vrakja prviot po red
                    //
int firstInTheQueue = numbersQueue.Peek();
Console.WriteLine(firstInTheQueue);
PrintCollection(numbersQueue, "Queue<int>");

//.Length.Count

#endregion


#region Gereric Collection - Stack Last In First Out
//undo opcija vo word site zborovi vlagaat vo nekoj Stack
Stack<string> numbersStack = new Stack<string>();
numbersStack.Push("Bob");
numbersStack.Push("Dimitar");
numbersStack.Push("Ognen");
numbersStack.Push("Damjan");


numbersStack.Pop();//vadenje od stack znaci elementot sto go izvadivme

PrintCollection(numbersStack, "Stack<string>");
Console.WriteLine(numbersStack.Count);
Console.WriteLine(numbersStack.Peek());//sledniot sto treba da izleze utv najgore

#endregion