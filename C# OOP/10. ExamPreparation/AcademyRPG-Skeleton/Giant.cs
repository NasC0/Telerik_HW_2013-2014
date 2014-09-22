using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private const int StartingHitPoints = 200;
        private const int StartingAttackPoints = 150;
        private const int StartingDefensePoints = 80;
        private const int GiantOwner = 0;

        private int attackPoints;
        private bool upgraded;

        public Giant(string name, Point position)
            :base(name, position, GiantOwner)
        {
            this.HitPoints = StartingHitPoints;
            this.AttackPoints = StartingAttackPoints;
            this.upgraded = false;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return StartingDefensePoints;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (this.upgraded == false)
                {
                    this.AttackPoints += 100;
                    this.upgraded = true;
                }

                return true;
            }

            return false;
        }
    }
}
