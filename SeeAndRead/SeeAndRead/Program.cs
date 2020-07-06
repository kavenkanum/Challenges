using System;
using System.Collections.Generic;
using System.Linq;

namespace SeeAndRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var cki = new ConsoleKeyInfo();
            while (cki.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Please type how much levels program should read:");
                var userInputLevel = Console.ReadLine();
                var parseResult = int.TryParse(userInputLevel, out int upToLevel);
                if (parseResult)
                {
                    var initialValue = new int[] { 1 };

                    for (int i = 0; i < upToLevel; i++)
                    {
                        var value = ReadLevel(initialValue, out initialValue);
                        Console.WriteLine(value);
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect user input - please type a number."); ;
                }
                Console.WriteLine("Press any key to continue. If you want to quit - please press the Escape button."); ;
                cki = Console.ReadKey();
            }
           

        }

        private static string ReadLevel(int[] initNumber, out int[] nextLevelNumber)
        {
            var indicator = 0;
            int value = initNumber[0];
            var result = new Queue<int>(0);
            foreach (var n in initNumber)
            {
                if (n != value)
                {
                    result.Enqueue(indicator);
                    result.Enqueue(value);
                    value = n;
                    indicator=1;
                }
                else
                {
                    indicator++;
                }
            }
            result.Enqueue(indicator);
            result.Enqueue(value);
            nextLevelNumber = result.ToArray();
            return String.Join("", result.Select(n => n.ToString()).ToArray());
        }
    }
}
