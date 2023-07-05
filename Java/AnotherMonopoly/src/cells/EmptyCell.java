/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import game_environment.Map;
import game_environment.Player;
import java.io.BufferedReader;

public class EmptyCell implements ICell {
    private final int position;

    /**
     * This constructor creates an empty cell on specified position
     * @param position position on the map
     */
    public EmptyCell(int position){
        this.position = position;
    }

    /**
     * This method gets position of the cell on the map
     * @param side number of side on the map
     * @return position of the empty cell
     */
    @Override
    public int getPosition(int side){
        return position;
    }

    /**
     * This method prints information about an empty cell
     * @param position position on the map
     */
    @Override
    public void printInfo(int position) {
        System.out.println("=".repeat(46) + "\nEmpty Cell Info\n    Position: " + position + "\n" + "=".repeat(46));
    }

    /**
     * This method invokes a cell event
     * @param player player who moves
     * @param opponent player's opponent
     * @param map game map
     * @param input buffer reader to get console input
     */
    @Override
    public void cellEvent(Player player, Player opponent,
                          Map map, BufferedReader input) {
        System.out.println("Just relax there");
    }

    /**
     * This method gets a string representation of an empty cell on the map
     * @return string representation of the empty cell
     */
    @Override
    public String toString() {
        return "E";
    }
}
