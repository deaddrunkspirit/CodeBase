package homework3;

import java.util.Random;

public class Animal extends Thread {
    private String name;
    private double angle;
    private double coefficient;
    private Cart cart;
    private final Random rnd = new Random();

    /**
     * This private constructor forbids to create an instance of
     * an animal without name, angle or coefficient
     */
    private Animal() { }

    /**
     * This constructor creates an animal with a name, cart and angle
     * @param name name of the animal
     * @param angle direction of pull
     * @param cart animal connected to this cart
     */
    public Animal(String name, double angle, Cart cart) {
        this.name = name;
        this.angle = angle;
        this.cart = cart;
        coefficient = (rnd.nextInt(9) + 1) + rnd.nextDouble();
    }

    /**
     * This method pulls the cart animal connected to
     */
    private synchronized void pull() {
        System.out.println(name + " is pulling cart");
        double x = cart.getX() + coefficient * Math.cos(Math.toRadians(angle));
        double y = cart.getY() + coefficient * Math.sin(Math.toRadians(angle));
        cart.move(x, y);
    }

    /**
     * Method that is running pull method in parallel with other threads
     */
    @Override
    public void run() {
        try {
            long start = System.currentTimeMillis();
            while (!isInterrupted()) {
                pull();
                long sleepTime = (int) (((rnd.nextInt(4) + 1) + rnd.nextDouble()) * 1000);
                System.out.println(name + " sleeps for " + (sleepTime) + " ms");
                sleep(sleepTime);
                if (System.currentTimeMillis() - start >= 25000) {
                    System.out.println(name + " has lost its powers");
                    return;
                }
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
