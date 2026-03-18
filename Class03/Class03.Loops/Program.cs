
//#region Loops - For


//Console.WriteLine("For loop - first");
//for(int i=0; i<10; i++)
//{
//    Console.WriteLine("Iteration no. "+i);
//}

//Console.ReadLine();//hack kako da se zakoci app

//Console.WriteLine("For loop - second");
//for(int i=10; i>0; i--)
//{
//    Console.WriteLine("Iteration no. "+i);
//}

//Console.ReadLine();

////Infinit for loop
//Console.WriteLine("Infinite for - loop");
////for(; ; )
////{
////    Console.WriteLine("This will go on forever");
////}

//// Loops indefinitely unless a condition in the block is met

////vo binaries se koristi zad ase izvrsi 
////.dll file iskomajliran kod
////Application si ja dava aplikacijata exe fileot//////

////kako da go koristime korisnikot vo loop se dodeka on iksplicitno ne kaze koga da zavrsi

//for (; ; )
//{
//    Console.WriteLine("This will go on forever until you enter X or x !");
//    string input = Console.ReadLine();
//    if(input=="X" || input == "x")
//    {
//        break;
//    }
//}


//Console.WriteLine("Creating a droid army");

//for (int i = 1; i < 10; i++)
//{
//    Console.WriteLine("Assembling Droid Batalion "+i);
//    Thread.Sleep(1000);//miliseconds ova e kako SetTimeout metodot
//    if (i == 5)
//    {
//        Console.WriteLine("Problem in assembling the Droid batalion "+i);
//        continue;//kje prodolzi na sledna iteracija i++
//    }
//    if (i == 7)
//    {
//        Console.WriteLine("Droid assembler broke down!");
//        break;
//    }
//    Console.WriteLine("Droid Batalion "+i+ " is operational");
//}

//#endregion


//#region Loops - While
//Console.ReadLine();
////counter e prvo do kade kje trae loop
//int count = 0;
//Console.WriteLine("While Loop");
//while (count<=10)
//{
//    Console.WriteLine(count);
//    count++;
//}

//Console.ReadLine();

//while (true)//se dodeka e tocno neka vrti vnatre
//{
//    Console.WriteLine("This will go on forever until you enter X or x !");
//    string input = Console.ReadLine();
//    if (input == "X" || input == "x")
//    {
//        break;
//    }
//}


////Create a droid army with while

//Console.WriteLine("Creating a Clone army:");
//int droidCounter = 1;
//while (droidCounter <= 10)
//{
//    Console.WriteLine("Cloning Clone Batalion" + droidCounter);
//    Thread.Sleep(2000);//SetTimeout si ceka 2 sekundi pred da prodolzi;
//    if(droidCounter == 5)
//    {
//        Console.WriteLine("Problem in cloning Clone Batalion "+ droidCounter);
//        droidCounter++;
//        continue;
//    }
//    if (droidCounter == 7)
//    {
//        Console.WriteLine("Cloning machine broke down!");
//        droidCounter++;//hover unnecessary assignment
//        break;
//    }
//    Thread.Sleep(2000);//SetTimeout si ceka 2 sekundi pred da prodolzi;

//    Console.WriteLine("Clone Batalion " + droidCounter + " is operational!");
//    droidCounter++;
//}

//#endregion



#region Loops Do-While

//barem ednas kje se izvrsi
Console.ReadLine();
int doWhileCount = 0;
Console.WriteLine("Do-While loop");
do
{
    Console.WriteLine(doWhileCount);
    doWhileCount++;
}while(doWhileCount<10);

do
{
    Console.WriteLine("This will be executed once!");
} while (false);

#endregion