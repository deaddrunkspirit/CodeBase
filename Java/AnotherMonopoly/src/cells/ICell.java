/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import game_environment.Map;
import game_environment.Player;
import java.io.BufferedReader;
import java.io.IOException;

public interface ICell {
    int getPosition(int side);
    void printInfo(int pos);
    void cellEvent(Player player, Player opponent, Map map, BufferedReader reader) throws IOException;
}
