using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
            private set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("- {0}\n", this.Name);
            result.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            result.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            result.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            result.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            result.AppendFormat(" *Targets: ");
            if (this.Targets.Count <= 0)
            {
                result.Append("None");
            }
            else
            {
                string targets = string.Join(", ", this.Targets);
                result.Append(targets);
            }

            return result.ToString();
        }
    }
}
