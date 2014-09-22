using ComputerBuilderClasses.Contracts;
using ComputerBuilderClasses.SystemComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerBuilderTests.LaptopBatteryTests
{
    [TestClass]
    public class ChargeMethodTests
    {
        [TestMethod]
        public void InitialBatteryChargeShouldBe50()
        {
            ILaptopBattery battery = new LaptopBattery();
            
            Assert.AreEqual(50, battery.Percentage);
        }

        [TestMethod]
        public void ChargeMethodShouldIcreaseChargeWhenPositiveParametePassed()
        {
            ILaptopBattery battery = new LaptopBattery();
            int charge = 20;
            battery.Charge(charge);

            Assert.AreEqual(70, battery.Percentage);
        }

        [TestMethod]
        public void ChargeMethodShouldReduceChargeWhenNegativeParameterPassed()
        {
            ILaptopBattery battery = new LaptopBattery();
            int charge = -10;
            battery.Charge(charge);

            Assert.AreEqual(40, battery.Percentage);
        }

        [TestMethod]
        public void ChargeMethodShouldChargeToZeroIfALargeNegativeNumberIsPassed()
        {
            ILaptopBattery battery = new LaptopBattery();
            int charge = -100;
            battery.Charge(charge);

            Assert.AreEqual(0, battery.Percentage);
        }

        [TestMethod]
        public void ChargeMethodShouldChargeToHundredIfALargePositiveNumberIsPassed()
        {
            ILaptopBattery battery = new LaptopBattery();
            int charge = 100;
            battery.Charge(charge);

            Assert.AreEqual(100, battery.Percentage);
        }
    }
}
