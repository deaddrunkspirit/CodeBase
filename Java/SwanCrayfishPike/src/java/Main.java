package homework3;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    public static void main(String[] args) {
        try {
            Cart cart = getCart(args);
            Animal swan = new Animal("Swan", 60, cart);
            Animal crayfish = new Animal("Crayfish", 180, cart);
            Animal pike = new Animal("Pike", 300, cart);
            cart.start();
            swan.start();
            crayfish.start();
            pike.start();
        }
        catch (IllegalArgumentException e) {
            System.out.println(e.getMessage());
        }
    }

    /**
     * This method gets an instance of a cart
     * with different amount of arguments from command prompt
     * @param args command prompt arguments
     * @return an instance of a cart
     */
    private static Cart getCart(String[] args) {
        switch (args.length) {
            case 0:
                return new Cart();
            case 1:
                return oneArgument(args);
            case 2:
                return new Cart(Double.parseDouble(args[0]), Double.parseDouble(args[1]));
            default:
                throw new IllegalArgumentException("Invalid number of arguments");
        }
    }

    /**
     * This method handles situation when only one argument given,
     * and checks format for validity. An argument can be either a single number
     * (if so it will be x coordinate of cart's start position)
     * or it can be a statement like: <x=12> or <Y=44>
     * @param args command prompt arguments
     * @return an instance of a cart
     */
    private static Cart oneArgument(String[] args) {
        try {
            return new Cart(Double.parseDouble(args[0]), 0);
        }
        catch (NumberFormatException e) {
            Pattern pattern = Pattern.compile("[xyXY]=\\d");
            Matcher matcher = pattern.matcher(args[0]);
            if (matcher.find()) {
                String[] arg = args[0].split("=");
                if (arg[0].equals("x") || arg[0].equals("X")) {
                    return new Cart(Double.parseDouble(arg[1]), 0);
                }
                return new Cart(0, Double.parseDouble(arg[1]));
            }
            else throw new IllegalArgumentException("Invalid argument");
        }
    }
}
