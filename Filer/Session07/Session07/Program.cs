using System;
using System.IO;
using System.Linq.Expressions;

namespace Session07
{
    class Program
    {
        const string _separator = ";";
        static void Main(string[] args)
        {
            //Detta går att applicera på alla typer av filer.
            //Läsa in en fils textinnehåll.
            //Inte minneshanterad, därför det ligger i using.
            //Filestream för att läsa filens innehåll som bytes från början till slut.
            using (FileStream stream = File.Open("maxfritid.csv", FileMode.Open))
            {
                // Streamreader för att konvertera bytes till tecken.
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Få ut all text på en gång.
                   string fileContent = reader.ReadToEnd();
                }
            }
            // Förlorar kontroll. Hämtar allting från filen.
            // Går att skriva såhär istället
            string simpleReadFileContent = File.ReadAllText("maxfritid.csv");

            using (FileStream stream = File.Open("maxfritid.csv", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Tar emot varje rad i filen, sätta variabel line och läsa av den på en gång. 
                    //Så kollar vi att den inte är null. 
                    //Kommer köras en rad för varje gång den inte är null.


                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            string[] columns = line.Split(_separator);

                            Product product = new Product
                            {
                                Id = ConvertToInt(columns[0]),
                                ProductNumber = columns[2],
                                ProductName = columns[3],
                                ProductBrand = ConvertToNullableInt(columns[4]),
                                ProductSupplier = columns[5],
                                ProductSynonyms = ConvertToArray(columns[6])
                            };
                            // Placera behandling av produkter efter inläsningen, i samma try-sats.
                            //För att kunna undvika behandling av ogiltig data
                            catch (Exception ex)
                        {
                        }
                    }
                    
                }
                         
            }
            //Konvertera till int
            static int ConvertToInt(string input)
            {
                int.TryParse(input, out int result);
                return result;
            }

            //Konvertera till int?
            static int? ConvertToNullableInt(string input)
            {
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }

            static string[] ConvertToArray(string input)
            {
                if (input == null)
                    return new string[0];
                return input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
