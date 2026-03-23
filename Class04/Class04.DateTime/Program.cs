#region Working with Dates

//e tip// date time e class ili vo nas slucaj e STRUKTURA ama e slicno na klasa;
//Creating an empty date time;
using System.Globalization;

DateTime date = new DateTime();
Console.WriteLine(date);

//Creating custom date YEAR MONTH DAY
DateTime customDate = new DateTime(2002, 06, 07,12,30,15);
Console.WriteLine(customDate);

//Converting from string to DateTime
//Variations

//day mothy year
string stringDateFirst = "15.12.2012";
string stringDateSecond= "15/12/2012";
string stringDateThird= "15/12/12";
string stringDateFourth = "dec.15.12";
string stringDateFifth = "15-12-12";
//                        day-month-year;


DateTime stringDate = DateTime.Parse(stringDateFourth);// ne saka zatoa sto serverot kako e podesen taka raboti
Console.WriteLine(stringDate);



DateTime today = DateTime.Now;
Console.WriteLine(today);

Console.WriteLine(today.AddDays(2));
Console.WriteLine(today.AddDays(-2));

//komplesen tip ako klikneme .
//kocka i kluc
//klucovite se properties kako Lenght
//kocki se methodi
//
Console.WriteLine(today.Day);
Console.WriteLine(today.Date);
Console.WriteLine(today.DayOfWeek);
Console.WriteLine(today.Month);

//na tema toString
//

string dateFormat1 = today.ToString("MM/dd/yyyy");//shablon pattern kako da go generira datumot
string dateFomrat2 = today.ToString("dddd, dd MMMM yyyy",CultureInfo.GetCultureInfo("en-US"));
Console.WriteLine(dateFormat1);
Console.WriteLine(dateFomrat2);








#endregion