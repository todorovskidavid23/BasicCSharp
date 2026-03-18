////strukturi povekje kolekciski strukturi
////tipovi na kolekcii 
////eden od ovie tipovi na kolekcii kako i se  drugo array e strick 
////NOV TIP Array e tip varijablata sto e od tip niza
////niza on integeri STRIKNO samo niza od int.
////nizata e per type 
////Stricly type.
////deklaracija na nizi vo c# kolku elementi da ima niza
////oop za bak end
////Nizite se kolekcii ako sakame da prosirime 
////
////Propery na nizata se:

//#region Arrays

////Declaration of an arrat in C#
////niza on integeri imeto= new arraySize or array initializer;
//using System.Collections;

//int[] emptynumbersArray = new int[3];

////Initializing of array elements
//emptynumbersArray[0] = 1;
//emptynumbersArray[1] = 10;
//emptynumbersArray[2] = 20;

////Cannot add new element on non existing index this will throw IndexOutIfRangeException 
////emptynumbersArray[3] = 50;//IndexOutIfRangeException;

//Console.WriteLine(emptynumbersArray);//type of variable System.Int32

//for (int i = 0; i < emptynumbersArray.Length; i++)
//{
//    //PascalCase L
//    //CammileCase malaGolemaBukva
//    int novo = emptynumbersArray[i];
//    Console.WriteLine(novo);
//}


////eleganten nacin na defininarnje na niza
////ako imame tri tocki znaci moze nesto na pokratok nacin da napravime 
//string[] names = new string[]
//{
//    "Martin",
//    "Mario",
//    "Dimitar",
//    "Ognen",
//    "Damjan"
//};

//double[] decimalNumbers = [10.2, 20.4, 100.12];


//foreach (string name in names )
//{
//    Console.WriteLine(name);
//}
//foreach (double number in decimalNumbers)
//{
//    Console.WriteLine(number);
//}


////var e placeholder za bilo koj tip

////MIXED ARRAY
////Ways of AVOID AND DON't USE THIS;
//var mixedArrayValues = new object[] { 1, 1.1, true, "David" };//pravam objekt od ovaa klasa// STRUKTURI
//ArrayList mixed = new ArrayList { 1, 1.1, true, "David", "Todorovski" };
//#endregion


//int[] array = new int[5];


//#region Array Methods

//int[] evenNumbers = new int[] { 2, 4, 6, 8, 10,2,4 };

////Reverse the array elements;
//Array.Reverse(evenNumbers);

//Console.WriteLine("Array of even numbers after reverse");
//foreach (var num in evenNumbers)
//{
//    Console.WriteLine(num);
//}

////da mu se najde indexot

//int indexFound = Array.IndexOf(evenNumbers, 2);
//Console.WriteLine("The index of number 2 is "+indexFound);//na prvata 2ka prvo pojavuvanje na elementot na nizata


//#endregion


#region Array Resize method using example use case

//dalu sakas da vneses novo ime vnesi ime,ako pises n kraj

string[] usernames = new string[0];

do
{
    Console.Clear();//nad nego e na nekoj nacin KOMENTIRANO
    Console.WriteLine("Please enter a username:");
    string userInput = Console.ReadLine();

    Array.Resize(ref usernames, usernames.Length+1);//na sekoja iteracija ide +1 nizata e so 1 posle
    usernames[usernames.Length - 1] = userInput;//0+1 =1 na pozicija 1-1=0 dodadi go toa sto go vnel userot;

    Console.WriteLine("Do you want to insert another username? y/n");
    userInput = Console.ReadLine();


    if (userInput == "n" || userInput == "N")
    {
        break;
    }

} while (true);

foreach ( var username in usernames)
{
    Console.WriteLine(username);
}


int[] test = new int[] { 1, 2, 3, 4, 5 };

Array.Resize(ref test, 10);//vtoriot parametar e nov SIZE NA NIZATA;

test[5] = 10;
test[6] = 10;
test[7] = 10;
test[8] = 10;
test[9] = 10;

//niza od niza
//[[1,2],[1,2],[1,2]]
int[][] arrayOfArrays = new int[][]
{
    new int[]{1,2},
    new int[]{1,3},
    new int[]{1,2},
};

#endregion