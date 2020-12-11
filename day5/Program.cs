using System;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            int maxRow = 0;

            foreach (var line in input) {
                // get value
                var rowVal = GetValue(line.Substring(0,7));
                var colVal = GetValue(line.Substring(7));
                var seatId = rowVal * 8 + colVal;
                Console.WriteLine($"'{input}' -> Row {rowVal}, Seat {colVal}, Seat ID {seatId}");
                if (seatId > maxRow)
                    maxRow = seatId;
            }
            Console.WriteLine($"Max Seat ID: {maxRow}");
        }

        static int GetValue(string encoded) {
            var binString = encoded
                .Replace("F","0").Replace("L", "0")
                .Replace("B","1").Replace("R", "1");
            return Convert.ToInt32(binString, 2);
        }
    }
}
