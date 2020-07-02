using System;
using System.Collections.Generic;
using System.Linq;

namespace WordGarland
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            while (cki.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Write a word to check if it can be used to create word garland!");
                var userInput = Console.ReadLine();
                var result = FindGarlandPart(userInput);
                if (result is null)
                {
                    Console.WriteLine("Garland cannot be create from that word.");
                    Console.WriteLine("Press any key to continue. If you want to quit please press an escape button.");
                    cki = Console.ReadKey();
                }
                else
                {
                    var garlandIndicator = result.Length;
                    var garlandWithRandomLength = CreateGarlandWithRandomLength(userInput, result);

                    Console.WriteLine($"Garland result: {result}.");
                    Console.WriteLine($"Garland indicator: {garlandIndicator}.");
                    Console.WriteLine($"Garland word generated with random length: {garlandWithRandomLength}.");
                    Console.WriteLine("Press any key to continue. If you want to quit please press an escape button.");
                    cki = Console.ReadKey();
                }
            }
        }

        private static string CreateGarlandWithRandomLength(string initialWord, string garlandPart)
        {
            var random = new Random();
            var partToCopy = initialWord.Remove(0, garlandPart.Length);
            var recurrentPart = String.Concat(Enumerable.Repeat(partToCopy, random.Next(100)));
            return String.Concat(garlandPart, recurrentPart);
        }

        private static string FindGarlandPart(string initialWord)
        {
            var reversedIndex = 1;
            var resultsList = new List<string>();
            var baseString = "";
            var checkingString = "";
            for (int i = 0; i < initialWord.Length / 2; i++)
            {
                baseString = String.Concat(baseString, initialWord[i].ToString());
                checkingString = String.Concat(initialWord[initialWord.Length - reversedIndex].ToString(), checkingString);
                if (baseString == checkingString)
                {
                    resultsList.Add(baseString);
                }
                reversedIndex++;
            }
            return resultsList.OrderByDescending(w => w.Length).FirstOrDefault();
        }
    }
}
