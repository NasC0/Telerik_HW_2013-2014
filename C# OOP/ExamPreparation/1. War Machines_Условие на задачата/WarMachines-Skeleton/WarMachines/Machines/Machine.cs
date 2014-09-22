using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : WorldObject, IMachine
    {
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string machineName, double machineHealthPoints, double machineAttackPoints, double machineDefensePoints)
            :base(machineName)
        {
            this.HealthPoints = machineHealthPoints;
            this.AttackPoints = machineAttackPoints;
            this.DefensePoints = machineDefensePoints;
        }

        public Machine(string machineName, double machineHealthPoints, double machineAttackPoints, double machineDefensePoints, IPilot machinePilot)
            :this(machineName, machineHealthPoints, machineAttackPoints, machineDefensePoints)
        {
            this.Pilot = machinePilot;
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                //if (value == null)
                //{
                //    throw new ArgumentNullException("Pilot value cannot be null!");
                //}

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException("Health points cannot be negative!");
                //}

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException("Attack points cannot be negative!");
                //}

                this.attackPoints = value;
            }
        }

        public double DefensePoints 
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentOutOfRangeException("Defense points cannot be negative!");
                //}

                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
            private set
            {
                //if (value == null)
                //{
                //    throw new ArgumentNullException("Targets list cannot be null!");
                //}

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(String.Format("- {0}\n", this.Name));
            result.Append(" *Type: ");

            if (this is ITank)
            {
                result.Append("Tank\n");
            }
            else if (this is IFighter)
            {
                result.Append("Fighter\n");
            }

            result.Append(String.Format(" *Health: {0}\n", this.HealthPoints));
            result.Append(String.Format(" *Attack: {0}\n", this.AttackPoints));
            result.Append(String.Format(" *Defense: {0}\n", this.DefensePoints));

            result.Append(" *Targets: ");
            if (this.Targets != null && this.Targets.Count >= 0)
            {
                foreach (var target in this.Targets)
                {
                    result.AppendFormat("{0}, ", target);
                }

                result.Remove(result.Length - 2, 2);
                result.Append('\n');
            }
            else
            {
                result.Append("None\n");
            }

            return result.ToString();
        }
    }
}
