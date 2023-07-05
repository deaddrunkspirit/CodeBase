package homework3;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

class PointTest {

    @Test
    void getX1() {
        Point point = new Point();
        assertEquals(point.getX(), 0);
    }

    @Test
    void getX2() {
        Point point = new Point(10, 5);
        assertEquals(point.getX(), 10);
    }

    @Test
    void getY1() {
        Point point = new Point();
        assertEquals(point.getY(), 0);
    }

    @Test
    void getY2() {
        Point point = new Point(10, 5);
        assertEquals(point.getY(), 5);
    }

    @Test
    void testToString1() {
        Point point = new Point();
        assertEquals(point.toString(), "(0; 0)");
    }

    @Test
    void testToString2() {
        Point point = new Point(-123, 123);
        assertEquals(point.toString(), "(-123; 123)");
    }

    @Test
    void testToString3() {
        Point point = new Point(123.123123, -123.123123);
        assertEquals(point.toString(), "(123,123; -123,123)");
    }
}