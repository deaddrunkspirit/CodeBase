/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package game_environment;

import cells.ICell;

public class Player {
    private final String name;
    private double wallet;
    private double spendMoney;
    private int debt;
    private int position;
    private boolean isLose;
    private boolean isDebtor;

    /**
     * This constructor creates a player with a special name
     * that means either the player is human or bot
     * @param name type of the player
     * @param money amount of start money
     */
    public Player(String name, int money){
        this.name = name;
        spendMoney = 0;
        wallet = money;
        isLose = false;
        isDebtor = false;
        debt = 0;
        position = 1;
    }

    /**
     * This method gets the amount of player's money
     * @return player's money
     */
    public double getMoney(){
        return wallet;
    }

    /**
     * Gets the type of the player
     * @return player type
     */
    public String getName(){
        return name;
    }

    /**
     * Gets player's status in bank.
     * Checks either he owes money to the bank or no
     * @return debtor status
     */
    public boolean getIsDebtor(){
        return isDebtor;
    }

    /**
     * Gets the player's lose status
     * (if isLose is true it means that player lost)
     * @return lose status
     */
    public boolean getIsLose(){
        return  isLose;
    }

    /**
     * Gets the amount of debt player owes to the bank
     * @return debt amount
     */
    public int getDebt(){
        return debt;
    }

    /**
     * Gets the amount of money player used to buy/upgrade shops
     * @return amount of spend money
     */
    public double getSpendMoney() {
        return spendMoney;
    }

    /**
     * Gets the position of the player on the game map
     * @return position on the game map
     */
    public int getPosition(){
        return position;
    }

    /**
     * This method borrows money from the bank
     * and sets player's debt status to active (true)
     * @param sum sum player borrows from the bank
     */
    public void borrow(double sum){
        wallet += sum;
        debt += sum;
        isDebtor = true;
    }

    /**
     * This method pays the debt back to the bank, than checks if player lost
     */
    public void payBack(){
        wallet -= debt;
        debt = 0;
        isDebtor = false;
        if (wallet < 0){
            this.lose();
        }
    }

    /**
     * This method sets player's lose status to true
     */
    public void lose(){
        isLose = true;
    }

    /**
     * This method moves player around the map
     * @param count count of cells to move forward
     * @param map map where player moves
     * @return new cell where player stands now
     */
    public ICell move(int count, Map map){
        position += count;
        position %= map.getSize();
        if (position == 0){
            position++;
        }
        return map.getCell(position);
    }

    /**
     * This method simulates paying process
     * @param sum sum player pays
     */
    public void pay(double sum){
        wallet -= sum;
        spendMoney += sum;
    }

    /**
     * This method simulates receiving money process
     * @param sum sum player receives
     */
    public void receive(double sum){
        wallet += sum;
    }

    /**
     * This method prints information about player
     */
    public void printInfo(){
        System.out.printf(name + "\n\tbalance:\t%.2f$\n", wallet);
        System.out.println("\tdebt:\t\t" + debt + "$\n\tposition:\t" + position);
    }
}
