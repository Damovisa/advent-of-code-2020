using System;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");

            // Thoughts: You always go to the next line, so I should just be able to mod the width?   
            var left = 0;
            var patternWidth = input[0].Length;
            var tree = 0;
            for (int row = 1; row < input.Length; row++)
            {
                left+=3;
                if (input[row][left%patternWidth] == '#') {
                    tree++;
                }
            }
            Console.WriteLine($"{tree} trees encountered");
        }
    }
}
