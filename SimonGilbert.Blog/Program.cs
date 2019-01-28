using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SimonGilbert.Blog
{
    class Program
    {
        private static Dictionary<int, TimeSpan> results = new Dictionary<int, TimeSpan>();

        static void Main(string[] args)
        {
            RunFizzBuzzVersionOne();
            RunFizzBuzzVersionTwo();
            RunFizzBuzzVersionThree();

            Console.Write(Environment.NewLine);
            Console.WriteLine("RESULTS:");
            foreach (var result in results)
                Console.WriteLine($"Version {result.Key} : {result.Value}");

            Console.Write(Environment.NewLine);
            Console.WriteLine("WINNER:");
            var keyAndValue = results.OrderBy(kvp => kvp.Value).First();
            Console.WriteLine("{0} => {1}", keyAndValue.Key, keyAndValue.Value);

            Console.ReadKey();
        }

        private static void RunFizzBuzzVersionOne()
        {
            Console.WriteLine("FizzBuzz Version One:");
            var stopwatch = Stopwatch.StartNew();

            for (int i = 1; i <= 100; i++)
            {
                var fizz = i % 3 == 0;
                var buzz = i % 5 == 0;

                if (fizz && buzz)
                    Console.WriteLine("FizzBuzz");
                else if (fizz)
                    Console.WriteLine("Fizz");
                else if (buzz)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }

            stopwatch.Stop();
            Console.WriteLine($"Code Execution Time: {stopwatch.Elapsed}");

            results.Add(1, stopwatch.Elapsed);
        }

        private static void RunFizzBuzzVersionTwo()
        {
            Console.WriteLine("FizzBuzz Version Two:");
            var stopwatch = Stopwatch.StartNew();

            var combinations = new List<Tuple<int, string>>
            {
                new Tuple<int, string> (3, "Fizz"),
                new Tuple<int, string> (5, "Buzz"),
            };

            for (int i = 1; i <= 100; i++)
            {
                var x = combinations.Where(y => i % y.Item1 == 0);

                if (x.Count() == 0)
                    Console.Write(i);
                else
                    Console.Write(string.Join("", x.Select(z => z.Item2)));

                Console.Write(Environment.NewLine);
            }

            stopwatch.Stop();
            Console.WriteLine($"Code Execution Time: {stopwatch.Elapsed}");

            results.Add(2, stopwatch.Elapsed);
        }

        private static void RunFizzBuzzVersionThree()
        {
            Console.WriteLine("FizzBuzz Version Three:");
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine(String.Join(
                Environment.NewLine,
                Enumerable.Range(1, 100)
                .Select(n => n % 15 == 0 ? "FizzBuzz"
                    : n % 3 == 0 ? "Fizz"
                    : n % 5 == 0 ? "Buzz"
                    : n.ToString())
                    ));

            stopwatch.Stop();
            Console.WriteLine($"Code Execution Time: {stopwatch.Elapsed}");

            results.Add(3, stopwatch.Elapsed);
        }
    }
}
