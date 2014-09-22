using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private const int NinjaHitPoints = 1;

        private const int NinjaStartAttackPoints = 0;

        public Ninja(string name, Point position, int owner)
            :base(name, position, owner)
        {
            this.HitPoints = NinjaHitPoints;
            this.AttackPoints = NinjaStartAttackPoints;
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var sortedTargets = availableTargets.OrderByDescending(x => x.HitPoints).ToList();

            for (int i = 0; i < sortedTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
