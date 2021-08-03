﻿using sem.ev.services.interfaces;
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

            var bucketMax = input.Max() % 1 == 0 ? input.Max() + 1 : Math.Ceiling(input.Max());
            var bucketMin = Math.Floor(input.Min());

            var totalNumberOfInputs = input.Length;

            if (bucketMax < 0)
            {
                bucketMax = 0;
            }

            if (bucketMin > 0)
            {
                bucketMin = 0;
            }

            var bucketSize = (int)(bucketMax - bucketMin) / numberOfBuckets;

           if(bucketSize == 0)
            {
                bucketSize = 1;
            }

            var lowerLimit = bucketMin;
            for (int bucketIx = 0; bucketIx < numberOfBuckets; bucketIx++)
            {
                var upperLimit = bucketMin + (bucketSize * (bucketIx+1));

                if(bucketIx == numberOfBuckets - 1 && upperLimit < bucketMax)
                {
                    upperLimit = bucketMax; // If its a fraction
                }

                // Could be simplified using LINQ.Count(x => x..., wasn't sure if it was allowed
                var entries = 0;
                for (int inputIx = 0; inputIx < totalNumberOfInputs; inputIx++)
                {
                    if (input[inputIx] >= lowerLimit && input[inputIx] < upperLimit)
                    {
                        entries++;
                    }
                }

                yield return (bucket: $"{lowerLimit} to <{upperLimit}", entries);
                lowerLimit = upperLimit;
            }
        }
    }
}
