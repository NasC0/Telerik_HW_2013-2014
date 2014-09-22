using System;
using ComputerBuilderClasses.Contracts;
using ComputerBuilderClasses.SystemComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerBuilderTests.CPUTests
{
    [TestClass]
    public class SquareNumberTests
    {
        [TestMethod]
        public void SquareNumberShouldReturnPositiveNumberWhenPositiveParamPassedIn()
        {
            ICentralProcessingUnit cpu = new Cpu128Bit(2);
            int dataToPass = 16;
            int resultData = cpu.SquareNumber(dataToPass);

            Assert.IsTrue(resultData > 0);
        }

        [TestMethod]
        public void SquareNumberShouldReturnCorectNumberWhenPositiveParamPassedIn()
        {
            ICentralProcessingUnit cpu = new Cpu128Bit(2);
            int dataToPass = 16;
            int resultData = cpu.SquareNumber(dataToPass);

            Assert.AreEqual(256, resultData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareNumberShouldThrowExceptionWhenNegativeParameterPassed()
        {
            ICentralProcessingUnit cpu = new Cpu128Bit(2);
            int dataToPass = -10;
            cpu.SquareNumber(dataToPass);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareNumberShouldThrowExceptionWhenOverflowingParameterPassed()
        {
            ICentralProcessingUnit cpu = new Cpu128Bit(2);
            int dataToPass = 2001;
            cpu.SquareNumber(dataToPass);
        }
    }
}
