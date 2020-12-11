using System;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = new[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};

            var input = System.IO.File.ReadAllText("input.txt");
            var groups = input.Split("\r\n\r\n");

            int totalCount = 0;

            foreach (var group in groups) {
                var yeses = 0;
                // I'm sure I could do this with Linq, but my brain hurts.
                foreach (var q in questions) {
                    yeses += group.Split("\r\n").All(answer => answer.Contains(q))?1:0;
                }
                Console.WriteLine(group);
                Console.WriteLine($" -> {yeses}");
                totalCount += yeses;
            }

            Console.WriteLine($"Total: {totalCount}");
        }
    }
}
