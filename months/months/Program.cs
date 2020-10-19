using System;
using System.Globalization;

namespace months
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv ett program som tar en emot inmatad siffra (1-12)
            // och konverterar siffran till ett månadsnamn på svenska
            // programmet skall kasta ett fel om den inmatade siffran är något annat än 1-12.

            

            Console.WriteLine("Vänligen skriv in ett tal mellan 1-12.");
            int userInput = int.Parse(Console.ReadLine());

            
            switch (userInput)
            {
                case 1:
                    userInput.ToString("Januari");
                    Console.WriteLine($"{userInput}");
                    break;
                case 2:
                    userInput.ToString("Februari");
                    Console.WriteLine($"{userInput}");
                    break;
                case 3:
                    userInput.ToString("Mars");
                    Console.WriteLine($"{userInput}");
                    break;
                case 4:
                    userInput.ToString("April");
                    Console.WriteLine($"{userInput}");
                    break;
                case 5:
                    userInput.ToString("Maj");
                    Console.WriteLine($"{userInput}");
                    break;
                case 6:
                    userInput.ToString("Juni");
                    Console.WriteLine($"{userInput}");
                    break;
                case 7:
                    userInput.ToString("Juli");
                    Console.WriteLine($"{userInput}");
                    break;
                case 8:
                    userInput.ToString("Augusti");
                    Console.WriteLine($"{userInput}");
                    break;
                case 9:
                    userInput.ToString("September");
                    Console.WriteLine($"{userInput}");
                    break;
                case 10:
                    userInput.ToString("Oktober");
                    Console.WriteLine($"{userInput}");
                    break;
                case 11:
                    userInput.ToString("November");
                    Console.WriteLine($"{userInput}");
                    break;
                case 12:
                    userInput.ToString("December");
                    Console.WriteLine($"{userInput}");
                    break;
                default:
                    Console.WriteLine("Nu har du matat in fel.");
                        break;

            }
        }
    }
}
