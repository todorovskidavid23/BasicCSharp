//se e wrap vo edna class za da se koristi kako objekt

//Osnovna celina na C# mozeme da pravime aplikacii 
//access modifiers

//OOP znaci programaska paradigma na organizacija na kodot preku povrzuvanje so realniot svet okolu nas
//so pomos na objekti
//CLasses based se sto gradime e izgradeno so pomos na nekoj objekt kreiran od nekoja klasa
//se izgradeni od building blocks od bjekti sto pripagjaat na edna klasa
//se sto pravime se mapira na edna klasa so pravime objekti

//clasite se sabloni za ponatamu istanciranje na novi objekti
//koficka so pesok
//taa kula e dzvezda
//vo klasite imeme//properties sto se data na klasata
//vrednostite ni gi cuvaat
//methodite se behavior odneuvanjeto taa data na nivo na klasata moe da pravi nesto 
//NE MOZE NITU METODITE NITU PROPERTIRS NE MOZE DA SE KORISTAT SE DODEKA NE SE NAPRAVI OVJEKT OD TAA KLASA


//access modifiers se keywords koisto ni odlucuvaat za kakov access kje bide na dadena klasa ovjekt metod

//public, private, protected, internal//

//zavisi koga se koristat kakva arhitektura ima aplikacijata

//klasa po klasa nikako klasa vo klasa

//top level statments


#region Classes Definition
using Class05.Classes.Models;
using System.Runtime.CompilerServices;


//Create a Person Object using the parameterless constructor and set properties manually;
//OBjekt od klasata person



Person david = new Person();
david.FirstName = "David";
david.LastName = "Todorovski";
david.Age = 23;
david.Hobbies = new string[] { "Basketball", "Reading books" };
//["reading"]
david.IsStudent = false;

Console.WriteLine($"{david.FirstName} {david.LastName} and SSN:({david.GetSSNValue()})");
Console.ReadLine();

//na STRING DEFUALT VREDNOST E NULL// PAMTI;


//NIKOGAS VO PROGRAM CS NE SE KREIRAAT
//POSEBEN FOLDER OVJEKTITE
//MI MODELIRA NOV PERSON
//

//na nivo na program cs nema person the tpye or namespace treba da 

//Create a Person Object using the objekct initializer syntax;

Person bob = new Person()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 23,
    PhoneNumber = "0777777777",
    Hobbies = ["Running", "Listening to music"],
    IsStudent = true
};

Console.WriteLine($"{bob.FirstName} {bob.LastName} is {bob.Age} years old!");
Console.ReadLine();


//Create a Person 
//prazen ili so site tie raboti
Person jill = new Person("Jill", "Wayne", "077/123-456", 28, [], true);
Console.WriteLine($"{jill.FirstName} {jill.LastName} is {jill.Age} years old");
Console.WriteLine(jill);


Person test = new Person("david");
Console.WriteLine(test.FirstName);

Console.WriteLine(test);

jill.Talk("Hello there nice to meet you!");
//jill.SSN//unikatno e ne moze da se proveri zatoa sto vo class ssn e private
jill.GetSSNValue();


#endregion



#region Working with classes

Group g1 = new Group("G1", 12, "Basic C#");
Group g2 = new Group("G2", 18, "Web development using NodeJS");

Student mario = new Student("Mario Simonovksi", 34, g1);
Student dimitar = new Student("Dimitar Kocevski", 19, g1);

Student tomi = new Student("Tomi Tomi", 36, g2);

Student ivo = new Student("Ivo Kostovski", 36, new Group("G3", 10, "HTML/CSS"));//na lice mesto pravime Group 
Student cvetko = new Student("Cvetko Cvetkovski", 35, new Group
{
    GroupName = "G3",
    NumberOfStudents = 10,
    CurrentSubjectName = "HTML/CSS",

});

//ne moze da kreiras nov ovjekt so initializer koga ideme vo gropu klasata imame samo eden konstruktor default const iamame sve,
//ako pravime cost so x proeprties i da istancirame objekt bez da MORA PRAZEN KONSTRUKTOR
//AKO CUSTOM IMA OBJEK BEZ DA KOTISTIME KONSTRUKTOR TOJ GO KOTISTI DEFAULT

mario.DisplayStudentInfo();
dimitar.DisplayStudentInfo();
tomi.DisplayStudentInfo();
ivo.DisplayStudentInfo();
cvetko.DisplayStudentInfo();


Student filip = new Student("Filip Mihajlovski", 27, null);//defult tip na complex type NULL E TIP
filip.DisplayStudentInfo();



#endregion


#region Exercise1




#endregion