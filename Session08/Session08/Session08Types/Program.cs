using System;
using System.Collections.Generic;

namespace Session08Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "This is a string value";

            // Utvärderas när man kompilerar
            Type myStringType = typeof(string);

            // Utvärderas när man kör programmet
            Type myStringTypeViaReflection = myString.GetType();

            

            // Jämför om det är exakt samma datatyp.
            if (myStringType == myStringTypeViaReflection)
            {

            }

            //Tar med arv i jämförelsen, jämför och tar hänsyn till arv.
            if (myStringTypeViaReflection.IsAssignableFrom(myStringType))
            {

            }

            List<string> myStringList = new List<string>();
            string[] myStringArray = new string[0];
            //Boxing
            IEnumerable<string> myEnumerable = myStringList;

            myEnumerable = myStringArray;

            //Unboxing via casting
            myStringArray = (string[])myEnumerable;

            //Unvoxing via casting till fel datatyp orsakar InvalidCastException
            //myStringList = (List<string>)myEnumerable;

            //Unboxing via as blir null om datatypen är felaktig
            myStringList = myEnumerable as List<string>;

            //Återställer till korrekta värden
            myEnumerable = new List<string>();

            // Pattering matching, kolla om datatypen är av ett visst värde, variabel är av viss typ.
            if (myEnumerable is List<string> myStringListPatternMatched)
            {
                //Kommer bli sann om den är av korrektdatatyp.
                myStringListPatternMatched.Add("added value");
            }

            //Går även att jämföra utan tilldelning
            if (myEnumerable is List<string>)
            {
                // I sådant fall kan man exekvera annan logik tex.
            }
        }
    }
}
