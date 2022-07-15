using System;

namespace T04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            string[] values = Console.ReadLine()
                .Split();

            foreach (var element in values)
            {
                try
                {
                    sum += int.Parse(element);
                }
                catch (FormatException)
                {

                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
