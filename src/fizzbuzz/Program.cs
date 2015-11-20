using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzLib;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzer = new FizzBuzzer();
            var lines = fizzBuzzer.GetFizzBuzzList(100);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
