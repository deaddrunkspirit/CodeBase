package homework3;

import java.text.DecimalFormat;

public class Point {
    private final double x;
    private final double y;

    /**
     * This default constructor creates a point at the origin
     */
    public Point() {
        x = 0;
        y = 0;
    }

    /**
     * This constructor creates a point based on specific coordinates
     * @param x point position on axis X
     * @param y point position on axis Y
     */
    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    /**
     * Getter for coordinate x
     * @return point position on axis X
     */
    public double getX() {
        return x;
    }

    /**
     * Getter for coordinate y
     * @return point position on axis Y
     */
    public double getY() {
        return y;
    }

    /**
     * String representation of a decimal point with specific format
     * @return string representation of point. Example: (12.228; -12.33)
     */
    @Override
    public String toString() {
        DecimalFormat formatter = new DecimalFormat("#.###");
        return "(" + formatter.format(x) + "; " + formatter.format(y) + ")";
    }
}
