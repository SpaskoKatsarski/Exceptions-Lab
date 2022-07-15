using System;

namespace T01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var num = double.Parse(Console.ReadLine());

                if (num < 0)
                {
                    throw new InvalidOperationException();
                }

                double sqrt = Math.Sqrt(num);
                Console.WriteLine(sqrt);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
