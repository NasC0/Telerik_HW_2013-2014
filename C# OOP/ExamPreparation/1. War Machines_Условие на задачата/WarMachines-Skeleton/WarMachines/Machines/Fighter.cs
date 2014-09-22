using System;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string fighterName, double fighterAttackPoints, double figtherDefensePoints, bool stealthMode)
            :base(fighterName, InitialHealthPoints, fighterAttackPoints, figtherDefensePoints)
        {
            this.StealthMode = false;

            if (stealthMode == true)
            {
                this.ToggleStealthMode();
            }

        }

        public Fighter(string fighterName, double fighterAttackPoints, double figtherDefensePoints, bool stealthMode, IPilot fighterPilot)
            :this(fighterName, fighterAttackPoints, figtherDefensePoints, stealthMode)
        {
            this.Pilot = fighterPilot;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "Stealth: ";

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
