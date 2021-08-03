using System.Collections;
using System.Collections.Generic;

namespace sem.ev.unitTests.services.testData
{
    public class StdDevTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new double[] { 2, 2, 2, 2 }, 0 };
            yield return new object[] { new double[] { 2, 0, 2, 0 }, 1 };
            yield return new object[] { new double[] { 100, 50, -50, 100, 75 }, 55.67764362830022 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
