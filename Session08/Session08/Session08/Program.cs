using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Session08
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instansiera en kollektion av typen StringCollection
            StringCollection collection = new StringCollection();

            //Lägga till strängar i kollektionen
            collection.AddString("this is a string");
            collection.AddString("this is another string");

            string firstEnteredString = collection.GetString(0);

            //Komma åt data i List. (get, set)
            string firstStringViaArray = collection[0];

            //Instansiering av IDictionary, typen StringDictionary
            StringDictionary dictionary = new StringDictionary();

            dictionary.AddString("duck", "anka");
            dictionary.AddString("horse", "häst");

            bool dictionaryContainsKey = dictionary.ContainsKey("duck");
            bool dictionaryDoesntContainKey = dictionary.ContainsKey("dog");

            string valueForKeyDuck = dictionary.GetValue("duck");

            List<string> genericStringList = new List<string>();

            //Komma åt data på index
            string value = genericStringList[0];

            foreach (string genericValue in genericStringList)
            {
                //Chans att behandla varje värde
            }

            IEnumerator enumerator = genericStringList.GetEnumerator();
            while(enumerator.MoveNext())
            {
                // nuvarande värde
            }

            //Om man har en ICollection kan man hämta index, jobbar med arrayindex
            for (int i = 0; i < genericStringList.Count; i++)
            {
                string currentValue = genericStringList[i];
            }

            int currentIndex = 0;
            
            // För att hämta från en yield-metod, jobbar med värden
            foreach (string item in collection.GetItems())
            {
                // Behandla nuvarande värde
                currentIndex++;
            }
            //Får ny genom att skriva new.
            var firstPerson = new Person { Name = "Sven-Erik" };
            var secondPerson = new Person { Name = "Sven-Erik" };

            secondPerson.Name = "Patrik";

            var thirdPerson = new Person { Name = "Jens" };
            //Bara pekare.
            var fourthPerson = thirdPerson;

            fourthPerson.Name = "Sanna";
        }
    }
}
