using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PrimeFactors
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full path to your file");
            string path = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            if (checkPath(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (reader.Peek() != -1)
                    {
                        string inputLine = reader.ReadLine();
                        int val;

                        if (int.TryParse(inputLine, out val))
                        {
                            // Find prime factors
                            var primeFactors = GetPrimeFactors(val);
                            var newLine = string.Empty;

                            // create csv list of prime factors and append to output with newline
                            for (int i = 0; i < primeFactors.Count; i++)
                            {
                                if (i == primeFactors.Count - 1)
                                {
                                    newLine += (primeFactors[i].ToString() + Environment.NewLine);
                                }
                                else
                                {
                                    newLine += (primeFactors[i].ToString() + ", ");
                                }
                            }
                            output.Append(newLine);
                        }
                    }
                    // Ensure reader is disposed of properly
                    reader.Close();
                }
                Console.Write(output);
                Console.ReadLine();
            }
        }

        private static bool checkPath(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                Console.WriteLine("You entered and invalid path. Please enter a new one");

                return checkPath(Console.ReadLine());
            }
        }

        public static List<int> GetPrimeFactors(int num)
        {
            var primes = new List<int>();

            for (int div = 2; div <= num; div++)
            {
                while (num % div == 0)
                {
                    primes.Add(div);
                    num = num / div;
                }
            }

            return primes;
        }
    }
}
