//manipulacija so baza,
//nacin na strukuriranje na podatoci
//rabota so podatoci
//potreba od povekje podatocni server
//nacin na organiziranje na podatocite
//Denes najkoristeni za koristenje na podatoci se database kolekcii na podatoci strukutirani na odreden nacin

//
//Databazi ne se sistemi
//bazite na podatoci imame mnogu tipovi, a so toa imame povelje provideri i pristapi kon niv
//raslicen pristap kon bazata i razlicni podatocni bazi,
//zavisi sto gradime,

//WEB DVELOPMENT
//Storaged sistemi
//Client server komunikacija
//font end Korisnikot
//se pusta povik kon web server, backend povikuva daj mi gi site naracki
//bakend SQL jazik si komunicira, serverot gi pakuva i si se prakjaat nazad,
//Kja bazite spored strukturite imame
//relacioni i nerlaciion bazi na podatoci
//relacioni bazi se strukturirani bazi vo smisla se kako data ima vo niv si imaat tabeli ima RELACIJA,
//Podelena vo megjusebno povrzani
//sekoja Koloni i od redici
//Edna tabel moze da bide user naaracka produkt, customer, Objekt vo backend
//kolonite se properties Ime,Prezime,BirthDate, RELACIONI deka se vo relacija
//ID i title na post,
//id na komentar i id na 


//Neraliocni bazi ne se strukturirani vo tabeli, DOCUMENT DATABASE
//json mongo Db e primer
//Pridobivki imame zapis id title i niza od komentari
//Pomalku strukturirani ama pofleksibilni
//nemam tabli imame zapisi za tablei
//nemame ogranicuvanje nemame klucevi foreigh klucevi itn.
//43345 / Sneakers / 60$ / 11
//Product Id / Name / Price / In Stock


//RDBMS RELATIONAL DATABASE MANAGEMENT SYSTEM
//predefinirani semi // dynamic
//non hierarchical//hierarchical
//complex queries//not
//vertically// horizontally

//1
//STO SE BAZI NA PODATOCI
//sistemi koisto ima strukturirani bazi na podatoci

//2
//Sto e sql
//nacinot na koj nie komunicirame , zacuvuame briseme od baza
//menadzira relational bazi, se pravi query za dodavanje brisenje update
//sql si ima IDE sintaksa semantika
//DATABASE MENAGMENT SISTEMI MNOGU VAAZNI
//Podobra integracija,sql kako query language e osnova na kucanje na bilo koja baza
//si ima svoj layer so nekoj dopolnitelni komandi Extension
//karakterisnicni samo za sql server
//eden od DMBS Microsoft SQL server
//TSQL Transact SQL
//MYSQL databasemenagementsystem na Oracle 
//Postgre SQL lite opensource i se free

//vopoazdinata da raboti da ima relacii da imame tabeli
//ne ni obezbeduva IDE kaj da go pravime toa, IDETO e SSMS SqlServerMenagmentStudio
//Micorosf sql server e sistemot kaj sto go gradime sistemot
//SSMS kreirame
//A BAZA VO STO IMAME bazata mi e MicosoftsqlServer OracleDatabase SISTEMOT STO GO KORISIME
//IDE ALATKI MILION visualstudio,Dbiver, PgAdmin
//moze da bide server na baza skriptata moze da zivee a se ranuva vo browswe,
//databasemenagment sistem za da raboti// mora da se naogja vo server
//BAZATA TREBA DA E NA SERVER i site da znaat da se vrzat na nasata baza

//Site DataBasemenagmentSystemi vo pozadina krevaat server sto e lokalen
//micosoftsql server i lokalno baza i da se povrzemen kon drug server
//dve edicii na SQL server i EXPRESS 

//Structured Query Language - programski jazik
//Database provideri i sto se Database menagment sistem

//Features
// databazite supports data types 
// treba da imame isti data types
// set od supported data types sto kje se definiraat koga kreirame baza
// od to opseg
//small int ili int bazata se opetretuva memoriski
//vo baza e bitno dek optovaruvame memoriski
//tipovi sto go kreirame
//boolean e bit 1(true)/0(false) or NULL
//od tip bit
//tinyint 1bytes integer
//smallint 2bytes
//int 4
//bigint 8
//date only date
//datetime
//nchat/char bez char ne mozeme ! % $ specialen karakter (a,z) nchar specijalni
//nvarchar/varchar STRING bez specijalni varChar ama , mobilen telefon so string varchar


//ni cuvaat razlic tipovi na databazi
//2tipa 
//relacuioni podatocite relacioni sturkuritani podatoci vo tablei
// imeto na relacioni bazi tableite moze da vidat vo nekakva relacija pokompleksna data poogranizirana flekisiblni
//po fleksibilni, vo dokumneti JSON struktura se koristat za situacija da nemame ralacija
//POFLEKSIBILNO DA SI POSTAPAT relacija ama si ima niza na podatoci HIERARHISKA STRUKURA


//databasemenagment system ne mozeme da imame baza
//micosoft sql server my sql
//da manipulirame ni trebaat 2 raboti
//Sql da znaeme i ID Server managment Studio

//data tipovi
//SQL e osnova na site a vrz sql si ima exstenions sto se karakterisicni samo za tie bazi
//Trancast SQL


//?Volatile services

//imeto na pc \SQLEXPRESS i velguvas so sertifiavte

//ZA DA RABOTI SI GI IMA OVIE CUSTOM BAZI master, model itm
//dropdown

//USE [master]
//GO
//koga kreirame baza
//programiranje na baza
// sigurni deka sme na master
//deka sme na master baza mora da sme sigurni deka sme vo master
//USE [master]
//GO
//CREATE DATABASE[DemoDb]
//GO

//sql mira da selekcirame sto kje se izvrsi
//Go osiguruvanje da se izvrsi 
//na ist server ne moze dve bazi so isto ime


//VO DemoDb
//database diagrams,tabeli, views, external resources, synonymus

//mora da sme sigurni mora da go napravi istoto bez da failne ,za da se osigurame
//ako postoi takva baza so takvo ime ne kreiraj ako ne kreiraj
//USE[master]
//GO

//IF EXISTS (SELECT name FROM sys.databases WHERE name= 'DemoDb')
//CREATE DATABASE [DemoDb]
//GO


//USE [master]
//using System.Diagnostics.Metrics;
//using System.Xml.Linq;

//GO

//--IF EXISTS (SELECT name FROM sys.databases WHERE name= 'DemoDb')
//--	ALTER DATABASE [DemoDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
///* 
//  promeni ja databazata sto kje ogranican na eden sigle user do nea
//  kje ogranicime eden user do bazata posle nego sakame da izvrsime komanda
//*/
//--GO

//--USE [Master]
//--GO

//--DROP DATABASE IF EXISTS [DemoDb]
//--delete na bazata ako postoi
//--GO

//CREATE DATABASE [DemoDb]
//GO
//--site querynja da se apliciraat na DemoDb

//USE [DemoDb]
//GO
//USE [master]
//GO

//--IF EXISTS (SELECT name FROM sys.databases WHERE name= 'DemoDb')
//--	ALTER DATABASE [DemoDb] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
///* 
//  promeni ja databazata sto kje ogranican na eden sigle user do nea
//  kje ogranicime eden user do bazata posle nego sakame da izvrsime komanda
//*/
//--GO

//--USE [Master]
//--GO

//--DROP DATABASE IF EXISTS [DemoDb]
//--delete na bazata ako postoi
//--GO

//CREATE DATABASE [DemoDb]
//GO
//--site querynja da se apliciraat na DemoDb

//USE [DemoDb]
//GO
