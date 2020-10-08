using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konvertera det inmatade värdena från strängar till siffror
            // Resultatet skall presentera:
            // Lägsta värdet
            // Högsta värdet
            // Medelvärde (snitt)
            // Programmet skall vara felhanterat
            // Felaktiga värden får inte påverka medelvärde, lägsta eller högsta.

            double sum = 0;
            double average = 0;
            double lowestValue = double.MaxValue;
            double highestValue = double.MinValue;
            int ParsedOk = 0;

            Console.WriteLine("Ange ett antal siffror, separerat med kommatecken.");
            var input = Console.ReadLine();
            var inputArray = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            double?[] numberArray = new double?[inputArray.Length]; 


            for (int i = 0; i < inputArray.Length; i++)
            {
                bool parsed;
                
                try
                {
                    double parsedValue = Convert.ToDouble(inputArray[i]);
                    numberArray[i] = parsedValue;
                    parsed = true;
                    ParsedOk++;

                    if (parsedValue > highestValue)
                    {
                        highestValue = parsedValue;
                    }

                    if (parsedValue < lowestValue)
                    {
                        lowestValue = parsedValue;
                    }
                }

                catch (Exception)
                {
                    numberArray[i] = 0;
                    parsed = false;
                }

                if (parsed == false)
                {
                    continue;
                }

                sum += numberArray[i].Value;
            }

            average = sum / ParsedOk;

            Console.WriteLine($"Det totala värdet är {sum}");
            Console.WriteLine($"Högsta värdet är {highestValue}");
            Console.WriteLine($"Lägsta värdet är {lowestValue}");
            Console.WriteLine($"Medelvärdet är {average :f1}");
        }
    }
}
