using System;
using System.Linq;
using System.Collections.Generic;

namespace day1
{
    class Program
    {

        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            List<int> numbers = input.Select(i => int.Parse(i)).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    for (int k = j + 1; k < numbers.Count; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            Console.WriteLine($"Numbers are {numbers[i]}, {numbers[j]}, and {numbers[k]}, which gives us {numbers[i] * numbers[j] * numbers[k]}");
                            return;
                        }
                    }
                }
            }
        }
    }
}
