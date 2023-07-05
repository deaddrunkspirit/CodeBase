using System;
using Ships;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Randomizer
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// This array is counter for dead ships
        /// </summary>
        private int[] deathCount;

        /// <summary>
        /// This method generates random double number within given boundaries
        /// </summary>
        /// <param name="lower">lower bound of the number</param>
        /// <param name="upper">upper bound of the number</param>
        /// <returns></returns>
        private double GenerateDouble(int lower, int upper)
            => rnd.Next(lower, upper) + rnd.NextDouble();

        /// <summary>
        /// Each players' credits
        /// </summary>
        private int credits1, credits2;

        /// <summary>
        /// Ehen this property is true picking phase end and attacking phase begins
        /// </summary>
        private bool endPicking
            => credits1 + credits2 == 0 ? true : false;

        /// <summary>
        /// 50% chance whose turn is first 
        /// </summary>
        private int coin = rnd.Next(1, 3);

        /// <summary>
        /// Number of player which player acts first
        /// </summary>
        private int turnPlayer;

        /// <summary>
        /// Arrays of ships of each player
        /// </summary>
        private Ship[] FirstShips, SecShips;

        /// <summary>
        /// Indices of ships
        /// </summary>
        private int shipIndex1, shipIndex2;

        public Form1()
        {
            InitializeComponent();
            FirstShips = new Ship[5];
            SecShips = new Ship[5];
            shipIndex1 = 0;
            shipIndex2 = 0;
            deathCount = new int[2] { 0, 0 };
            phaseName.Text = "PICKING PHASE";
            credits1 = 40;
            creditsPlayer1.Text = "40";
            credits2 = 40;
            creditsPlayer2.Text = "40";
            turn.Visible = false;
            buttonAttack.Visible = false;
            shipInfo.Visible = false;
            giveCargo.Visible = false;
            label4.Visible = false;
            ammoChoice.Visible = false;
            turnPlayer = coin;
            turn.Text = turnPlayer == 1 ? "First player turn" : "Second player turn";
        }

        /// <summary>
        /// This method is to make active player ship attack inactive player ship, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonAttack_Click(object sender, EventArgs e)
        {
            try
            {
                messageBox.Clear();
                ListBox activeList = turnPlayer == 1 ? FirstPlayerShips : SecondPlayerShips;
                Ship[] activeShips = turnPlayer == 1 ? FirstShips : SecShips;
                ListBox attackedList = turnPlayer == 2 ? FirstPlayerShips : SecondPlayerShips;
                Ship[] attackedShips = turnPlayer == 2 ? FirstShips : SecShips;

                if (!(activeShips[activeList.SelectedIndex] is CargoShip))
                {
                    Ship attackedShip = attackedShips[attackedList.SelectedIndex];
                    AttackingShip actShip = (AttackingShip)activeShips[activeList.SelectedIndex];

                    int oppositeTurn = turnPlayer == 1 ? 2 : 1;
                    if (attackedShip.IsDead || actShip.IsDead)
                        throw new ArgumentException();

                    int cargoPossibility = rnd.Next(1, 6);
                    if ((attackedShip is CargoShip && cargoPossibility == 1 && deathCount[oppositeTurn - 1] < 3))
                        throw new ArgumentNullException();

                    actShip.Attack(attackedShip);
                    CheckDead(oppositeTurn, attackedShip);

                    CheckWin(activeShips, attackedShips);
                    turnPlayer = turnPlayer == 1 ? 2 : 1;
                    turn.Text = turnPlayer == 1 ? "First player turn" : "Second player turn";
                    messageBox.AppendText($"Dealing damage:" + Environment.NewLine +
                        Environment.NewLine + $"Attacking ship" + Environment.NewLine +
                        $"{actShip}" + Environment.NewLine + $"Attacked ship" +
                        Environment.NewLine + $"{attackedShip}" +
                        Environment.NewLine + $"Ship has been defeated: {attackedShip.IsDead}" +
                        Environment.NewLine + Environment.NewLine);
                }
            }
            catch (ArgumentNullException)
            {
                messageBox.Text = "Sorry not this time))" +
                    Environment.NewLine + Environment.NewLine +
                    "P.S. You can attack cargo only when your " +
                    "opponent have two or less ships with chance 20%!";
            }
            catch (ArgumentException)
            { messageBox.Text = "You cannot pick dead ship!"; }
        }

        /// <summary>
        /// This method checks if ship is dead
        /// </summary>
        /// <param name="player">number of the player</param>
        /// <param name="ships">ships to check for dead</param>
        private void CheckDead(int player, Ship ships)
        {
            deathCount[player - 1] += ships.IsDead ? 1 : 0;
        }

        /// <summary>
        /// This method transfer cargo from cargo ship to choosed ship
        /// </summary>
        private void giveCargo_Click(object sender, EventArgs e)
        {
            try
            {
                messageBox.Clear();
                ListBox activeList = turnPlayer == 1 ? FirstPlayerShips : SecondPlayerShips;
                Ship[] activeShips = turnPlayer == 1 ? FirstShips : SecShips;
                AttackingShip ship = (AttackingShip)activeShips[activeList.SelectedIndex];
                CargoShip cargoShip = new CargoShip(0, 0);
                for (int i = 0; i < activeShips.Length; i++)
                    if (activeShips[i] is CargoShip)
                        cargoShip = (CargoShip)activeShips[i];

                if (cargoShip.IsDead)
                    throw new ArgumentException();
                int cargo = int.Parse(ammoChoice.Text);
                if (cargo < 0 || cargo > cargoShip.Cargo)
                    throw new OverflowException();

                ship.TakeAmmo(cargo);
                cargoShip.Cargo -= cargo;
                messageBox.Clear();
                messageBox.AppendText(Environment.NewLine + "Ammo transfered successful!" 
                    + Environment.NewLine + cargoShip);
            }
            catch (ArgumentException)
            { messageBox.Text = "Cargo ship is dead!"; }
            catch (FormatException)
            { messageBox.Text = "Invalid value of cargo!"; }
            catch (OverflowException)
            { messageBox.Text = "Too big input!"; }
            catch (IndexOutOfRangeException)
            { messageBox.Text = "You haven't picked the ship!"; }
            catch (Exception ex) { messageBox.Text = "Error: " + ex.Message; }
        }

        /// <summary>
        /// This method adds outputs information about choosed ship to message box, 
        /// when corresponding button is clicked
        /// </summary>
        private void shipInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ListBox activeList = turnPlayer == 1 ? FirstPlayerShips : SecondPlayerShips;
                Ship[] activeShips = turnPlayer == 1 ? FirstShips : SecShips;


                messageBox.AppendText(Environment.NewLine + "Ship informstion:" +
                    Environment.NewLine + Environment.NewLine + activeShips[activeList.SelectedIndex]);
            }
            catch (ArgumentOutOfRangeException)
            { messageBox.Text = "There is no ship"; }
            catch (ArgumentException)
            { messageBox.Text = "You haven't picked correct ship"; }
            catch (IndexOutOfRangeException)
            { messageBox.Text = "You haven't picked correct ship!"; }
        }

        /// <summary>
        /// This method checks if any of players won
        /// </summary>
        /// <param name="ships1">first player ships</param>
        /// <param name="ships2">second player ships</param>
        private void CheckWin(Ship[] ships1, Ship[] ships2)
        {
            bool cargo1 = false, cargo2 = false, win1, win2, draw;
            for (int i = 0; i < ships1.Length; i++)
                if (ships1[i] is CargoShip)
                    cargo1 = true;
            for (int i = 0; i < ships2.Length; i++)
                if (ships2[i] is CargoShip)
                    cargo2 = true;
            win1 = cargo2 ? deathCount[1] == 4 : deathCount[1] == 5;
            win2 = cargo1 ? deathCount[0] == 4 : deathCount[0] == 5;
            draw = CheckDraw(ships1, ships2, cargo1, cargo2);
            if (win1)
            {
                MessageBox.Show("Congratulations player 1" + Environment.NewLine + "!!!You win!!!");
                
            }
            else if (win2)
            {
                MessageBox.Show("Congratulations player 2" + Environment.NewLine + "!!!You win!!!");
            }
            else if (draw)
            {
                MessageBox.Show("Draw");
            }
        }

        /// <summary>
        /// This method checks if there is draw condition
        /// </summary>
        /// <param name="ships1">first player ships</param>
        /// <param name="ships2">second player ships</param>
        /// <param name="cargo1">have first player a cargo ship?</param>
        /// <param name="cargo2">have second player a cargo ship?</param>
        /// <returns></returns>
        private bool CheckDraw(Ship[] ships1, Ship[] ships2, bool cargo1, bool cargo2)
        {
            bool draw;
            int noAmmo1 = 0, noAmmo2 = 0;
            for (int i = 0; i < ships1.Length; i++)
            {
                if (!(ships1[i] is CargoShip))
                {
                    AttackingShip s = (AttackingShip)ships1[i];
                    if (s.Ammo <= 0)
                        noAmmo1++;
                }
            }
            for (int i = 0; i < ships2.Length; i++)
            {
                if (!(ships2[i] is CargoShip))
                {
                    AttackingShip s = (AttackingShip)ships2[i];
                    if (s.Ammo <= 0)
                        noAmmo2++;
                }
            }
            draw = (cargo1 && cargo2 && (noAmmo1 + noAmmo2 == 8))
                || ((cargo1 && !cargo2 || !cargo1 && cargo2) && (noAmmo1 + noAmmo2 == 9))
                || (!cargo1 && !cargo2) && (noAmmo1 + noAmmo2 == 10) ? true : false;

            return draw;
        }

        /// <summary>
        /// This method ends picking phase and starts attacking phase
        /// </summary>
        private void PickingEnd()
        {
            if (endPicking)
            {
                buttonAttack.Visible = true;
                shipInfo.Visible = true;
                phaseName.Text = "ATTACKING PHASE";
                turn.Visible = true;

                bool cargo1 = false, cargo2 = true;
                var cShip1 = new CargoShip(0, 0); 
                var cShip2 = new CargoShip(0, 0);
                for (int i = 0; i < FirstShips.Length; i++)
                {
                    if (FirstShips[i] is CargoShip)
                    {
                        cShip1 = (CargoShip)FirstShips[i];
                        cargo1 = true;
                    }
                }

                for (int i = 0; i < SecShips.Length; i++)
                {
                    if (SecShips[i] is CargoShip)
                    {
                        cShip2 = (CargoShip)SecShips[i];
                        cargo2 = true;
                    }
                }

                if (turnPlayer == 1)
                {
                    giveCargo.Visible = cargo1 ? true : false;
                    label4.Visible = cargo1 ? true : false;
                    ammoChoice.Visible = cargo1 ? true : false;
                }
                else
                {
                    giveCargo.Visible = cargo2 ? true : false;
                    label4.Visible = cargo2 ? true : false;
                    ammoChoice.Visible = cargo2 ? true : false;
                }

            }
        }

        /// <summary>
        /// This method adds Battle ship to player 1 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonBatt1_Click(object sender, EventArgs e)
        {
            if (credits1 <= 0)
            {
                buttonBatt1.Visible = false;
                buttonDest1.Visible = false;
                buttonCargo1.Visible = false;
            }
            else
            {
                FirstShips[shipIndex1] = new Battleship(GenerateDouble(30, 70),
                        GenerateDouble(2000, 2500), rnd.Next(12, 18), rnd.Next(50, 71),
                        rnd.Next(5, 8), GenerateDouble(4500, 5500));
                credits1 -= 8;
                shipIndex1++;
                creditsPlayer1.Text = credits1.ToString();
                FirstPlayerShips.Items.Add("Battleship");
                PickingEnd();
            }
        }

        /// <summary>
        /// This method adds Destroyer to player 1 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonDest1_Click(object sender, EventArgs e)
        {
            if (credits1 <= 0)
            {
                buttonBatt1.Visible = false;
                buttonDest1.Visible = false;
                buttonCargo1.Visible = false;
                return;
            }
            else
            {
                FirstShips[shipIndex1] = new Destroyer(GenerateDouble(60, 100),
                        GenerateDouble(1000, 1800), rnd.Next(15, 23), rnd.Next(50, 71),
                        GenerateDouble(3800, 4500));
                credits1 -= 8;
                shipIndex1++;
                creditsPlayer1.Text = credits1.ToString();
                FirstPlayerShips.Items.Add("Destoyer");
                PickingEnd();
            }

        }

        /// <summary>
        /// This method adds Cargo ship to player 1 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonCargo1_Click(object sender, EventArgs e)
        {
            if (credits1 <= 0)
            {
                buttonBatt1.Visible = false;
                buttonDest1.Visible = false;
                buttonCargo1.Visible = false;
                return;
            }
            else
            {
                FirstPlayerShips.Items.Add("Cargo ship");
                FirstShips[shipIndex1] = new CargoShip(rnd.Next(40, 71),
                        GenerateDouble(1500, 2000));
                credits1 -= 8;
                shipIndex1++;
                creditsPlayer1.Text = credits1.ToString();
                buttonCargo1.Visible = false;
                PickingEnd();
            }
        }

        /// <summary>
        /// This method restarts the game by restarting application
        /// </summary>
        private void restartButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// This method adds Battle ship to player 2 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonBatt2_Click(object sender, EventArgs e)
        {
            if (credits2 <= 0)
            {
                buttonBatt2.Visible = false;
                buttonDest2.Visible = false;
                buttonCargo2.Visible = false;
                return;
            }
            else
            {
                SecShips[shipIndex2] = new Battleship(GenerateDouble(30, 70),
                        GenerateDouble(2000, 2500), rnd.Next(12, 18), rnd.Next(50, 71),
                        rnd.Next(5, 8), GenerateDouble(4500, 5500));
                credits2 -= 8;
                shipIndex2++;
                creditsPlayer2.Text = credits2.ToString();
                SecondPlayerShips.Items.Add("Battleship");
                PickingEnd();
            }
        }

        /// <summary>
        /// This method adds Destroyer to player 2 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonDest2_Click(object sender, EventArgs e)
        {
            if (credits2 <= 0)
            {
                buttonBatt2.Visible = false;
                buttonDest2.Visible = false;
                buttonCargo2.Visible = false;
                return;
            }
            else
            {
                SecShips[shipIndex2] = new Destroyer(GenerateDouble(60, 100),
                        GenerateDouble(1000, 1800), rnd.Next(15, 23), rnd.Next(50, 71),
                        GenerateDouble(3800, 4500));
                credits2 -= 8;
                shipIndex2++;
                creditsPlayer2.Text = credits2.ToString();
                SecondPlayerShips.Items.Add("Destoyer");
                PickingEnd();
            }
        }

        /// <summary>
        /// This method adds Cargo ship to player 2 ships, 
        /// when corresponding button is clicked
        /// </summary>
        private void buttonCargo2_Click(object sender, EventArgs e)
        {
            if (credits2 <= 0)
            {
                buttonBatt2.Visible = false;
                buttonDest2.Visible = false;
                buttonCargo2.Visible = false;
                return;
            }
            else
            {
                SecShips[shipIndex2] = new CargoShip(rnd.Next(40, 71),
                        GenerateDouble(1500, 2000));
                SecondPlayerShips.Items.Add("Cargo ship");
                credits2 -= 8;
                shipIndex2++;
                creditsPlayer2.Text = credits2.ToString();
                buttonCargo2.Visible = false;
                PickingEnd();
            }
        }
    }
}
