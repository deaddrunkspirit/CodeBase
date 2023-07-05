using System;

namespace Ships
{
    public class CargoShip : Ship
    {
        /// <summary>
        /// Cargo on the ship
        /// </summary>
        protected int cargo;

        /// <summary>
        /// This property gets cargo of the cargo ship
        /// </summary>
        public int Cargo { get { return cargo; } set { cargo = value; } }

        /// <summary>
        /// This method decreases cargo on the cargoship
        /// </summary>
        /// <param name="giveaway">cargo that transfered away</param>
        public void GiveAmmo(int giveaway) => cargo -= giveaway;

        /// <summary>
        /// Constructor creates a cargo ship with two parametrs
        /// </summary>
        /// <param name="cargo">amount of cargo on the ship</param>
        /// <param name="hp">health of cargo ship</param>
        public CargoShip(int cargo, double hp) : base(hp)
        {
            this.cargo = cargo;
        }

        /// <summary>
        /// This property returns type info
        /// </summary>
        public override string Type => "Cargo ship";

        /// <summary>
        /// This method dealing damage to the ship
        /// </summary>
        /// <param name="damage">size of the damage</param>
        public override void GetDamage(double damage)
        {
            healthy -= damage;
            if (IsDead)
            {
                healthy = 0;
            }
        }

        /// <summary>
        /// This method converts CargoShip type to String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => Environment.NewLine + $"Cargo ship" + Environment.NewLine
            + $"Health:\t\t\t{healthy.ToString("f3")}" + 
            Environment.NewLine + $"Cargo:\t\t\t{cargo}" + 
            Environment.NewLine + $"This ship is dead: {IsDead}" + 
            Environment.NewLine;
    }
}
