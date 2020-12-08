using System;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText("input.txt");
            var passports = input.Split("\r\n\r\n");

            var requiredKeys = new[] {"byr","iyr","eyr","hgt","hcl","ecl","pid"}; //,"cid"};
            var valid = 0;

            foreach (var passport in passports) {
                var keys = passport.Split(new[] {"\r\n", " "}, StringSplitOptions.None)
                                   .Select(f => f.Substring(0,3));
                if (requiredKeys.All(k => keys.Contains(k))) {
                    valid++;
                    Console.WriteLine("Passport valid");
                }
            }

            Console.WriteLine($"Total: {valid}");
        }
    }
}
