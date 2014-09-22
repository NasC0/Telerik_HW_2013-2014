namespace WarMachines.Machines
{
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const int TankStartingHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = TankStartingHealthPoints;
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
                this.DefenseMode = true;
            }
            else
            {
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
                this.DefenseMode = false;
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += "\n *Defense: ";
            if (this.DefenseMode)
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
