//LINQ
//Link mnozestvo na metodi sekoja so razlina namena
//Chain na metodi
//Raboti so IEnumerable
//Vrakja IEnumerable
//Converts using ToList();
//Query komanda za prebaruvanje na data
//Tehnika na prrebaruvanje na Data vo kolekcii

using System;
using System.Collections.Generic;
using System.Xml.Schema;
using Class08.LINQ.Models;

// Initialize a list of 10 different students with varying properties
var students = new List<Student>
{
    new Student(1, "Alice", "Smith", 22, "G1", Academy.WebDev, new List<string>{ "BasicCSharp", "AdvancedCSharp", "BasicJS" }),
    new Student(2, "Bob", "Johnson", 24, "G2", Academy.FrontEnd, new List<string>{ "HTML/CSS", "JS", "Figma" }),
    new Student(3, "Carol", "Williams", 21, "G3", Academy.Design, new List<string>{ "Figma", "Photoshop", "Basic HTML/CSS" }),
    new Student(4, "David", "Brown", 23, "G4", Academy.WebDev, new List<string>{ "BasicCSharp", "AJS", "AdvancedCSharp" }),
    new Student(5, "Emma", "Davis", 20, "G1", Academy.FrontEnd, new List<string>{ "HTML/CSS", "JS" }),
    new Student(6, "Frank", "Miller", 25, "G2", Academy.Design, new List<string>{ "Photoshop", "Figma" }),
    new Student(7, "Grace", "Wilson", 19, "G3", Academy.WebDev, new List<string>{ "BasicJS", "AJS" }),
    new Student(8, "Henry", "Moore", 26, "G4", Academy.FrontEnd, new List<string>{ "HTML/CSS", "Figma", "JS" }),
    new Student(9, "Isla", "Taylor", 22, "G2", Academy.Design, new List<string>{ "Basic HTML/CSS", "Figma" }),
    new Student(10, "Jack", "Anderson", 27, "G1", Academy.WebDev, new List<string>{ "AdvancedCSharp", "BasicCSharp" })
};

Student david = students
                    .Where(x => x.FirstName == "David")
                    .First();


//deka akademijata ni bese Enum
Console.WriteLine($"{david.FirstName} {david.LastName} - {david.Academy.ToString()}");
//tip IEnumerable<Studnet> zada bide lista treba .ToList();

//First()
//Where()
var allWebDevStudentsFromG1 = students
                                .Where(x => x.Academy == Academy.WebDev && x.Group == "G1")
                                .ToList();

foreach (var std in allWebDevStudentsFromG1)
{
    Console.WriteLine($"{std.FirstName} {std.LastName} - Academy: {david.Academy.ToString()} Group: {std.Group}");

}


//Last()
var lastStudent = students.Last();
Console.WriteLine($"{lastStudent.FirstName} {lastStudent.LastName}");

//lista na predmeti da se sekectita IEnumerable za toa ToList();
var frankSubjects = students
                    .Where(x => x.FirstName == "Frank")
                    .Select(x => x.Subjects)
                    .First();//otpakuvame list u list samo da bide list prv vo listata
foreach (var sub in frankSubjects)
{
    Console.WriteLine(sub);
}


//a e anonymous
var customSelection = students
    .Where(x => x.FirstName == "Carol")//ako stavime nesto sto nema togas koristime FirstOrDefault() za da ne pukne exeption
    .Select(x => new
    {
        FullName = $"{x.FirstName} {x.LastName}",
        //Subjects = x.Subjects//Nashe ime=x.Subjects
        x.Subjects
    }).FirstOrDefault();//anonimen objekt//null e default// Queryto da ne ni pukne da si KORISIME FirstOrDefault()
//SingleOrDefault() koga sme sigurni deka ima samo edno primer da filtrirame fo Id


Console.WriteLine(customSelection.FullName);
foreach (var sub in customSelection.Subjects)
{
    Console.WriteLine(sub);
}



// Optional: print students to console to verify
//foreach (var s in students)
//{
//    Console.WriteLine($"{s.Id}: {s.FirstName} {s.LastName}, Age: {s.Age}, Group: {s.Group}, Academy: {s.Academy}, Subjects: {string.Join(", ", s.Subjects)}");
//}


