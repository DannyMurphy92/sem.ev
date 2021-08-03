using sem.ev.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem.ev.services
{
    public class ArithmeticService : IArithmeticService
    {
        public double Mean(double[] input)
        {
            double total = 0;

            if (input.Length > 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    total += input[i];
                }

                return total / input.Length;
            }

            return 0;
        }

        public double StandardDeviation(double[] input)
        {
            var mean = Mean(input);

            if (input.Length > 0)
            {
                var numerator = (double)0;
                for (int i = 0; i < input.Length; i++)
                {
                    var distToMean = input[i] - mean;
                    numerator += distToMean * distToMean;
                }

                var sqrtInput = numerator / input.Length;

                return Math.Sqrt(sqrtInput);
            }

            return mean;
        }


        public IEnumerable<(string bucket, int entries)> BucketData(double[] input, int numberOfBuckets)
        {
            if (input.Length == 0)
            {
                throw new ArgumentException("Input data must contain at least 1 entry");
            }
            if(numberOfBuckets == 0)
            {
                throw new ArgumentException("Number of buckets must be at least 1");
            }

            var (bucketMin, bucketMax, bucketSize) = GetBucketValues(input, numberOfBuckets);

            var lowerLimit = bucketMin;

            for (int bucketIx = 0; bucketIx < numberOfBuckets; bucketIx++)
            {
                var upperLimit = bucketMin + (bucketSize * (bucketIx+1));

                if(bucketIx == numberOfBuckets - 1 && upperLimit < bucketMax)
                {
                    upperLimit = bucketMax; // If its a decimal
                }

                // Could be simplified using LINQ.Count(x => x..., wasn't sure if it was allowed
                var entries = 0;

                Array.ForEach(input, value =>
                {
                    if (value >= lowerLimit && value < upperLimit)
                    {
                        entries++;
                    }
                });

                yield return (bucket: $"{lowerLimit} to <{upperLimit}", entries);
                lowerLimit = upperLimit;
            }
        }

        private (double min, double max, int size) GetBucketValues(double[] input, int numberOfBuckets)
        {
            var max = input.Max() % 1 == 0 ? input.Max() + 1 : Math.Ceiling(input.Max());
            var min = Math.Floor(input.Min());

            if (max < 0)
            {
                max = 0;
            }

            if (min > 0)
            {
                min = 0;
            }

            var size = (int)(max - min) / numberOfBuckets;

            if (size == 0)
            {
                size = 1;
            }

            return (min, max, size);
        }
    }
}
