using ASP.NET.Core.MVC.Database.Class09.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Core.MVC.Database.Class09.DataAccess
{
    public class DemoDbContext : DbContext
    {
        //ovaa  klasa ni e DbContext mozeme da pocneme da ja pocneme celata konfifuracija na baza
        //koi kje ni bidat tabeli
        //DbSet e kolekcija od objekti so pomos na DbSet mu kazuvame koj domain da stane tabela
        //imeto na tabelata so pomos na to DbSet prima cel objekt prima domanski model i so pomos na tjo db set NE SE VNESUVAAT RACNO, racno se dopolnuva ako sakame plus property
        //avtomatski se mapirat od domanski modeli si se kreiraat tabeli
        //za sekoj domanski modeli ni treba posevna tabela
        //za da se kreira kako kje znae kade kje se kreira ni treba CONEKCISKI STRING koja baza kje ni ja pinga
        //imame sqlexpress kako kje znaeme od koja od Serverite da se kreira ni treb konekciski string <U DAVA PAREKA NA EF KADE DA SE KREIRA BAZA I DAVA IMETO NA BAZATA
        //SE TOA SE PRAVI PREKU KONEKISKI STRING
        //TOJ SE PISUVA VO KOFIGRACIJA NE SE PISUVA VO DBCONTEXT
        //VO appsettings.json tuka se gradi patekata kade sto treba da ne odnese
        //od kade kje znae DemoDbContext  ni treba Constructor i da zeme od vekje postoecka kalsa dvOptions preku opstions kje prima site konfiguracii 
        //PRVO NESTO STO PRAVIME E COBTRUCTOR

        public DemoDbContext(DbContextOptions options) : base(options){}
        public DbSet<Student> Students { get; set; }//kje zemame i zapisuvame vo baza //sekoe property kje ni bide kolona a imeto na tabelata e Students
        public DbSet<Course> Courses { get; set; }//domanksi model vo tabela

        //onmodelcreating e postoecka metoda vo dbcontext samo praviem override nie mozeme da gi menuvame site poperties i da pravime nekoi logiki
        //mozeme na porpertyo mozeme da mu dodademe relacii, maxlength, DOPOLNITELNI KOMANDI DA SE SMENI DOKOLKU E POTREBNO

        protected override void OnModelCreating(ModelBuilder modelBuilder)//sekoe porperty se znae site entiteti se vo ModelBuilder da si vleze vo dirst nae i da mu dademe maxlength primer
        {
            List<Course> courses = new List<Course>()
            {
                new() { Id = 1, Name = "C# basic", NumberOfClasses = 40 },
                new() { Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
                new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
                new() { Id = 4, Name = "ASP.NET Mvc", NumberOfClasses = 40 }
            };
            var students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-27),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jilski",
                    DateOfBirth = DateTime.Now.AddYears(-37),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-45),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-17),
                    ActiveCourseId = 4
                },
            };

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Student>().HasData(students);
            base.OnModelCreating(modelBuilder);//da gi zeme site  so pomos na ova nie mu kazuvame zemi gi site podatoci koi sto gi imame site podatoci da gi kreiras + da se dodadat ZEMI GI SITE STVARI OD DOMANSKITE MODELI dokolku jas sakam da override nad neg pravime override i so pomos na base.OnModelCreating + zemi si gi site preostanati od Domainski Modeli
        }


        //
    }
}
