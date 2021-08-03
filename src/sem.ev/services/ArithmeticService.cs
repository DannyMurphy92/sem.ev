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
    }
}
