using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {
        static string[] requiredKeys = new[] {"byr","iyr","eyr","hgt","hcl","ecl","pid"}; //,"cid"};

        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText("input.txt");
            var passports = input.Split("\r\n\r\n");

            var valid = 0;

            foreach (var passport in passports) {
                var fields = passport.Split(new[] {"\r\n", " "}, StringSplitOptions.None)
                                   .Select(f => new {key=f.Substring(0,3), value=f.Substring(4)}).ToDictionary(f => f.key, f => f.value);
                if (Validate(fields)) {
                    valid++;
                    Console.WriteLine("Passport valid");
                }
            }

            Console.WriteLine($"Total: {valid}");
        }

        static bool Validate(Dictionary<string, string> fields) {
            if (requiredKeys.All(k => fields.ContainsKey(k))) {

                // byr (1920-2002)
                int readval = 0;
                if (!int.TryParse(fields["byr"], out readval) || readval < 1920 || readval > 2002) {
                    Console.WriteLine($"byr invalid: {fields["byr"]}");
                    return false;
                }
                
                // iyr (2010-2020)
                if (!int.TryParse(fields["iyr"], out readval) || readval < 2010 || readval > 2020) {
                    Console.WriteLine($"iyr invalid: {fields["iyr"]}");
                    return false;
                }

                // eyr (2020-2030)
                if (!int.TryParse(fields["eyr"], out readval) || readval < 2020 || readval > 2030) {
                    Console.WriteLine($"eyr invalid: {fields["eyr"]}");
                    return false;
                }

                // hgt (150-193cm || 59-76in)
                var unit = fields["hgt"].Substring(fields["hgt"].Length-2);
                if (unit.Equals("cm")) {
                    if (!int.TryParse(fields["hgt"].Substring(0,fields["hgt"].Length-2), out readval) || readval < 150 || readval > 193) {
                        Console.WriteLine($"hgt invalid: {fields["hgt"]}");
                        return false;
                    }
                } else if (unit.Equals("in")) {
                    if (!int.TryParse(fields["hgt"].Substring(0,fields["hgt"].Length-2), out readval) || readval < 59 || readval > 76) {
                        Console.WriteLine($"hgt invalid: {fields["hgt"]}");
                        return false;
                    }
                } else {
                    Console.WriteLine($"hgt invalid: {fields["hgt"]}");
                    return false;
                }

                // hcl (# then 6 hex digits)
                if (!Regex.IsMatch(fields["hcl"], "^#[0-9a-f]{6}$")) {
                    Console.WriteLine($"hcl invalid: {fields["hcl"]}");
                    return false;
                }

                // ecl (["amb", "blu", "brn", "gry", "grn", "hzl", "oth"])
                if (!(new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}).Contains(fields["ecl"])) {
                    Console.WriteLine($"ecl invalid: {fields["ecl"]}");
                    return false;
                }

                // pid (9 digit number including leading zeros)
                if (!Regex.IsMatch(fields["pid"], "^[0-9]{9}$")) {
                    Console.WriteLine($"pid invalid: {fields["pid"]}");
                    return false;
                }

            } else {
                return false;
            }

            return true;
        }
    }
}
