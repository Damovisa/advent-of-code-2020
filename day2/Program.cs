using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // part 1
            var input = System.IO.File.ReadAllLines("input.txt");
            var records = input.Select(i =>
            {
                var bits = i.Split(" ");
                return new
                {
                    min = int.Parse(bits[0].Substring(0, bits[0].IndexOf("-"))),
                    max = int.Parse(bits[0].Substring(bits[0].IndexOf("-") + 1)),
                    letter = bits[1].Trim()[0].ToString(),
                    password = bits[2]
                };
            }
            );

            var validCount = 0;
            foreach (var record in records) {
                var instances = Regex.Matches(record.password, record.letter).Count;
                if (instances >= record.min && instances <= record.max) {
                    Console.WriteLine($"VALID: {record}");
                    validCount++;
                } else {
                    Console.WriteLine($"INVALID: {record}");
                }
            }
            Console.WriteLine($"Total valid: {validCount}");
        }
    }
}
