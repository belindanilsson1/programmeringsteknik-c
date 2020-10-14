using System;
using System.Globalization;

namespace tgif
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en applikation som läser in ett datum via användarinmatning,
            // som sedan räknar ut hur många dagar det är till nästa fredag.
            //Svensk veckodagsräkning

            /*CultureInfo ci = CultureInfo.InvariantCulture;

            Console.WriteLine("Mata in ett datum. \tSkriv i följande format: YYYY/MM/DD");
            DateTime userDateTime = DateTime.Parse(Console.ReadLine());

            DateTime nextFriday = DateTime.ParseExact("10/16/2020", "MM/dd/yyyy", ci);

            int daysBetween = (nextFriday.Date - userDateTime.Date).Days;

            Console.WriteLine($"Antal dagar mellan det inmatade datumet och nästa fredag: {daysBetween}"); */


            DateTime date;
            while (!GetDateFromUser(out date)) ;

            DayOfWeek nextFriday = DayOfWeek.Friday;
            DayOfWeek givenDay = date.DayOfWeek;

            int daysBetween = nextFriday - givenDay;

            Console.WriteLine($"Antal dagar mellan det inmatade datumet och nästa fredag: {daysBetween}");           
        }
        static bool GetDateFromUser(out DateTime date)
        {
            Console.WriteLine("Enter a date:");
            string userInput = Console.ReadLine();

            CultureInfo culture = new CultureInfo("sv-SE");

            return DateTime.TryParse(userInput, culture, DateTimeStyles.AssumeLocal, out date);
        }
    }
}
