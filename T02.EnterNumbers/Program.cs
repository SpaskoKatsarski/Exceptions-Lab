using System;
using System.Collections.Generic;

namespace T02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>();
            int nextNum = 1;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(nextNum, 100, ref nextNum);
                    nums.Add(nextNum);
                }
                catch (ArgumentOutOfRangeException)
                {
                    i--;
                    Console.WriteLine($"Your number is not in range {nextNum} - 100!");
                }
                catch 
                {
                    i--;
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }

        static void ReadNumber(int start, int end, ref int nextNum)
        {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            nextNum = number;
        }
    }
}
