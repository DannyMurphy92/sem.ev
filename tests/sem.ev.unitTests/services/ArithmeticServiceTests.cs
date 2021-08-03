using FluentAssertions;
using sem.ev.services;
using sem.ev.unitTests.services.testData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace sem.ev.unitTests.services
{
    public class ArithmeticServiceTests
    {
        [Fact]
        public void Mean_GivenEmptyArray_Returns0()
        {
            var sut = new ArithmeticService();

            Assert.Equal(0, sut.Mean(new double[] { }));
        }

        [Theory]
        [ClassData(typeof(MeanTestData))]
        public void Mean_GivenArrayOfData_CalculatesMeanCorrectly(double[] input, double expectedMean)
        {
            var sut = new ArithmeticService();

            Assert.Equal(expectedMean, sut.Mean(input));
        }

        [Fact]
        public void StdDev_GivenEmptyArray_Returns0()
        {

            var sut = new ArithmeticService();

            Assert.Equal(0, sut.StandardDeviation(new double[] { }));
        }

        [Theory]
        [ClassData(typeof(StdDevTestData))]
        public void StdDev_GivenArrayOfData_CalculatesStdDevCorrectly(double[] input, double expectedDeviation)
        {
            var sut = new ArithmeticService();

            Assert.Equal(expectedDeviation, sut.StandardDeviation(input));
        }

        [Theory]
        [ClassData(typeof(BucketsTestData))]
        public void Buckets_GivenArrayOfData_SortsIntoBucketsCorrectly(double[] input, int buckets, (string bucket, int entries)[] expectedResponse )
        {
            var sut = new ArithmeticService();

            var result = sut.BucketData(input, buckets);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public void Buckets_GivenEmptyArrayOfData_ThrowsException()
        {
            var sut = new ArithmeticService();

            var ex = Assert.Throws<ArgumentException>(() => sut.BucketData(new double[] { }, 5).ToList());
            Assert.Equal("Input data must contain at least 1 entry", ex.Message);
        }

        [Fact]
        public void Buckets_GivenZeroBuckets_ThrowsException()
        {
            var sut = new ArithmeticService();

            var ex = Assert.Throws<ArgumentException>(() => sut.BucketData(new double[] { 1,2,3}, 0).ToList());
            Assert.Equal("Number of buckets must be at least 1", ex.Message);
        }
    }
}
