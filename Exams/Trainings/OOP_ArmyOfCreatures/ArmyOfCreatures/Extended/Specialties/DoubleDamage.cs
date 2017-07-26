using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0 and less or equal to 10");
            }
            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            decimal modifiedDmg = currentDamage;

            if (rounds > 0)
            {
                modifiedDmg *= 2;
                this.rounds--;
            }

            return modifiedDmg;
        }

        public override string ToString()
        {
            return string.Format("DoubleDamage({0})", this.rounds);
        }
    }
}
