//Console.WriteLine("Hello from Class07");


//sposobnosta da nekaspuliras vo edna celina da prikazes
//create customer
//create customer 
//withdra

//Inheritance za construktori
//koga nasleduvame tohas i parentot go nasleduvame
//
//TREBA DA ZNAEME
//inheritance,enkapsulacija,apstrakcija, polimofrziam
//

//od OOP poteknat C++ C# JAVA
//sposobnosta na eden objekt da gi ima atributite na edna parent klasa
//protorype based, Classes based
//benefits, idejata e da si pomogneme da go resikoristime kodot, DA RESIKORITUVMAe
//parent class i dopolnitelno da si nadleduvaat od nea
//sekoj si ima svoi karakteristiki igi nalsleduva od parent clasata
//da te trgne od pogeneralno do pospeficino

//Organiziranje na entitetite od general to specific
//povekje entiteti moze da nasledi od istata parent class
//od edna klasa moze da nasledat od edna klasa 
//VO C# ne moze da se naldei od 2 razlicni Klasi//MNOGU VAZNO
//SAMO OD EDNA KLASA DA SE NASLEDI


//Child class can override parent methods
//constructor can be chained



//specijalen metod KONSTUIRA OBJEKT OD TAA KLASA

//overload constructori


//ovverroad povekje metodi razlicni metodi
//overide ista metoda razlicna metoda

using Class07.Inheritance.Models;
//OBject initializer
Animal elephant = new Animal()
{
    Id = 1,
    Name = "Dambo",
    Type = "Elemphant"
};
elephant.PrintInfo();
elephant.Eat();
Console.WriteLine("--------------------------------");//se povukiva defualt construcotor


Dog dog = new Dog()
{
    Id = 2,
    Name = "Spikey",
    Type = "Dog",
    Race = "Labrador",

};
dog.PrintInfo();
dog.Eat();
dog.Bark();
Console.WriteLine("--------------------------------");//se povukiva defualt construcotor


Cat cat = new Cat()
{
    Id = 3,
    Name = "Garfield",
    Lazyness = "Very"
};

cat.PrintInfo();
cat.Eat();
cat.Meow();



Console.WriteLine("--------------------------------");//se povukiva defualt construcotor


//MOrame vo konstruktorot da piseme
//Parrot riki=new Parrot()//ovoj vonstrukot na parrot ocekuva ID ima eden konstruktor
//{
//    Id=4,
//    Name="Riki"
//}

Parrot riki = new Parrot(4, "Riki", "Parrot", "Blue");

riki.PrintInfo();
riki.Fly();
riki.Eat();

Console.WriteLine("--------------------------------");//se povukiva defualt construcotor


Parrot miki = new Parrot()//vaka samo za prazen konstruktor
{
    Id = 5,
    Name="Miki",
    Type="Parrot",
    Color="Yellow"
};
miki.PrintInfo();
miki.Fly();
miki.Eat();
Console.WriteLine("--------------------------------");//se povukiva defualt construcotor

//predefinirani integer vrednosti vo tekstualen prikaz
//setovi sto se predefinirani integer vresnoti vo tekstualen prikaz