using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : WorldObject, IPilot
    {
        public Pilot(string name)
            :base(name)
        {
            this.MachinesEngaged = new List<IMachine>();
        }

        private List<IMachine> MachinesEngaged { get; set; }

        public void AddMachine(IMachine machine)
        {
            this.MachinesEngaged.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append(String.Format("{0} - ", this.Name));
            if (this.MachinesEngaged.Count == 0)
            {
                result.Append("no machines");
            }
            else if (this.MachinesEngaged.Count == 1)
            {
                result.Append("1 machine\n");
            }
            else
            {
                result.Append(String.Format("{0} machines\n", this.MachinesEngaged.Count));
            }

            foreach (IMachine machine in this.MachinesEngaged)
            {
                result.Append(machine.ToString());
            }

            return result.ToString();
        }
    }
}
