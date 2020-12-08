using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            var records = input.Select(i =>
            {
                var bits = i.Split(" ");
                return new
                {
                    first = int.Parse(bits[0].Substring(0, bits[0].IndexOf("-"))),
                    second = int.Parse(bits[0].Substring(bits[0].IndexOf("-") + 1)),
                    letter = bits[1].Trim()[0].ToString(),
                    password = bits[2]
                };
            }
            );

            // part 1:
            var validCount = 0;
            foreach (var record in records) {
                var instances = Regex.Matches(record.password, record.letter).Count;
                if (instances >= record.first && instances <= record.second) {
                    Console.WriteLine($"VALID: {record}");
                    validCount++;
                } else {
                    Console.WriteLine($"INVALID: {record}");
                }
            }
            Console.WriteLine($"Total valid under part 1: {validCount}");

            // part 2:
            validCount = 0;
            foreach (var record in records) {
                if (record.password[record.first-1] == record.letter[0] ^ record.password[record.second-1] == record.letter[0]) {
                    Console.WriteLine($"VALID: {record}");
                    validCount++;
                }
            }
            Console.WriteLine($"Total valid under part 2: {validCount}");
        }
    }
}
