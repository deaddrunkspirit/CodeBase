/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */
package game_environment;

import cells.Bank;
import cells.ICell;

public class Map {
    private final int width;
    private final int height;
    private final Side[] sides;

    /**
     * This constructor creates a map with specified width and height
     * @param width width of the map
     * @param height height of the map
     */
    public Map(int width, int height){
        this.height = height;
        this.width = width;
        Bank bank = new Bank();
        sides = new Side[4];
        fillMap(bank);
    }

    /**
     * This method gets the count of cells on the map
     * @return map size
     */
    public int getSize(){
        return height * 2 + width * 2 - 4;
    }

    /**
     * This method gets a cell on the map with specified index
     * @param position position of the cell on the map
     * @return cell on specified position
     */
    public ICell getCell(int position){
        Side side;
        side = getSide(position);
        if (side == sides[0]){
            return side.getCell(position - 1, "lr");
        }
        else if (side == sides[1]){
            return side.getCell(position - width, "lr");
        }
        else if (side == sides[2]){
            return side.getCell(position - height - width + 1, "rl");
        }
        else {
            return side.getCell(position - height - width * 2 + 2, "rl");
        }
    }

    /**
     * This method gets the side cased on its position
     * (1 - up, 2 - right, 3 - down, 4 - left)
     * @param position position of the side on the game map
     * @return side with specified position
     */
    private Side getSide(int position) {
        Side side;
        if (position >= 1 && position <= width){
            side = sides[0];
        }
        else if (position > width && position < width + height - 1){
            side = sides[1];
        }
        else if (position >= width + height - 1 && position <= width * 2 + height - 2){
            side = sides[2];
        }
        else if (position > width * 2 + height - 2 && position < width * 2 + height * 2 - 3){
            side = sides[3];
        }
        else throw new IllegalArgumentException("Invalid position!");
        return side;
    }

    /**
     * This method fills the map by filling its sides
     * @param bank bank instance (only one on the map)
     */
    private void fillMap(Bank bank){
        sides[0] = new Side(width, bank, 1, 1);
        sides[1] = new Side(height, bank, width, 2);
        sides[2] = new Side(width, bank, width + height - 1, 3);
        sides[3] = new Side(height, bank, width * 2 + height - 2, 4);
    }

    /**
     * This method appends the third side to map string representation
     * @param stringBuilder string builder instance to append third side
     */
    private void appendThirdSide(StringBuilder stringBuilder) {
        stringBuilder.append(" ".repeat(4));
        for (int i = 0; i < width; i++) {
            if (i < 9) {
                stringBuilder.append(sides[2].getCell(i, "rl")).append(" ".repeat(4));
            }
            else{
                stringBuilder.append(sides[2].getCell(i, "rl")).append(" ".repeat(5));
            }
        }
        stringBuilder.append("\n    ");
        for (int i = 0; i < width; i++) {
            if (i < 9) {
                stringBuilder.append(sides[2].getCell(i, "rl").getPosition(3)).append(" ".repeat(3));
            }
            else {
                stringBuilder.append(sides[2].getCell(i, "rl").getPosition(3)).append(" ".repeat(4));
            }
        }
        stringBuilder.append("\n").append("m".repeat(46));
    }

    /**
     * This method appends the second and fourth sides to map string representation
     * @param stringBuilder string builder instance to append second and fourth sides
     */
    private void appendSecondAndFourthSide(StringBuilder stringBuilder) {
        for (int i = 1; i < height - 1; i++) {
            ICell left = sides[3].getCell(i, "rl");
            ICell right = sides[1].getCell(i, "lr");
            if (left.getPosition(4) >= 100){
                stringBuilder.append(left.getPosition(4)).append(" ").append(left.toString());
            }
            else{
                stringBuilder.append(left.getPosition(4)).append("  ").append(left.toString());
            }
            if (width < 10){
                stringBuilder.append(" ".repeat(10 - width));
            }
            stringBuilder.append(" ".repeat(width * 6 - 4 * 4));
            stringBuilder.append(right.toString()).append("    ");
            stringBuilder.append(right.getPosition(2)).append("\n");
        }
    }

    /**
     * This method appends the first side to map string representation
     * @param stringBuilder string builder instance to append first side
     */
    private void appendFirstSide(StringBuilder stringBuilder) {
        stringBuilder.append("m".repeat(46)).append("\n");
        stringBuilder.append("    ");
        for (int i = 0; i < width; i++) {
            stringBuilder.append(sides[0].getCell(i, "lr").getPosition(1)).append("    ");
        }
        stringBuilder.append("\n    ");
        for (int i = 0; i < width; i++) {
            if (i < 9) {
                stringBuilder.append(sides[0].getCell(i, "lr").toString()).append(" ".repeat(4));
            }
            else stringBuilder.append(sides[0].getCell(i, "lr").toString()).append(" ".repeat(5));
        }
        stringBuilder.append("\n");
    }

    /**
     * This method creates a string representation of the map
     * @return string representation of the map
     */
    @Override
    public String toString(){
        StringBuilder res = new StringBuilder();
        appendFirstSide(res);
        appendSecondAndFourthSide(res);
        appendThirdSide(res);
        return res.toString();
    }
}
