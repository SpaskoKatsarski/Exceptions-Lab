using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var num = int.Parse(Console.ReadLine());
                Console.WriteLine("Done! Wrote it in the try statement!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Cannot parse it!");
            }
            finally
            {
                Console.WriteLine("Everything went clear or didn't go clear :D");
            }
        }
    }
}
