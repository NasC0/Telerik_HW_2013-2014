using System;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.Manufacturers
{
    public class FactoryMaker
    {
        private static IManufacturer factory;

        public static IManufacturer GetFactory(string manufacturer)
        {
            if (manufacturer == "Dell")
            {
                factory = new DellFactory();
            }
            else if (manufacturer == "HP")
            {
                factory = new HpFactory();
            }
            else if (manufacturer == "Lenovo")
            {
                factory = new LenovoFactory();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer name supplied.");
            }

            return factory;
        }
    }
}