package homework3;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class CartTest {

    @Test
    void getX1() {
        Cart cart = new Cart();
        assertEquals(0, cart.getX());
    }

    @Test
    void getX2() {
        Cart cart = new Cart(100.100, 100);
        assertEquals(100.100, cart.getX());
    }

    @Test
    void getY1() {
        Cart cart = new Cart();
        assertEquals(0, cart.getX());
    }

    @Test
    void getY2() {
        Cart cart = new Cart(100, 100.100);
        assertEquals(100.100, cart.getY());
    }

    @Test
    void move() {
        Cart cart = new Cart();
        assertEquals(cart.getX(), 0);
        assertEquals(cart.getY(), 0);
        cart.move(12.22, 12.22);
        assertEquals(cart.getX(), 12.22);
        assertEquals(cart.getY(), 12.22);
    }
}