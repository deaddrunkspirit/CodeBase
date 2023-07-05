using System;

namespace Ships
{
    public abstract class Ship
    {
        /// <summary>
        /// Randomizer for all ships
        /// </summary>
        protected static Random rnd = new Random();

        /// <summary>
        /// Heath points of the ship
        /// </summary>
        protected double healthy;

        public double Hp => healthy;

        /// <summary>
        /// Constructor creates an abstract ship with 1 parametr
        /// </summary>
        /// <param name="healthy">Heath of the ship</param>
        protected Ship(double healthy)
        {
            this.healthy = healthy;
        }

        /// <summary>
        /// Flag that shows if ship is dead
        /// </summary>
        public virtual bool IsDead 
        { get { return healthy <= 0 ? true : false; } set { } }

        public virtual string Type => "";

        /// <summary>
        /// Abstract method that dealing damage to ship
        /// </summary>
        /// <param name="damage">size of the damage</param>
        public abstract void GetDamage(double damage);
    }
}
