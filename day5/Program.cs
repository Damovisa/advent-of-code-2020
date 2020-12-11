using System;
using System.Collections.Generic;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            var seatIds = new List<int>();

            foreach (var line in input) {
                // get value
                var rowVal = GetValue(line.Substring(0,7));
                var colVal = GetValue(line.Substring(7));
                var seatId = rowVal * 8 + colVal;
                Console.WriteLine($"'{line}' -> Row {rowVal}, Seat {colVal}, Seat ID {seatId}");
                seatIds.Add(seatId);
            }
            
            // dump the missing seats
            seatIds.Sort();
            var lastSeat = 0;
            for (int i=0;i<seatIds.Count;i++) {
                if (seatIds[i] != lastSeat+1) {
                    Console.WriteLine($"Seat missing between {lastSeat} and {seatIds[i]}!");
                }
                lastSeat = seatIds[i];
            }
        }

        static int GetValue(string encoded) {
            var binString = encoded
                .Replace("F","0").Replace("L", "0")
                .Replace("B","1").Replace("R", "1");
            return Convert.ToInt32(binString, 2);
        }
    }
}
