using System;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string machineName, double tankAttackPoints, double tankDefensePoints)
            :base(machineName, InitialHealthPoints, tankAttackPoints, tankDefensePoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public Tank(string machineName, double tankAttackPoints, double tankDefensePoints, IPilot tankPilot)
            :this(machineName, tankAttackPoints, tankDefensePoints)
        {
            this.Pilot = tankPilot;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == true)
            {
                this.DefenseMode = false;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "Defense: ";

            if (this.DefenseMode == true)
            {
                result += "ON";
            }
            else
            {
                result += "OFF";
            }

            return result;
        }
    }
}
