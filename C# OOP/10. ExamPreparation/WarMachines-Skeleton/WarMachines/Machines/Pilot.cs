using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
	public class Pilot : IPilot
	{
		private IList<IMachine> machinesOperated;

		public Pilot(string name)
		{
			this.Name = name;
			this.machinesOperated = new List<IMachine>();
		}

		public string Name { get; private set; }

		public void AddMachine(IMachine machine)
		{
			this.machinesOperated.Add(machine);
		}

		public string Report()
		{
			var sortedMachines = this.machinesOperated.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);

			StringBuilder result = new StringBuilder();
			result.AppendFormat("{0} - ", this.Name);

			int machinesCount = sortedMachines.Count();
			if (machinesCount > 0)
			{
				result.AppendFormat("{0} ", machinesCount);
				if (machinesCount == 1)
				{
					result.Append("machine");
				}
				else
				{
					result.Append("machines");
				}
			}
			else
			{
				result.Append("no machines");
			}

			if (machinesCount > 0)
			{
				result.AppendLine();

				foreach (var machine in sortedMachines)
				{
					result.AppendFormat("{0}\n", machine.ToString());
				}

				result.Remove(result.Length - 1, 1);
			}

			return result.ToString();
		}
	}
}
