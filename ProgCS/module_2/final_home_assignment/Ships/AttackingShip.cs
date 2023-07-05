using System;

namespace Ships
{
    public abstract class AttackingShip : Ship
    {
        /// <summary>
        /// Gun damage size
        /// </summary>
        protected double damage;

        /// <summary>
        /// Guard of the attacking ship
        /// </summary>
        protected double guard;

        /// <summary>
        /// Count of guns on ship
        /// </summary>
        protected int guns;

        /// <summary>
        /// Amount of ammunition avaliable for guns
        /// </summary>
        protected int ammunition;

        /// <summary>
        /// Constructor creates abstract attacking ship
        /// with 5 parametrs
        /// </summary>
        /// <param name="damage">damage of each gun</param>
        /// <param name="guard">guard of ship</param>
        /// <param name="guns">amount of guns on ship</param>
        /// <param name="ammunition">count of ammunition
        /// avaliable for guns</param>
        /// <param name="healthy">heath of ship</param>
        public AttackingShip(double damage, double guard, int guns,
            int ammunition, double healthy) : base(healthy)
        {
            this.guard = guard;
            this.guns = guns;
            this.ammunition = ammunition;
            this.damage = damage;
        }

        /// <summary>
        /// Abstract method that deals damage to another ship
        /// </summary>
        /// <param name="s">ship to attack</param>
        public abstract void Attack(Ship s);

        /// <summary>
        /// This property delievrs ammunition from cargo 
        /// ship to attacking ship
        /// </summary>
        /// <param name="ammo"></param>
        public void TakeAmmo(int ammo) => ammunition += ammo;

        public int Ammo => ammunition;

        /// <summary>
        /// Abstract method that deals damage to the ship
        /// </summary>
        /// <param name="damage">size of taking damage</param>
        public override void GetDamage(double damage) { }

        /// <summary>
        /// This method calcultes if 
        /// any gun broken during attack
        /// </summary>
        /// <param name="lower">lower bound of 
        /// breaking down possibility</param>
        /// <param name="upper">upper bound of 
        /// breaking down possibility</param>
        /// <param name="st">Type of attacking ship</param>
        protected void GunsBreak(int lower, int upper, string st)
        {
            int restGuns = guns;
            for (int i = 0; i < guns; i++)
            {
                int n = rnd.Next(lower, upper);
                if (n == 1) { restGuns--; }
            }
            Console.WriteLine($"{st} ship during the attack lost " +
                $"{guns - restGuns} guns\n");
            guns = restGuns;
        }
    }
}
