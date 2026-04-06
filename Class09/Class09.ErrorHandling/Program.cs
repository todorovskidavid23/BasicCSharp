using Class09.ErrorHandling.Models;
using System.Net.Http.Headers;

Console.WriteLine("Error Handling");

//error i exeption ne e ista rabota
//exeption i nivno hendlanje hendling
//nema da ima los user experience
//kje si logneme exeption na nego mu pokazuvame ubava poraka 
//so Parse puka exeption
//So TryParse resavame

//Tipovi na
//BuildTime errors Compile time ;
//za vreme na kompajliranje, safe errors nema ni da pocne da raboti;
//vednas se vidlivi vo  VisualStudio
//

//Run Time Error
//Happen while the application is running
//Can crash the program if not handled
//Usually come from logic problems
//ne poradi developer
//vo bilo koj moment na aplikacijata
//db server e padnat nie ja pristapuvame greskata moze da e do padnata baza
//runtime greska ama developerot gi hendla 
//
//log logirame vo kozolata na cmd na nasata konzolna aplikacija
//zapisuvame na poraka da imame git log 

//log files sto kazuvaat sto se sluclovo vo kolku saat
//log-6/6/2024 i si gleda sto ima vnatre

//da ne crushne aplikacijata tuku da si prodolzi

//do sega zborevme za ERRORS

//EXEPTIONS
//isklucitelna situacija da ja smenia normalnatiot tek na 
//reprezentacija na errorite , si nosi dopolnitelna data za negoviot error
//errorite prestanuvat, 
//Exeptions se objektisodrzat edtalni podatoci za gresata
//delot od tie da si gi zapiseme vo log file.
//tie mozat da se hendlaat vo kodot



//promise vo JS 
//tuka si ima try catch blok
//assynhrono programirawe async i await si gi wrapnuvame vo try catch
//finally, nezavisno kje si se izvrsi

// vo try bolot go stavame kade sto moze da se slici greska


#region Exeptions and Exeption Handling
Console.WriteLine($"------------------Example 1-------------------");
try
{
	//se sto ocekuvame da ni frli exeption ovde ide
	Console.WriteLine("Enter a number:");
	int number = Int32.Parse(Console.ReadLine());
	Console.WriteLine($"The number you entered is: {number}");


}
catch (Exception ex)//sekogas sleduva kako objekt od tip exeption site infomacii toj gi nosi
{
    Console.WriteLine($"Oops, something went wrong! Please try again later");
    //throw ex;//ne e hanle na exeption toa znaci da go Raiseneme exeption, da go fatime vo try i da go henlame vo catch
    Console.WriteLine($"--------------------------------------------------");
    Console.WriteLine($"Info for developer: {ex.Message}");
    Console.WriteLine($"{ex.StackTrace}");//tuka sve si ima si pusyva vo koja metoda imame greska 
}
finally
{
    Console.WriteLine($"-------------------Press any key to contine-------------------");
    Console.ReadLine();
}



//Custom Exeption (Exeption with our own logic)
Console.WriteLine($"------------------Example 2-------------------");
Console.WriteLine("Handling exception with custom message");

try
{
    Console.WriteLine($"Enter letter a or letter b: ");
    string letter = Console.ReadLine().Trim().ToLower();
    if(letter=="a" || letter == "b")
    {
        Console.WriteLine($"Congratulations, you have eneter a or b!");
    }
    else
    {
        throw new Exception("That is not a or b! Sorry!", new Exception($"Incorrect input '{letter}'."));//class sto ima konstruktori
        //porakata Message doagja od tuka
    }
}
catch (Exception ex)
{
    //stom kodot dojde do Throw avtomatski go forsirame da vleze vo catch 
    //throw;
    Console.WriteLine(ex.Message);
    Console.WriteLine("More info:" + ex.InnerException);
}

finally
{
    Console.WriteLine($"-------------------Press any key to contine-------------------");
    Console.ReadLine();
}

#endregion

#region Handling specific exceptions

try
{
    Console.WriteLine("Enter some character: ");
    char char1 = char.Parse(Console.ReadLine());
    Console.WriteLine($"The character you entered is: {char1}");

    Console.WriteLine("Please enter a number:");
    int number1 = Int32.Parse(Console.ReadLine());
    Console.WriteLine($"The number you entered is: {number1}");

    Person p = new Person() { Name = "David" };
    foreach (var skill in p.Skills)
    {
        Console.WriteLine(skill);
    }

    
}
catch (FormatException frmEx)//site exception nasleduvaat od ovde, ovozmozuva da agetirame konkreten tip na exeption
{
    Console.WriteLine($"You have entered something other than a character!");
}
catch(OverflowException ovEx)
{
    Console.WriteLine($"You have entered either too large or too small for integer!");
}
//sekogas
catch(Exception ex)
{
    //site tipovi nalsdeuvaat od Exception
    Console.WriteLine("Something went wrong!");
}

finally
{
    Console.WriteLine($"-------------------Press any key to contine-------------------");
    Console.ReadLine();
}

#endregion


#region Handling exceptions within a method

//Exception handling propagation (exception sent to the higher level)
// VO METODATA SEKOGAS DA PRAVIME TRY I CATCH
static void PersonSkill1(Person person)
{
    foreach (var skill in person.Skills)
    {
        Console.WriteLine(skill);
    }
}

static void PersonSkill2(Person person)
{
    try
    {
        foreach (var skill in person.Skills)
        {
            Console.WriteLine(skill);
        }
    }
    catch (Exception ex)//ovde da napravime cw ili throw
    {
        Console.WriteLine($"Catch inside the function: {ex.Message}");
    }
}



try
{
    PersonSkill1(new Person() { Name = "David" });
    PersonSkill2(new Person() { Name = "Martin" });

}
catch (NullReferenceException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine($"-------------------Press any key to contine-------------------");
    Console.ReadLine();
}






#endregion




//Exception Types
//Exception (base type – catches everything)
//FormatException//parsiranje vo char a vnesuvame dva karatera
//NullReferenceException
//ArgumentException// parametar a ne go prosleduvame
//IndexOutOfRangeException// indeks na nepostoecka niza
//And many others