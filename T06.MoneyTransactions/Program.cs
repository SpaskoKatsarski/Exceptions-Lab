using System;
using System.Collections.Generic;

namespace T06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> accounts = new Dictionary<string, decimal>();

            string[] accountsInfo = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var acc in accountsInfo)
            {
                accounts.Add(acc.Split('-', StringSplitOptions.RemoveEmptyEntries)[0],
               decimal.Parse(acc.Split('-', StringSplitOptions.RemoveEmptyEntries)[1]));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split();

                string cmdType = cmdArgs[0];
                string accNumber = cmdArgs[1];
                decimal sum = decimal.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Deposit")
                    {
                        if (!accounts.ContainsKey(accNumber))
                        {
                            throw new MissingMemberException();
                        }

                        accounts[accNumber] += sum;
                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                    }
                    else if (cmdType == "Withdraw")
                    {
                        if (!accounts.ContainsKey(accNumber))
                        {
                            throw new MissingMemberException();
                        }
                        else if (sum > accounts[accNumber])
                        {
                            throw new InvalidOperationException();
                        }

                        accounts[accNumber] -= sum;
                        Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (MissingMemberException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

            }
        }
    }
}
