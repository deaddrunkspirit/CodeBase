/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package cells;

import game_environment.Randomizer;
import game_environment.Map;
import game_environment.Player;
import java.io.BufferedReader;
import java.io.IOException;


public class Shop implements ICell {
    private String status;
    private int N;
    private int K;
    private final int position;
    private final double improvementCoeff;
    private final double compensationCoeff;

    /**
     * This constructor creates a shop on specified position on the map
     * @param position shop position on the map
     */
    public Shop(int position){
        status = "S";
        this.position = position;
        N = Randomizer.nextInt(50, 500);
        K = (int)Math.round(Randomizer.nextDouble(0.5, 0.9) * N);
        improvementCoeff = Randomizer.nextDouble(0.1, 2);
        compensationCoeff = Randomizer.nextDouble(0.1, 1);

    }

    /**
     *
     */
    public void upgrade(){
        N += improvementCoeff * N;
        K += compensationCoeff * K;
    }

    /**
     * This method changes the status of the shop, if someone buys it
     * @param owner new owner of the shop (can be a bot or a player)
     */
    public void changeStatus(String owner){
        switch(owner){
            case "bot":
                status = "O";
                break;
            case "player":
                status = "M";
                break;
            case "free":
                status = "S";
            default:
                throw new IllegalArgumentException("Invalid shop owner!");
        }
    }

    /**
     * This method simulates process when player pays compensation to his opponent
     * @param player player who is paying compensation
     * @param opponent player who receives compensation
     */
    private void payCompensation(Player player, Player opponent){
        if (player.getMoney() >= K) {
            player.pay(K);
            opponent.receive(K);
            System.out.println(player.getName() + " paid " + K + "$ to "
                    + opponent.getName() + " for shop on position" + position);
        }
        else player.lose();
    }

    /**
     * This method decides who is upgrading the shop and calls the method to upgrade
     * @param player player who moves now
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    private void upgradeShop(Player player,
                             BufferedReader input) throws IOException {
        if (player.getName().equals("player")){
            playerUpgrade(player, input);
        }
        else if (player.getName().equals("bot")){
            botUpgrade(player);
        }
        else throw new IllegalArgumentException("Unexpected player name!");
    }

    /**
     * This method simulates upgrading process if player is human
     * @param player bot player
     */
    private void botUpgrade(Player player) {
        int possibility = Randomizer.nextInt(1, 100);
        if (possibility > 30 && player.getMoney() > N){
            player.pay(N * improvementCoeff);
            upgrade();
            System.out.println("Bot has upgraded shop. New info:");
            this.printInfo(position);
        }
        else{
            System.out.println("Bot hasn't upgrade the shop.");
        }
    }

    /**
     * This method simulates upgrading process if player is human
     * @param player human player
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    private void playerUpgrade(Player player, BufferedReader input)
            throws IOException {
        System.out.println("You are in your shop (position " + position + ").");
        System.out.println("Would you like to upgrade it for " + N + "$?");
        System.out.println("Input 'Yes' if you agree or 'No' otherwise");
        String choice = input.readLine();
        while (!choice.equals("Yes") && !choice.equals("No")) {
            System.out.println("Please input 'Yes' or 'No' . . .");
            choice = input.readLine();
        }
        if (choice.equals("Yes")){
            player.pay(N * improvementCoeff);
            upgrade();
            System.out.println("You upgraded the shop. New info:");
            this.printInfo(position);
        }
    }

    /**
     * This method decides who is buying the shop and call the simulation method
     * @param player player (either human or bot)
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    private void buyShop(Player player, BufferedReader input) throws IOException {
        if (player.getName().equals("player")) {
            playerBuys(player, input);
        }
        else  if (player.getName().equals("bot")){
            botBuys(player);
        }
    }

    /**
     * This method simulates buying process if player is bot
     * @param player bot player
     */
    private void botBuys(Player player) {
        if (player.getMoney() < N) return;
        int possibility = Randomizer.nextInt(1, 100);
        if (possibility > 30 && player.getMoney() > N){
            changeStatus(player.getName());
            player.pay(N);
            System.out.println("Bot has bought shop (position "
                    + position +") for " + N + "$.");
            this.printInfo(position);
        }
        else{
            System.out.println("Bot hasn't bought the shop (position "
                    + position + ") for " + N + "$.");
        }
    }

    /**
     * This method simulates buying process if player is human
     * @param player human player
     * @param input buffer reader to get console input
     * @throws IOException buffer reader throws IOException
     */
    private void playerBuys(Player player, BufferedReader input) throws IOException {
        System.out.println("You are in the shop (position " + position + ").\nWould you " +
                "like to buy it for " + N + "$?\nInput 'Yes' if you agree or " +
                "'No' otherwise\nYour answer: ");
        boolean incorrectInput = true;
        do {
            try {
                String choice = input.readLine();
                while (!choice.equals("Yes") && !choice.equals("No")) {
                    System.out.println("Please input 'Yes' or 'No' . . .");
                    choice = input.readLine();
                }
                if (choice.equals("Yes")) {
                    changeStatus(player.getName());
                    player.pay(N);
                    this.printInfo(position);
                }
                incorrectInput = false;
            } catch (NullPointerException e) {
                System.out.println("Don't try to input Ctrl + Z");
            }
        } while(incorrectInput);
    }

    /**
     * This method gets the cell on specified position
     * @param side number of the side on the map
     * @return position of the cell
     */
    @Override
    public int getPosition(int side){
        return position;
    }

    /**
     * This method prints information about the cell
     * @param position position of the cell on the map
     */
    @Override
    public void printInfo(int position) {
        String owner = status.equals("F") ? "Free" : status.equals("M") ? "player" : "bot";
        System.out.println("=".repeat(46) + "\nShop Info\n\tPosition " + position);
        System.out.printf("\tCompensation coefficient: %.2f\n", compensationCoeff);
        System.out.printf("\tImprovement coefficient:  %.2f\n", improvementCoeff);
        System.out.println("\tShop cost:\t\t" + N + "\n" + "\tShop owner:\t\t" + owner
                + "\n\tCompensation:\t" + K + "\n" + "=".repeat(46));
    }

    /**
     * This method invokes cell event
     * @param player player standing on the cell
     * @param opponent player's opponent
     * @param map game map
     * @param input buffer reader to get input from console
     * @throws IOException buffer reader throws IOException
     */
    @Override
    public void cellEvent(Player player, Player opponent,
                          Map map, BufferedReader input) throws IOException {
        if (status.equals("S")){
            buyShop(player, input);
        }
        else if (status.equals("O") || status.equals("M")){
            if (player.getName().equals("player") && status.equals("M") ||
                    player.getName().equals("bot") && status.equals("O")){
                upgradeShop(player, input);
            }
            else {
                if (player.getMoney() < K){
                    player.lose();
                    return;
                }
                payCompensation(player, opponent);
            }
        }
        else throw new IllegalArgumentException("Unexpected status value!");
    }

    /**
     * This method gets a string representation of the shop on the map
     * @return string representation of the shop
     */
    @Override
    public String toString() {
        return status;
    }
}
