package martians;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Collection;

import static org.junit.jupiter.api.Assertions.*;

class InnovatorMartianTest {

    @Test
    void setGeneticCode1() {
        String newGeneticCode = "Marty";
        InnovatorMartian<String> martian = new InnovatorMartian<>("John", null);
        martian.setGeneticCode(newGeneticCode);
        assertEquals(newGeneticCode, martian.getGeneticCode());
    }

    @Test
    void setGeneticCode2() {
        Double newGeneticCode = 3.14;
        InnovatorMartian<Double> martian = new InnovatorMartian<Double>(228.322, null);
        martian.setGeneticCode(newGeneticCode);
        assertEquals(newGeneticCode, martian.getGeneticCode());
    }

    @Test
    void setGeneticCode3() {
        Integer newGeneticCode = 13;
        InnovatorMartian<Integer> martian = new InnovatorMartian<Integer>(228, null);
        martian.setGeneticCode(newGeneticCode);
        assertEquals(newGeneticCode, martian.getGeneticCode());
    }

    @Test
    void setParent1() {
        var martian = new InnovatorMartian<>(123, null);
        var parent = new InnovatorMartian<>(228, null);
        assertTrue(martian.setParent(parent));
        assertEquals(martian.getParent(), parent);
    }

    @Test
    void setParent2() {
        var parent = new InnovatorMartian<>(13, null);
        var martian = new InnovatorMartian<>(123, parent);
        assertFalse(martian.setParent(null));
        assertEquals(martian.getParent(), parent);
    }

    @Test
    void setParent3() {
        var parent = new InnovatorMartian<>(13, null);
        var martian = new InnovatorMartian<>(123, parent);
        assertFalse(martian.setParent(parent));
        assertEquals(martian.getParent(), parent);
    }

    @Test
    void setParent4() {
        var parent = new InnovatorMartian<>(13, null);
        var martian = new InnovatorMartian<>(123, parent);
        assertFalse(martian.setParent(martian));
        assertEquals(martian.getParent(), parent);
    }

    @Test
    void setChildren1() {
        var martian = new InnovatorMartian<>(12, null);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(new InnovatorMartian<>(123, null));
        children.add(new InnovatorMartian<>(4231, null));
        children.add(new InnovatorMartian<>(123, null));
        assertTrue(martian.setChildren(children));
        assertArrayEquals(martian.getChildren().toArray(), children.toArray());

    }

    @Test
    void setChildren2() {
        var martian = new InnovatorMartian<>(12, null);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(new InnovatorMartian<>(123, martian));
        children.add(new InnovatorMartian<>(4231, martian));
        children.add(new InnovatorMartian<>(123, martian));
        assertFalse(martian.setChildren(children));
        assertArrayEquals(martian.getChildren().toArray(), children.toArray());

    }

    @Test
    void setChildren3() {
        var martian = new InnovatorMartian<>(12, null);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(new InnovatorMartian<>(123, martian));
        children.add(new InnovatorMartian<>(4231, martian));
        children.add(new InnovatorMartian<>(123, martian));
        assertFalse(martian.setChildren(null));
        assertArrayEquals(martian.getChildren().toArray(), children.toArray());
    }

    @Test
    void addChild1() {
        var parent = new InnovatorMartian<>(14.88, null);
        var child = new InnovatorMartian<>(13.37, null);
        assertTrue(parent.addChild(child));
        assertTrue(parent.hasChildWithValue(13.37));
    }

    @Test
    void addChild2() {
        var parent = new InnovatorMartian<>("Dad", null);
        var child = new InnovatorMartian<>("Son", parent);
        assertFalse(child.addChild(parent));
        assertFalse(child.hasChildWithValue("Dad"));
        assertNotEquals(parent.getParent(), child);
    }

    @Test
    void addChild3() {
        var child = new InnovatorMartian<>("Son", null);
        assertFalse(child.addChild(child));
        assertFalse(child.hasChildWithValue("Son"));
        assertNotEquals(child.getParent(), child);
    }

    @Test
    void addChild4() {
        var parent = new InnovatorMartian<>("Dad", null);
        var child = new InnovatorMartian<>("Son", parent);
        assertFalse(parent.addChild(child));
        assertTrue(parent.hasChildWithValue("Son"));
        assertEquals(child.getParent(), parent);
    }

    @Test
    void addChild5() {
        var grandad = new InnovatorMartian<>("Granddad", null);
        var parent = new InnovatorMartian<>("Dad", grandad);
        var uncle = new InnovatorMartian<>("Uncle", grandad);
        var child = new InnovatorMartian<>("Son", parent);
        assertFalse(child.addChild(uncle));
        assertFalse(child.hasChildWithValue("Uncle"));
        assertNotEquals(uncle.getParent(), child);
    }

    @Test
    void removeChild1() {
        var martian = new InnovatorMartian<>(123, null);
        var child = new InnovatorMartian<>(222, martian);
        assertTrue(martian.removeChild(child));
        assertFalse(martian.hasChildWithValue(222));
    }

    @Test
    void removeChild2() {
        var martian = new InnovatorMartian<>("Dad", null);
        var child = new InnovatorMartian<>("Son", martian);
        var notChild = new InnovatorMartian<>("Daughter", child);
        assertFalse(martian.removeChild(notChild));
    }

    @Test
    void testToString1() {
        var martian = new InnovatorMartian<>(123, null);
        assertEquals("InnovatorMartian(Integer:123)", martian.toString());
    }

    @Test
    void testToString2() {
        var martian = new InnovatorMartian<>(14.88, null);
        assertEquals("InnovatorMartian(Double:14.88)", martian.toString());
    }

    @Test
    void testToString3() {
        var martian = new InnovatorMartian<>("Naruto", null);
        assertEquals("InnovatorMartian(String:Naruto)", martian.toString());
    }

    @Test
    void getRoot1() {
        var martian = new InnovatorMartian<>(12, null);
        assertEquals(martian, martian.getRoot());
    }

    @Test
    void getRoot2() {
        var martian = new InnovatorMartian<>(12, null);
        var child = new InnovatorMartian<>(23, martian);
        assertEquals(child.getRoot(), martian);
    }

    @Test
    void getRoot3() {
        var greatGrandad = new InnovatorMartian<>(12, null);
        var granddad = new InnovatorMartian<>(13, greatGrandad);
        var dad = new InnovatorMartian<>(21344, granddad);
        var child = new InnovatorMartian<>(1423, dad);
        assertEquals(child.getRoot(), greatGrandad);
    }
}