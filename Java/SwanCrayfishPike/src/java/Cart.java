package homework3;

public class Cart extends Thread {
    private Point position;

    /**
     * This constructor creates a cart instance on default position
     */
    public Cart() {
        position = new Point();
    }

    /**
     * This method creates a cart instance on specific position
     * @param x position of cart on axis X
     * @param y position of cart on axis Y
     */
    public Cart(double x, double y) {
        position = new Point(x, y);
    }

    /**
     * Getter for x coordinate of cat's position
     * @return position of the cart on axis X
     */
    public double getX() {
        return position.getX();
    }

    /**
     * Getter for y coordinate of cat's position
     * @return position of the cart on axis Y
     */
    public double getY() {
        return position.getY();
    }

    /**
     * This method changes cart's position
     * @param x new coordinate x
     * @param y new coordinate y
     */
    public void move(double x, double y) {
        position = new Point(x, y);
    }

    /**
     * This method is running in parallel with animals
     * and prints information about cart's current position every 2 seconds
     */
    @Override
    public void run() {
        try {
            long start = System.currentTimeMillis();
            while (!isInterrupted()) {
                System.out.println("Cart is now at " + position.toString());
                sleep(2000);
                if (System.currentTimeMillis() - start >= 29000) {
                    return;
                }
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
