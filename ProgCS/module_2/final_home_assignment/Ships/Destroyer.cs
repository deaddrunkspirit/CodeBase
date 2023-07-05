using System;

namespace Ships
{
    public class Destroyer : AttackingShip
    {
        /// <summary>
        /// Constructor creates destroyer ship based on abstract attacking ship 
        /// </summary>
        public Destroyer(double damage, double guard, int guns,
            int ammunition, double hp) : base(damage, guard, guns, ammunition, hp) { }

        /// <summary>
        /// This property returns type info
        /// </summary>
        public override string Type => "Destroyer";

        /// <summary>
        /// This method deals damage to destroyer
        /// </summary>
        /// <param name="damage">size of the damage</param>
        public override void GetDamage(double damage)
        {
            if (guard > 0)
            {
                guard -= 0.7 * damage;
                healthy -= 0.3 * damage;
            }
            else
                healthy -= damage;

            if (guard < 0)
                guard = 0;

            if (IsDead)
                healthy = 0;
        }

        /// <summary>
        /// Destroyer attacks another ship 
        /// </summary>
        /// <param name="s">another ship</param>
        public override void Attack(Ship s)
        {
            GunsBreak(1, 6, Type);
            ammunition -= guns;
            if (ammunition < 0)
                ammunition = 0;
            s.GetDamage(damage * guns);
        }

        /// <summary>
        /// This method converts Destroyer type to String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => Environment.NewLine + $"Destroyer" +
            Environment.NewLine + $"Health:\t\t\t{healthy.ToString("f3")}" +
            Environment.NewLine + $"Guard:\t\t\t{guard.ToString("f3")}" +
            Environment.NewLine + $"Amount of guns:\t\t{guns}" +
            Environment.NewLine + $"Each gun's damage:\t\t{damage.ToString("f3")}" +
            Environment.NewLine + $"Avaliable ammunition:\t{ammunition}" +
            Environment.NewLine + $"This ship is dead: {IsDead}" + Environment.NewLine;
    }
}
