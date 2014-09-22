using System;
using ComputerBuilderClasses.Contracts;
using ComputerBuilderClasses.SystemComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerBuilderTests.CPUTests
{
    [TestClass]
    public class RandTests
    {
        private static Random randomGenerator = new Random();

        [TestMethod]
        public void RandShouldReturnNumberInTheRangeSpecified()
        {
            ICentralProcessingUnit cpu = new Cpu32Bit(2);
            int minValue = 1;
            int maxValue = 10;
            int result = cpu.Rand(randomGenerator, minValue, maxValue);
           
            Assert.IsTrue(result >= minValue && result <= maxValue);
        }

        [TestMethod]
        public void RandShouldReturnSameValueInSameRange()
        {
            ICentralProcessingUnit cpu = new Cpu32Bit(2);
            int minValue = 1;
            int maxValue = 1;
            int result = cpu.Rand(randomGenerator, minValue, maxValue);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void RandShouldReturnNegativeValueIfNegativeParamsPassed()
        {
            ICentralProcessingUnit cpu = new Cpu32Bit(2);
            int minValue = -10;
            int maxValue = -1;
            int result = cpu.Rand(randomGenerator, minValue, maxValue);

            Assert.IsTrue(result >= minValue && result <= maxValue);
        }
    }
}
