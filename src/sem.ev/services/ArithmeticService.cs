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

            if(input.Length > 0)
            {
                var numerator = (double)0;
                for(int i = 0; i < input.Length; i++)
                {
                    var distToMean = input[i] - mean;
                    numerator += distToMean * distToMean;
                }

                var sqrtInput = numerator / input.Length;

                return Math.Sqrt(sqrtInput);
            }

            return mean;
        }
    }
}
