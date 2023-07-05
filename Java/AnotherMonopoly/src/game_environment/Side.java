/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package game_environment;

import cells.*;

public class Side {
    private final ICell[] cells;
    private final int size;

    /**
     * This is constructor to create a side of the map
     * @param size count of all cells
     * @param bank bank instance (only one bank on the map)
     * @param sideCoeff coefficient to create correct cell indices
     * @param sideNumber number of the side on the map
     *                   (1: up, 2: right, 3: down, 4: left)
     */
    public Side(int size, Bank bank, int sideCoeff, int sideNumber){
        cells = new ICell[size];
        this.size = size;
        fillSide(bank, sideCoeff, sideNumber);
    }

    /**
     * This method gets a cell with specified index and direction
     * (rl - right-to-left, lr - left-to-right)
     * direction used because side representation of the map prints not correct
     * left and down sides need to be output in reverse to show map correctly
     * @param index index of the cell
     * @param direction direction of the side
     * @return index cell of the side
     */
    public ICell getCell(int index, String direction){
        ICell res;
        switch (direction){
            case "lr":
                res = cells[index];
                break;
            case "rl":
                res = cells[cells.length - 1 - index];
                break;
            default:
                throw new IllegalArgumentException("Invalid direction given!");
        }
        return res;
    }

    /**
     * This method creates cells and fills the side with them
     * @param bank bank instance (only one on game map)
     * @param sideCoeff coefficient to create correct cell indices
     * @param sideNumber number of the side on the map
     *                   (1: up, 2: right, 3: down, 4: left)
     */
    private void fillSide(Bank bank, int sideCoeff, int sideNumber){
        cells[0] = new EmptyCell(sideCoeff);
        cells[size - 1] = new EmptyCell(size + sideCoeff - 1);
        int bankPos;
        int taxiCount = Randomizer.nextInt(0,2);
        int penaltyCellCount = Randomizer.nextInt(0, 2);
        bankPos = Randomizer.nextInt(1, size - 1);
        for (int i = 1; i < size - 1; i++) {
            if (i == bankPos){
                cells[i] = bank;
                bank.setSidePosition(sideNumber, i + sideCoeff);
            }
            else if (taxiCount != 0 && penaltyCellCount != 0){
                int coin = Randomizer.nextInt(1, 2);
                cells[i] = nextCell(coin, i + sideCoeff);
                if (coin == 1) penaltyCellCount--;
                else taxiCount--;
            }
            else if (penaltyCellCount == 0 && taxiCount != 0){
                cells[i] = nextCell(2, i + sideCoeff);
                taxiCount--;
            }
            else if (penaltyCellCount != 0){
                cells[i] = nextCell(1, i + sideCoeff);
                penaltyCellCount--;
            }
            else cells[i] = nextCell(3, i + sideCoeff);
        }
    }

    /**
     * This method generates a new cell based on coin parameter
     * (1 - PenaltyCell, 2 - Taxi, 3 - Shop)
     * @param coin parameter to create
     * @param position position on the map where the cell is
     * @return generated cell
     */
    private ICell nextCell(int coin, int position){
        ICell res;
        switch (coin){
            case 1:
                res = new PenaltyCell(position);
                break;
            case 2:
                res = new Taxi(position);
                break;
            case 3:
                res = new Shop(position);
                break;
            default:
                throw new IllegalArgumentException("Invalid argument to get to the next cell!");
        }
        return res;
    }
}
