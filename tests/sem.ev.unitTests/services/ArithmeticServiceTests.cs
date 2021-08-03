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
    }
}
