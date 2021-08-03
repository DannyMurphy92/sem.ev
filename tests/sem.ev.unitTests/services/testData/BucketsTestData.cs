using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sem.ev.unitTests.services.testData
{
    public class BucketsTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new double[] { 2, 2, 2, 2 },
                2,
                new (string bucket, int entries)[]
                {
                    ("0 to <1", 0),
                    ("1 to <3", 4)
                }
            };

            yield return new object[]
            {
                new double[] { 1, 100 },
                10,
                new (string bucket, int entries)[]
                {
                    ("0 to <10", 1),
                    ("10 to <20", 0),
                    ("20 to <30", 0),
                    ("30 to <40", 0),
                    ("40 to <50", 0),
                    ("50 to <60", 0),
                    ("60 to <70", 0),
                    ("70 to <80", 0),
                    ("80 to <90", 0),
                    ("90 to <101", 1),
                }
            };

            yield return new object[]
            {
                new double[] { 1,2,2,1,7.5 },
                3,
                new (string bucket, int entries)[]
                {
                    ("0 to <2", 2),
                    ("2 to <4", 2),
                    ("4 to <8", 1),
                }
            };

            yield return new object[]
            {
                new double[] { 1 },
                5,
                new (string bucket, int entries)[]
                {
                    ("0 to <1", 0),
                    ("1 to <2", 1),
                    ("2 to <3", 0),
                    ("3 to <4", 0),
                    ("4 to <5", 0),
                }
            };

            yield return new object[]
            {
                new double[] { -3, 0, 6 },
                3,
                new (string bucket, int entries)[]
                {
                    ("-3 to <0", 1),
                    ("0 to <3", 1),
                    ("3 to <7", 1),
                }
            };

            yield return new object[]
            {
                new double[] { -1,-2,-2,-1,-7.5 },
                3,
                new (string bucket, int entries)[]
                {
                    ("-8 to <-6", 1),
                    ("-6 to <-4", 0),
                    ("-4 to <0", 4),
                }
            };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
