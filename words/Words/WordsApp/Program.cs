using System;
using System.Linq;

namespace WordsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en konsolapplikation som tar emot en skriven text.

            // Vi vill ha ut följande:
            // Antal ord?
            // Antal vokaler?
            // Vilket det längsta ordet är?

            // Word count
            // Vowel count
            // Longest word
            Console.WriteLine("Enter a string, preferrably containing a sentence.");

            char[] vowels = new char[] { 'a', 'o', 'e', 'i', 'u', 'y', 'å', 'ä', 'ö' };

            string enteredString = Console.ReadLine;
            string lowercaseString = enteredString.ToLower();

            string[] words = lowercaseString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int vowelCount = 0;
            int wordCount = words.Length;
            string longestWord = string.Empty´;

            foreach (var word in words)
            {   
                (var character in word)
                {
                    if (vowels.Contains(character))
                    {
                        vowelCount++;
                    }
                }
            
                if (word.Length)

                {

                }
            }

            for (var i = 0; i < myTestString.Lenght; i++)
            {

            }
            vowels.Contains();

                Console.WriteLine("Word count: " + wordCount);
                Console.WriteLine("Vowel count:" + vowelCount);
            Console.WriteLine("Longest word: " + )
        }
    }
}
