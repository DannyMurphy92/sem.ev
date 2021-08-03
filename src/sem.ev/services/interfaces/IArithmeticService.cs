using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem.ev.services.interfaces
{
    public interface IArithmeticService
    {
        double Mean(double[] input);
        double StandardDeviation(double[] input);
        IEnumerable<(string bucket, int entries)> BucketData(double[] input, int numberOfBuckets);
    }
}
