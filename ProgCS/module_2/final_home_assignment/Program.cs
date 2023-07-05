using System;
using Ships;
// TODO:
// 2 incapsulation?
namespace MainProgram
{
    public class Program
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Main plot of the program
        /// </summary>
        public static void Main()
        {
            do
            {
                Console.Clear();
                Player player1 = new Player(5);
                // create ship array for the first player
                Player player2 = new Player(5);
                // create ship array for the second player

                //Picking phase (Player 1)
                Console.WriteLine("PICKING PHASE\n----------");
                Console.WriteLine("First player turn\n");
                PlayerChoosingShips(player1); // Getting types of ships (user's choice)
                Console.Clear();
                Console.WriteLine("Player 1 ships\n\n");
                PrintPlayerShips(player1); // Showing picked ships
                Console.WriteLine("To end choosing press any key . . .");
                Console.ReadKey();
                Console.Clear();

                // Picking process (Player 2)
                Console.WriteLine("PICKING PHASE\n----------");
                Console.WriteLine("Second player turn\n");
                PlayerChoosingShips(player2); // Getting types of ships (user's choice)
                Console.Clear();
                Console.WriteLine("\n\nPlayer 2 ships\n\n");
                PrintPlayerShips(player2); // Showing picked ships
                Console.WriteLine("To end choosing press any key . . .");
                Console.ReadKey();
                Console.Clear();
                // End of the picking part

                int turn = rnd.Next(1, 3);
                int[] deathCount = new int[2] { 0, 0 }; // counter for dead ships

                bool cargo1, cargo2, win1, win2, draw; // conditions to end game

                // Conditions to end the game
                cargo1 = player1._ships[0] is CargoShip ? true : false; // have player 1 a cargoShip?
                cargo2 = player2._ships[0] is CargoShip ? true : false; // have player 2 a cargoShip?
                win1 = cargo2 ? deathCount[1] == 4 : deathCount[1] == 5; // endgame condition for player 1
                win2 = cargo1 ? deathCount[0] == 4 : deathCount[0] == 5; // endgame condition for player 2
                draw = CheckDraw(player1, player2, cargo1, cargo2);

                while (!win1 && !win2 && !draw) // Battle phase cycle
                {
                    Console.WriteLine("BATTLE PHASE\n----------");
                    BattlePhase(ref turn, player1, player2, deathCount,
                        ref win1, ref win2, cargo1, cargo2, ref draw);
                }

                // Show congrats to winner
                ShowWinner(player1, player2, win1, win2, draw);

                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("To exit program press Escape key" +
                    "\nTo restart press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// This method print information about winner 
        /// </summary>
        /// <param name="player1">first player</param>
        /// <param name="player2">second player</param>
        /// <param name="win1">win condition for first player</param>
        /// <param name="win2">win condition for second player</param>
        /// <param name="draw">draw condition for both players</param>
        private static void ShowWinner(Player player1, Player player2, bool win1, bool win2, bool draw)
        {
            if (win1)
            {
                Console.WriteLine("Congratulation player 1\nYou won !!!");
                PrintPlayerShips(player1);
                PrintPlayerShips(player2);
            }
            else if (win2)
            {
                Console.WriteLine("Congratulation player 2\nYou won !!!");
            }
            else if (draw)
            {
                Console.WriteLine("You played a draw");
                PrintPlayerShips(player1);
                PrintPlayerShips(player2);
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
        }

        /// <summary>
        /// This method checks if there is draw condition
        /// </summary>
        /// <param name="player1">first player</param>
        /// <param name="player2">second player</param>
        /// <param name="cargo1">have first player a cargo ship?</param>
        /// <param name="cargo2">have second player a cargo ship?</param>
        /// <returns></returns>
        private static bool CheckDraw(Player player1, Player player2, bool cargo1, bool cargo2)
        {
            bool draw;
            int noAmmo1 = 0, noAmmo2 = 0;
            if (cargo1)
            {
                for (int i = 1; i < player1._ships.Length; i++)
                {
                    AttackingShip s = (AttackingShip)player1[i];
                    if (s.Ammo <= 0)
                    {
                        noAmmo1++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < player1._ships.Length; i++)
                {
                    AttackingShip s = (AttackingShip)player1[i];
                    if (s.Ammo <= 0)
                    {
                        noAmmo1++;
                    }
                }
            }

            if (cargo2)
            {
                for (int i = 1; i < player2._ships.Length; i++)
                {
                    AttackingShip s = (AttackingShip)player2[i];
                    if (s.Ammo <= 0)
                    {
                        noAmmo2++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < player2._ships.Length; i++)
                {
                    AttackingShip s = (AttackingShip)player2[i];
                    if (s.Ammo <= 0)
                    {
                        noAmmo2++;
                    }
                }
            }

            draw = (cargo1 && cargo2 && (noAmmo1 + noAmmo2 == 8))
                || ((cargo1 && !cargo2 || !cargo1 && cargo2) && (noAmmo1 + noAmmo2 == 9))
                || (!cargo1 && !cargo2) && (noAmmo1 + noAmmo2 == 10) ? true : false;

            return draw;
        }

        /// <summary>
        /// This method is battle phase where player chooses 
        /// attacking ship and ship he wants to attack and deals
        /// damage to the ship, then passes turn to another player
        /// </summary>
        /// <param name="turn">number of player whose turn is now</param>
        /// <param name="player1">first player</param>
        /// <param name="player2">second player</param>
        /// <param name="deathCount">count of dead ship of eack user</param>
        /// <param name="win1">win condition for first player</param>
        /// <param name="win2">win condition for second player</param>
        /// <param name="cargo1">have first player a cargo ship?</param>
        /// <param name="cargo2">have second player a cargo ship?</param>
        /// <param name="draw">draw condition</param>
        private static void BattlePhase(ref int turn, Player player1, Player player2, int[] deathCount,
            ref bool win1, ref bool win2, bool cargo1, bool cargo2, ref bool draw)
        {
            Player activePlayer, attackedPlayer;
            InitializationOfPlayersShips(turn, player1, player2, out activePlayer, out attackedPlayer);
            Ship[] activePlayerShips = activePlayer._ships;
            Ship[] attackedShips = attackedPlayer._ships;
            
            int oppTurn = turn == 1 ? 2 : 1; // calculate attacked player number
            int cargoAttack = rnd.Next(1, 6); // possibility of attacing cargo ship (20%)

            AttackMenu(activePlayerShips);
            AttackingShip actingShip = ChooseAttackShip(activePlayerShips);

            // Taking ammunition from cargo ship
            if (activePlayerShips[0] is CargoShip && !activePlayerShips[0].IsDead)
                TakeAmmunition((CargoShip)activePlayerShips[0], actingShip);

            

            // display to chose attacked ship
            DefendMenu(attackedShips, deathCount, oppTurn, cargoAttack);
            // making a choice of a ship
            Ship attackedShip = ChooseDefendShip(attackedShips, cargoAttack, deathCount, oppTurn);

            // deals damage to attacked ship
            actingShip.Attack(attackedShip);

            Console.Clear();
            //Show dealt damage
            ShowDamage(turn, actingShip, attackedShip, attackedShip.IsDead);
            Console.ReadKey();
            
            deathCount[0] = 0;
            deathCount[1] = 0;

            // Counting dead ships
            IncreaseDeathCount(turn, deathCount, attackedShips);

            win1 = cargo1 ? deathCount[1] == 4 : deathCount[1] == 5; // win condition for player 1
            win2 = cargo2 ? deathCount[0] == 4 : deathCount[0] == 5; // win condition for player 2
            draw = CheckDraw(player1, player2, cargo1, cargo2); // draw condition endgame

            turn = oppTurn; // turn pass
        }

        /// <summary>
        /// Initialize in case of turn who attacks who
        /// </summary>
        /// <param name="turn">number of the player whose turn is</param>
        /// <param name="player1">first player</param>
        /// <param name="player2">second player</param>
        /// <param name="activePlayer">player who attacks</param>
        /// <param name="attackedPlayer">player who takes damage</param>
        private static void InitializationOfPlayersShips(int turn, Player player1, Player player2,
            out Player activePlayer, out Player attackedPlayer)
        {
            Console.WriteLine($"Now the turn of {turn} player");
            activePlayer = new Player(5);
            attackedPlayer = new Player(5);
            switch (turn)
            {
                case 1:
                    activePlayer = player1;
                    attackedPlayer = player2;
                    break;
                case 2:
                    activePlayer = player2;
                    attackedPlayer = player1;
                    break;
            }
        }

        /// <summary>
        /// This method increasing count of dead ships
        /// </summary>
        /// <param name="turn">number of player whose turn is</param>
        /// <param name="deathCount">count of dead ships</param>
        /// <param name="attackedShips">ships that can be defeated this turn</param>
        private static void IncreaseDeathCount(int turn, int[] deathCount, Ship[] attackedShips)
        {
            for (int i = 0; i < attackedShips.Length; i++)
                if (attackedShips[i].IsDead)
                    deathCount[turn - 1]++;
        }

        /// <summary>
        /// This method shows information about ships after attack 
        /// </summary>
        /// <param name="turn">number of player whose turn is now</param>
        /// <param name="attackingShip">attacking ship</param>
        /// <param name="attackedShip">attacked ship</param>
        /// <param name="dead">check if ship is dead</param>
        private static void ShowDamage(int turn, AttackingShip attackingShip, Ship attackedShip, bool dead)
        {
            string deathMessage = dead ? $"\nShip has been defeated" : "";
            Console.WriteLine($"{turn} player's {attackingShip.Type}\n " +
                $"deals damage to other player's {attackedShip.Type}\n\n" +
                $"Attacking ship info{attackingShip}\n\nAttacked ship info{attackedShip}" +
                $"{deathMessage}\n----------\n");
        }

        /// <summary>
        /// This method let player make a transfer
        /// of ammunition from cargo ship to attacking ship
        /// </summary>
        /// <param name="cargoShip">player's cargo ship</param>
        /// <param name="attackingShip">player'sattacking ship</param>
        private static void TakeAmmunition(CargoShip cargoShip, AttackingShip attackingShip)
        {
            Console.WriteLine("Do you want to transfer ammunition from a cargo" +
                " ship to attacking ship\nYes: Y\nNo: any other key . . .");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                int cargo = GetInt(0, cargoShip.Cargo,
                    $"How much ammunition you want to transfer?\nInput integer: ");
                attackingShip.TakeAmmo(cargo);
                cargoShip.GiveAmmo(cargo);
                Console.WriteLine("Amminition transfered successful" +
                    "\n\nTo continue press any key");
                Console.ReadKey();
                Console.Clear();

            }
        }

        /// <summary>
        /// This method gets the ship which player choose as an attacking
        /// </summary>
        /// <param name="ships">array of users ships</param>
        /// <returns></returns>
        private static AttackingShip ChooseAttackShip(Ship[] ships)
        {
            int choice;
            Ship ship;
            if (ships[0] is CargoShip)
            {
                do
                {
                    Console.WriteLine("Remember\nYou can't choose dead ship");
                    choice = GetInt(2, 5);
                } while (ships[choice - 1].IsDead);
                ship = ships[choice - 1];
            }
            else
            {
                do
                {
                    Console.WriteLine("Remember\nYou can't choose dead ship");
                    choice = GetInt(1, 5);
                } while (ships[choice - 1].IsDead);
                ship = ships[choice - 1];
            }

            return (AttackingShip)ship;
        }



        /// <summary>
        /// This method gets from player the ship which he wants to attack
        /// </summary>
        /// <param name="ships">ships player is atttacking</param>
        /// <param name="cargoAttack">chance to attack cargo</param>
        /// <param name="deathCount">count of all dead ships</param>
        /// <param name="oppTurn">number of attacked player</param>
        /// <returns></returns>
        private static Ship ChooseDefendShip(Ship[] ships, int cargoAttack, int[] deathCount, int oppTurn)
        {
            int choice;
            Ship ship;

            if (ships[0] is CargoShip)
            {
                if (cargoAttack == 1 && deathCount[oppTurn - 1] >= 3)
                {
                    do
                    {
                        Console.WriteLine("Remember\nYou can't choose dead ship");
                        choice = GetInt(1, 5);
                    } while (ships[choice - 1].IsDead);

                    ship = ships[choice - 1];
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Remember\nYou can't choose dead ship");
                        choice = GetInt(2, 5);
                    } while (ships[choice - 1].IsDead);

                    ship = ships[choice - 1];
                }
            }
            else
            {
                do
                {
                    Console.WriteLine("Remember\nYou can't choose dead ship");
                    choice = GetInt(1, 5);
                } while (ships[choice - 1].IsDead);

                ship = ships[choice - 1];
            }

            return ship;
        }

        /// <summary>
        /// This method prints menu of attacking ships
        /// </summary>
        /// <param name="ships">array of active player's ships</param>
        private static void AttackMenu(Ship[] ships)
        {
            Console.Write($"Choose which ship attacks\n==========");

            for (int i = 0; i < 5; i++)
            {
                if (ships[i] is CargoShip)
                {
                    i++;
                }
                Console.Write($"\n || {i + 1}: { ships[i]}");
            }
            Console.WriteLine("\n==========\n\n");
        }

        /// <summary>
        /// This method prints menu to choose attacked ship
        /// </summary>
        /// <param name="ships">array of attacked player's ships</param>
        /// <param name="deathCount">array with count of 
        /// death ships of each player</param>
        /// <param name="oppTurn">number of attacked player</param>
        /// <param name="cargoAttack">possibility of attacking cargoship</param>
        private static void DefendMenu(Ship[] ships, int[] deathCount,
            int oppTurn, int cargoAttack)
        {
            string res = $"Choose ship you want to attack\n==========";

            if (cargoAttack == 1 && deathCount[oppTurn - 1] >= 3)
                res += $"\n || 1: { ships[0]}";

            for (int i = 1; i < 5; i++)
                res += $"\n || {i + 1}: { ships[i]}";

            Console.WriteLine(res + "\n==========\n");
        }

        /// <summary>
        /// This method prints all ships of player
        /// </summary>
        /// <param name="player">player whose ship prints</param>
        private static void PrintPlayerShips(Player player)
        {
            for (int i = 0; i < 5; i++)
                Console.WriteLine(player[i]);

        }

        /// <summary>
        /// This method gets the ships player chooses
        /// </summary>
        /// <param name="player">player who is asked to pick cargo ship</param>
        private static void PlayerChoosingShips(Player player)
        {
            int shipCount = 0;
            CargoShipChoice(player, ref shipCount);

            while (shipCount < 5)
            {
                Console.Clear();
                PickShipMenu(player._credits);
                ChooseShip(player, ref shipCount);
            }
        }

        /// <summary>
        /// This method gets from user wether 
        /// he choose cargo ship or he does not 
        /// </summary>
        /// <param name="player">player's ships</param>
        /// <param name="shipCount">number of the ship</param>
        private static void CargoShipChoice(Player player, ref int shipCount)
        {
            Console.WriteLine("Do you want to take a Cargo ship?" +
                            "\n\nIf yes press Y key else press any key . . .");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                player._credits -= 8;
                player[0] = new CargoShip(rnd.Next(40, 71),
                    GenerateDouble(1500, 2000));
                shipCount++;
            }
        }

        /// <summary>
        /// This method gets from user which ships he chooses
        /// </summary>
        /// <param name="player">player's ships</param>
        /// <param name="shipCount">number of the ship</param>
        private static void ChooseShip(Player player, ref int shipCount)
        {
            int n = GetInt(1, 2);
            switch (n)
            {
                case 1:
                    player._credits -= 8;
                    Console.WriteLine($"You picked Battleship (cost 8)" +
                        $"\nCredits left {player._credits}");
                    player[shipCount] = new Battleship(GenerateDouble(30, 70),
                        GenerateDouble(2000, 2500), rnd.Next(12, 18), rnd.Next(50, 71),
                        rnd.Next(5, 8), GenerateDouble(4500, 5500)); // input incorrect
                    shipCount++;
                    break;
                case 2:
                    player._credits -= 8;
                    Console.WriteLine($"You picked Destroyer (cost 8)" +
                        $"\nCredits left {player._credits}");
                    player[shipCount] = new Destroyer(GenerateDouble(60, 100),
                        GenerateDouble(1000, 1800), rnd.Next(15, 23), rnd.Next(50, 71),
                        GenerateDouble(3800, 4500)); 
                    shipCount++;
                    break;
                default:
                    Console.WriteLine("Wrong choice!!!");
                    break;
            }
        }

        /// <summary>
        /// This method generates random double value
        /// </summary>
        /// <param name="lower">lower bound of random double value</param>
        /// <param name="upper">upper bound of random double value</param>
        /// <returns></returns>
        private static double GenerateDouble(int lower = 1, int upper = 100)
            => rnd.Next(lower, upper) + rnd.NextDouble();

        /// <summary>
        /// This method is menu to pick ships 
        /// </summary>
        /// <param name="credits">credits left</param>
        private static void PickShipMenu(int credits)
        {
            Console.WriteLine("|Pick your ship|\n==========\n" +
                "||1: Battleship (cost 8 credits)\n" +
                "||2: Destroyer (cost 8 credits)\n==========\n\n" +
                $"Credits left: {credits}\n\n");
        }

        /// <summary>
        /// This method gets an integer from user
        /// </summary>
        /// <param name="str">message for user</param>
        /// <param name="lower">lower bound of the integer</param>
        /// <param name="upper">upper bound of the integer</param>
        /// <returns></returns>
        private static int GetInt(int lower = 1, int upper = int.MaxValue,
            string str = "Your choice: ")
        {
            Console.Write(str);
            int n;
            while (!int.TryParse(Console.ReadLine(), out n)
                || n < lower || n > upper)
            {
                Console.WriteLine($"Incorrect input" +
                    $"\nPlease input integer number in [{lower}, {upper}]");
            }

            return n;
        }
    }
}
