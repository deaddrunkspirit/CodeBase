/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import game_environment.Map;
import game_environment.Player;
import game_environment.Randomizer;
import java.io.BufferedReader;

public final class PenaltyCell implements ICell {
    private static final double penaltyCoeff = Randomizer.nextDouble(0.01, 0.1);
    private final int position;

    /**
     * This method prints penalty coefficient
     */
    public static void showPenaltyCoeff(){
        System.out.printf("\tPenalty Coefficient: %.2f\n", penaltyCoeff);
    }

    /**
     * This constructor creates a penalty cell on specified position
     * @param position position on the map
     */
    public PenaltyCell(int position){
        this.position = position;
    }

    /**
     * This method gets the position of the cell on the map
     * @param side number of the side on the map
     * @return position of the penalty cell
     */
    @Override
    public int getPosition(int side){
        return position;
    }

    /**
     * This method prints information about penalty cell
     * @param position position on the map
     */
    @Override
    public void printInfo(int position) {
        System.out.printf("=".repeat(46) + "\nPenalty Cell Info\n\tPosition " + position +
                "\n\tPenalty coefficient %.2f" + "\n" + "=".repeat(46) + "\n", penaltyCoeff);
    }

    /**
     * This method invokes cell event
     * @param player player who moves
     * @param opponent player's opponent
     * @param map game map
     * @param input buffer reader to get console input
     */
    @Override
    public void cellEvent(Player player, Player opponent, Map map, BufferedReader input) {
        int sum = (int) (player.getMoney() * penaltyCoeff);
        player.pay(sum);
        System.out.println(player.getName() + " paid " + sum + " as penalty");
    }

    /**
     * This method gets penalty cell representation on the map
     * @return string representation of penalty cell
     */
    @Override
    public String toString() {
        return "%";
    }
}
