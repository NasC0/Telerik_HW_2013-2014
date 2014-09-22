using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        private const int StartingHitPoints = 100;
        private const int StartingDefensePoints = 100;
        private const int StartingAttackPoints = 100;

        public Knight(string name, Point position, int owner)
            :base(name, position, owner)
        {
            this.HitPoints = StartingHitPoints;
        }

        public int AttackPoints
        {
            get
            {
                return StartingAttackPoints;
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
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
