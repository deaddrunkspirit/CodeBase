namespace Ships
{
    public class Player
    {

        public readonly int playerNumber;
        /// <summary>
        /// Array of player's ships
        /// </summary>
        public Ship[] _ships;

        /// <summary>
        /// Amount of players credits
        /// </summary>
        public int _credits;

        /// <summary>
        /// Indexator to change player's ships
        /// </summary>
        /// <param name="ship">number of ship</param>
        /// <returns></returns>
        public Ship this[int ship]
        {
            get
            {
                return _ships[ship];
            }
            set
            {
                _ships[ship] = value;
            }
        }

        /// <summary>
        /// Constructor that creates player with one parametr
        /// </summary>
        /// <param name="n">count of ships</param>
        public Player(int n)
        {
            _ships = new Ship[n];
            _credits = 40;
        }
    }
}
