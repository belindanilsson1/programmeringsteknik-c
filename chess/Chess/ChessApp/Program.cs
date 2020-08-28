using System;

namespace ChessApp
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.Write("▓");
           // Console.Write("░");
           // Console.ReadKey();


            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 16; x++)
                {
                    var characterIndex = ((x / 2) + y) % 2;
                    var character = characterIndex == 0 ? '░' : '▓';

                    Console.Write(character);
                }

                Console.Write('\n');
            }

            Console.ReadKey();

            {
               
            }
        }
    }
}
