using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private const int FighterStartHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            :base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = FighterStartHealthPoints;
            this.StealthMode = !stealthMode;
            this.ToggleStealthMode();
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "\n *Stealth: ";
            if (this.StealthMode == true)
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
