using System;

namespace Ships
{
    public class Battleship : AttackingShip
    {
        /// <summary>
        /// Count of minimal attacks to break down ship
        /// </summary>
        protected int minimalAttack;

        /// <summary>
        /// Constructor creates battleship based on absract 
        /// attacking ship with one additional parametr
        /// </summary>
        /// <param name="minAttack">minimal attacks to break ship</param>
        public Battleship(double damage, double guard, int guns, int ammunition,
            int minAttack, double hp) : base(damage, guard, guns, ammunition, hp)
        {
            minimalAttack = minAttack;
        }

        /// <summary>
        /// This property returns type info
        /// </summary>
        public override string Type => "Battleship";

        public override bool IsDead
        {
            get
            {
                if (minimalAttack > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //set
            //{
            //    IsDead = value;
            //}
        }

        /// <summary>
        /// This method deals damage to battleship
        /// </summary>
        /// <param name="damage">size of the damage</param>
        public override void GetDamage(double damage)
        {
            minimalAttack -= 1;
            minimalAttack = minimalAttack <= 0 ? 0 : minimalAttack;
            
            if (guard > 0)
            {
                guard -= 0.7 * damage;
                healthy -= 0.3 * damage;
            }
            else
                healthy -= damage;
            if (guard < 0)
                guard = 0;
            
            if (minimalAttack == 0 && healthy <= 0)
                IsDead = true;
            
            if (IsDead)
                healthy = 0;
            
        }

        /// <summary>
        /// Battleship attacks another ship 
        /// </summary>
        /// <param name="s">another ship</param>
        public override void Attack(Ship s)
        {
            GunsBreak(1, 11, Type);
            ammunition -= guns;
            if (ammunition < 0)
                ammunition = 0;
            s.GetDamage(damage * guns);
        }

        /// <summary>
        /// This method converts Battleship type to String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => Environment.NewLine + $"Battleship" +
            Environment.NewLine + $"Health:\t\t\t{healthy.ToString("f3")}" +
            Environment.NewLine + $"Guard:\t\t\t{guard.ToString("f3")}" +
            Environment.NewLine + $"Amount of guns:\t\t{guns}" +
            Environment.NewLine + $"Each gun's damage:\t\t{damage.ToString("f3")}" +
            Environment.NewLine + $"Avaliable ammunition:\t{ammunition}" +
            Environment.NewLine + $"Attacks to break ship:\t{minimalAttack}" +
            Environment.NewLine + $"This ship is dead: {IsDead}" + Environment.NewLine;
    }
}
