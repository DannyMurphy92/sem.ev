using sem.ev.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace sem.ev
{
    class Program
    {
        static void Main(string[] args)
        {
            var arithmeticSvc = new ArithmeticService();
            var numbers = new List<double>();

            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (var reader = new StreamReader($"{assemblyPath}\\data\\SampleData.xls"))
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


            Console.WriteLine($"Press any key to exit");

            Console.ReadLine();
        }
    }
}
