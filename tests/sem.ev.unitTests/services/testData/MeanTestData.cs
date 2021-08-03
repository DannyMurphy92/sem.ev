using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem.ev.unitTests.services.testData
{
    public class MeanTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new double[] { 2, 2, 2, 2 }, 2 };
            yield return new object[] { new double[] { 3, -1, -1, -1 }, 0 };
            yield return new object[] { new double[] { 3, 3, 1.5 }, 2.5 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
