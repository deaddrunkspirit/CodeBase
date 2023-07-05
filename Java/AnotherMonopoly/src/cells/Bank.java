/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import java.io.BufferedReader;
import java.io.IOException;
import game_environment.Map;
import game_environment.Player;
import game_environment.Randomizer;

public class Bank implements ICell {
    private static final double debtCoeff = Randomizer.nextDouble(1, 3);
    private static final double creditCoeff = Randomizer.nextDouble(0.002, 0.2);
    private final int[] positions;

    /**
     * This constructor creates a bank instance
     */
    public Bank(){
        positions = new int[4];
    }

    /**
     * This method shows debt and credit coefficients
     */
    public static void showCoefficients() {
        System.out.printf("\tDebt coefficient: %.2f\n", debtCoeff);
        System.out.printf("\tCredit coefficient: %.2f\n", creditCoeff);
    }

    /**
     * This method sets the positions of the banks on different sides
     * @param sideNumber number of the side on the map
     * @param position position of the bank on specified side
     */
    public void setSidePosition(int sideNumber, int position){
        positions[sideNumber - 1] = position;
    }

    /**
     * This method simulates player borrowing money from bank process
     * @param player player who receives money from bank
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    public void giveMoney(Player player, BufferedReader input) throws IOException {
        double maxSum = creditCoeff * player.getSpendMoney();
        System.out.println("Input the amount of money you want to borrow (in range (0, " + (int)(maxSum) +"])");
        String strAmount = input.readLine();
        int amount = Integer.parseInt(strAmount);
        while (amount > maxSum || amount < 0) {
            System.out.println("Input an integer number in range (0, " + (int)maxSum + "]");
            strAmount = input.readLine();
            amount = Integer.parseInt(strAmount);
        }
        player.borrow(amount);
    }

    /**
     * This method makes player pay his debt
     * @param player human player only
     */
    public void Charge(Player player){
        int debt = player.getDebt();
        if (player.getMoney() >= debt) player.payBack();
        else player.lose();
    }

    /**
     * This method gets a user choice about borrowing or not money from the bank
     * @param input buffer reader to get console input
     * @return user choice
     * @throws IOException buffer reader throws IOException
     */
    private String getChoice(BufferedReader input) throws IOException {
        System.out.println("Do you want to borrow money from bank?" +
                "\nPrint 'Yes' if you want and 'No' otherwise");
        String choice = input.readLine();
        while (!choice.equals("Yes") && !choice.equals("No")){
            choice = input.readLine();
        }
        return choice;
    }

    /**
     * This method gets the position of the bank on the map
     * @param side number of the side on the map
     * @return bank position
     */
    @Override
    public int getPosition(int side){
        return positions[side - 1];
    }

    /**
     * This method prints information about the bank cell
     * @param position position of the bank cell on the map
     */
    @Override
    public void printInfo(int position) {
        System.out.println("=".repeat(46) + "\nBank Info\n\tPosition " + position);
        Bank.showCoefficients();
        System.out.println("=".repeat(46));
    }

    /**
     * This method invokes the event of the map
     * @param player player who moves
     * @param opponent player's opponent
     * @param map game map
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    @Override
    public void cellEvent(Player player, Player opponent, Map map, BufferedReader input) throws IOException {
        if (player.getName().equals("player")) {
            if (player.getIsDebtor()) {
                Charge(player);
            }
            else if (player.getSpendMoney() != 0) {
                boolean incorrectInput = true;
                do {
                    try {
                        String choice = getChoice(input);
                        if (choice.equals("Yes")) giveMoney(player, input);
                        incorrectInput = false;
                    } catch (NullPointerException e) {
                        System.out.println("Don't try to input Ctrl + Z");
                    }
                } while(incorrectInput);
            }
        }
    }

    /**
     * This method gets a string representation of the Bank on the map
     * @return string representation of the bank
     */
    @Override
    public String toString() {
        return "$";
    }
}
