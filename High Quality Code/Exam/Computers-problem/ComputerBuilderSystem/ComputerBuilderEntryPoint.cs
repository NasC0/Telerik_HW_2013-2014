using System;
using ComputerBuilderClasses.Contracts;
using ComputerBuilderClasses.Manufacturers;

namespace ComputerBuilderSystem
{
    public class Computers
    {
        public static void Main()
        {
            Random randomGenerator = new Random();

            var manufacturer = Console.ReadLine();
            IManufacturer manufacturerFactory = FactoryMaker.GetFactory(manufacturer);

            IPcSystem pc = manufacturerFactory.BuildPc();
            ILaptopSystem laptop = manufacturerFactory.BuildLaptop();
            IServerSystem server = manufacturerFactory.BuildServer();

            string executeCommand = Console.ReadLine();

            while (executeCommand != null)
            {
                if (executeCommand.StartsWith("Exit"))
                {
                    break;
                }

                var executeCommandSanitized = executeCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (executeCommandSanitized.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandToExecute = executeCommandSanitized[0];
                var commandParameter = int.Parse(executeCommandSanitized[1]);

                if (commandToExecute == "Charge")
                {
                    laptop.ChargeBattery(commandParameter);
                }
                else if (commandToExecute == "Process")
                {
                    server.Process(commandParameter);
                }
                else if (commandToExecute == "Play")
                {
                    pc.Play(commandParameter, randomGenerator);
                }
 
                executeCommand = Console.ReadLine();
            }
        }
    }
}