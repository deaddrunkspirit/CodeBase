package martians;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class ConservatorMartianTest {

    @Test
    void testToString1() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(123, null));
        assertEquals("ConservatorMartian(Integer:123)", martian.toString());
    }

    @Test
    void testToString2() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(14.88, null));
        assertEquals("ConservatorMartian(Double:14.88)", martian.toString());
    }

    @Test
    void testToString3() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>("Naruto", null));
        assertEquals("ConservatorMartian(String:Naruto)", martian.toString());
    }
}