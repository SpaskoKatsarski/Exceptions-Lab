using System;
using System.Linq;

namespace T05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MaxExceptionsCount = 3;
            int numberOfExceptions = 0;

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (numberOfExceptions < MaxExceptionsCount)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                try
                {
                    int index = int.Parse(cmdArgs[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    if (cmdType == "Replace")
                    {
                        int element = int.Parse(cmdArgs[2]);

                        numbers[index] = element;
                    }
                    else if (cmdType == "Print")
                    {
                        int endIndex = int.Parse(cmdArgs[2]);

                        if (endIndex < 0 || endIndex >= numbers.Length )
                        {
                            throw new IndexOutOfRangeException();
                        }

                        for (int i = index; i <= endIndex; i++)
                        {
                            Console.Write(numbers[i]);

                            if (i != endIndex)
                            {
                                Console.Write(", ");
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                    else if (cmdType == "Show")
                    {
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    numberOfExceptions++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    numberOfExceptions++;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
