/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import game_environment.Randomizer;
import game_environment.Map;
import game_environment.Player;
import java.io.BufferedReader;

public class Taxi implements ICell {
    private int taxiDistance;
    private final int position;

    /**
     * This constructor creates a Taxi cell with specified position
     * @param position position on the map
     */
    public Taxi(int position){
        this.position = position;
    }

    /**
     * This method gets position of the cell on the map
     * @param side number of the side on the map
     * @return position of the cell on the map
     */
    @Override
    public int getPosition(int side){
        return position;
    }

    /**
     * This method invokes a cell event
     * @param player player standing on the cell
     * @param opponent player's opponent
     * @param map game map
     * @param input buffer reader to get console input
     */
    @Override
    public void cellEvent(Player player, Player opponent,
                          Map map, BufferedReader input) {
        taxiDistance = Randomizer.nextInt(3, 5);
        player.move(taxiDistance, map);
        System.out.println("You are shifted forward by "
                + taxiDistance + " cells");
        map.getCell(player.getPosition());
    }

    /**
     * This method prints information about a taxi instance
     * @param position taxi position on the map
     */
    @Override
    public void printInfo(int position) {
        System.out.println("=".repeat(46) + "\nTaxi Info" +
                "\n\tPosition " + position + "\n\tDistance "
                + taxiDistance + "\n" + "=".repeat(46));
    }

    /**
     * This method gets a string representation of the taxi on the map
     * @return string representation of the taxi
     */
    @Override
    public String toString() {
        return "T";
    }
}
