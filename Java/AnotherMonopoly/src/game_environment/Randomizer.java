/**
 * @author <a href="mailto:enmosolkov@edu.hse.ru"> Mosolov Evgeny</a>
 */

package game_environment;

import java.util.Random;

public class Randomizer {
    public static Random rnd = new Random();

    /**
     * This method generates an integer number in specified bounds
     * @param lowerBound lower bound of new number inclusive
     * @param upperBound upper bound of new number inclusive
     * @return generated integer number
     */
    public static int nextInt(int lowerBound, int upperBound){
        return rnd.nextInt(upperBound - lowerBound) + lowerBound;
    }

    /**
     * This method generates a double number in specified bounds
     * @param lowerBound lower bound of new number
     * @param upperBound upper bound of new number
     * @return generated double number
     */
    public static double nextDouble(double lowerBound, double upperBound){
        return lowerBound + (upperBound - lowerBound) * rnd.nextDouble();
    }
}
