using sem.ev.services;
using System;
using System.Collections.Generic;
using System.IO;

namespace sem.ev
{
    class Program
    {
        static void Main(string[] args)
        {
            var arithmeticSvc = new ArithmeticService();
            var numbers = new List<double>();

            using (var reader = new StreamReader(@".\data\SampleData.xls"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineValues = line.Split(',');

                    for (int i = 0; i < lineValues.Length; i++)
                    {
                        if (double.TryParse(lineValues[i], out var value))
                        {
                            numbers.Add(value);
                        }
                    }
                }
            }

            Console.WriteLine($"Mean of the data is {arithmeticSvc.Mean(numbers.ToArray())}");
            Console.WriteLine($"The standard deviation of the data is {arithmeticSvc.StandardDeviation(numbers.ToArray())}");

            foreach(var resp in arithmeticSvc.BucketData(numbers.ToArray(), 10))
            {
                Console.WriteLine($"{resp.bucket}: {resp.entries}");
            }

            Console.ReadLine();
        }
    }
}
