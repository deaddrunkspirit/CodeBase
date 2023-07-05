/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

import cells.Bank;
import cells.ICell;
import cells.PenaltyCell;
import cells.Taxi;
import game_environment.Map;
import game_environment.Player;
import game_environment.Randomizer;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    /**
     * Main method that executes the program
     * @param args command prompt arguments that initialize width and height
     *             of the game map and the amount of player's and bot's money
     */
    public static void main(String[] args) {
        try (BufferedReader input = new BufferedReader(new InputStreamReader(System.in))){
            int money, width, height;
            if (args.length == 0){
                args = new String[] {"8", "6", "1000"};
            }
            width = Integer.parseInt(args[0]);
            height = Integer.parseInt(args[1]);
            money = Integer.parseInt(args[2]);
            var player = new Player("player", money);
            var bot = new Player("bot", money);
            Map map = preparation(width, height, player, bot);
            gameProcess(map, player, bot, input);
        }
        catch (IOException e){
            System.out.println(e.getMessage());
        }
    }

    /**
     * The loop method where the game process runs
     * @param map game map
     * @param player human player
     * @param bot bot player
     * @param input buffer reader to get input from console
     * @throws IOException buffer reader throws IOException
     */
    private static void gameProcess(Map map, Player player, Player bot,
                                    BufferedReader input) throws IOException{
        System.out.println("Press enter to continue . . .");
        input.readLine();
        int turn = Randomizer.nextInt(1, 2), turnNumber = 1;
        boolean botLose = bot.getIsLose(), playerLose = player.getIsLose();
        while (!botLose && !playerLose){
            printTurnInfo(turnNumber);
            int dice = throwDice();
            turn = makeMove(map, player, bot, input, turn, dice);
            System.out.println(map);
            turnNumber++;
            if (player.getMoney() < 0) player.lose();
            botLose = bot.getIsLose();
            if (bot.getMoney() < 0) bot.lose();
            playerLose = player.getIsLose();
        }
        String winner = getWinner(playerLose);
        System.out.println("\t\t\t\tGame over");
        System.out.println(winner);
    }

    /**
     * This method calculates either bot or player is the winner
     * @param playerLose property that says if player lost
     * @return message about winner
     */
    private static String getWinner(boolean playerLose) {
        return playerLose ? "!".repeat(46) + "\n\t " + "!".repeat(6) + "\t\tBot won \t\t" +
                "!".repeat(6) + "\n" + "!".repeat(46) : "!".repeat(46) + "\n\t " + "!".repeat(6) +
                "\t\tPlayer won\t\t" + "!".repeat(6) + "\n" + "!".repeat(46);
    }

    /**
     * This method prints information about current game turn
     * @param turnNumber number of current game turn
     */
    private static void printTurnInfo(int turnNumber) {
        System.out.println("+".repeat(46) + "\n" + "+".repeat(10) + "\t\tNow is " +
                turnNumber + " turn\t\t" + "+".repeat(10) + "\n" + "+".repeat(46));
    }

    /**
     * This method simulates throwing two dice
     * @return the sum of two dice
     */
    private static int throwDice() {
        return Randomizer.nextInt(1, 6) +
                Randomizer.nextInt(1, 6);
    }

    /**
     * This method decides which player moves and calls method that make player move
     * @param map game map
     * @param player human player
     * @param bot bot player
     * @param input buffer reader to get input from console
     * @param turn value of turn owner (if 1 - player, if 2 - bot)
     * @param dice dice sum
     * @return value of next turn owner
     * @throws IOException buffer reader throws exception
     */
    private static int makeMove(Map map, Player player, Player bot,
                                BufferedReader input, int turn, int dice) throws IOException {
        switch (turn){
            case 1:
                playerMove(dice, player, bot, map, input);
                turn = 2;
                break;
            case 2:
                playerMove(dice, bot, player, map, input);
                turn = 1;
                break;
        }
        return turn;
    }

    /**
     * This method calls method that prints messages about coefficients
     * and generates the game map than prints the map
     * and prints information about game players
     * @param width width of thee game map
     * @param height height of the game map
     * @param player human player
     * @param bot bot player
     * @return game map
     */
    private static Map preparation(int width, int height, Player player, Player bot){
        Map map = new Map(width, height);
        System.out.println(map);
        System.out.println("Coefficients");
        Bank.showCoefficients();
        PenaltyCell.showPenaltyCoeff();
        System.out.print("Players\n\t");
        bot.printInfo();
        System.out.print("_".repeat(46) + "\n\t");
        player.printInfo();
        System.out.println("_".repeat(46));
        return map;
    }

    /**
     * This method simulates player move around the map and
     * prints information about current cell
     * @param dice dice sum
     * @param player current player (can be a bot or human)
     * @param opponent opponent of current player (can be a bot or human)
     * @param map game map
     * @param input buffer reader to get input from console
     * @throws IOException buffer reader throws IOException
     */
    private static void playerMove(int dice, Player player, Player opponent, Map map,
                                   BufferedReader input) throws IOException {
        ICell currentCell = player.move(dice, map);
        player.printInfo();
        currentCell.printInfo(player.getPosition());
        currentCell.cellEvent(player, opponent, map, input);
        if (currentCell instanceof Taxi) {
            currentCell = map.getCell(player.getPosition());
            currentCell.printInfo(player.getPosition());
            currentCell.cellEvent(player, opponent, map, input);
        }
        System.out.println("Press enter to continue . . .");
        input.readLine();
    }
}
