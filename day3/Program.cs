using System;

namespace day3
{
    class Program
    {
        static string[] input;

        static void Main(string[] args)
        {
            input = System.IO.File.ReadAllLines("input.txt");

            // Part 2 - extract a function
            long r1d1 = GetTrees(1,1);
            long r3d1 = GetTrees(3,1);
            long r5d1 = GetTrees(5,1);
            long r7d1 = GetTrees(7,1);
            long r1d2 = GetTrees(1,2);

            Console.WriteLine($"Multiplied: {r1d1*r3d1*r5d1*r7d1*r1d2}");
        }

        public static int GetTrees(int right, int down) {
            Console.WriteLine($"Right {right}, Down {down}:");
            var patternWidth = input[0].Length;
            var left = 0;
            var tree = 0;
            for (int row = down; row < input.Length; row+=down)
            {
                left+=right;
                if (input[row][left%patternWidth] == '#') {
                    tree++;
                }
            }
            Console.WriteLine($"  {tree} trees encountered");
            return tree;
        }
    }
}
