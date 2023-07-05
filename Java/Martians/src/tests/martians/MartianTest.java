package martians;

import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.Collection;

import static org.junit.jupiter.api.Assertions.*;

class MartianTest {

    @Test
    void getParent1() {
        var martian = new InnovatorMartian<>(3.22, null);
        assertNull(martian.getParent());
    }

    @Test
    void getParent2() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>("Sasuke", null));
        assertNull(martian.getParent());
    }

    @Test
    void getParent3() {
        var parent = new InnovatorMartian<>(14.88, null);
        var martian = new InnovatorMartian<>(3.22, parent);
        assertEquals(martian.getParent(), parent);
    }

    @Test
    void getParent4() {
        var parent = new InnovatorMartian<>(322, null);
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(228, parent));
        assertNull(martian.getParent());
    }

    @Test
    void getGeneticCode1() {
        var geneticCode = "Naruto";
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(geneticCode, null));
        assertEquals(geneticCode, martian.getGeneticCode());
    }

    @Test
    void getGeneticCode2() {
        var geneticCode = 1;
        var martian = new InnovatorMartian<>(geneticCode, null);
        assertEquals(geneticCode, martian.getGeneticCode());
    }

    @Test
    void getGeneticCode3() {
        var geneticCode = "John";
        var martian = new InnovatorMartian<>(geneticCode, null);
        assertEquals(geneticCode, martian.getGeneticCode());
    }

    @Test
    void getGeneticCode4() {
        var geneticCode = 2.28;
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(geneticCode, null));
        assertEquals(geneticCode, martian.getGeneticCode());
    }

    @Test
    void getChildren1() {
        var martian = new InnovatorMartian<>("Indra", null);
        assert martian.getChildren().isEmpty();
    }

    @Test
    void getChildren2() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(2.23, null));
        assert martian.getChildren().isEmpty();
    }

    @Test
    void getChildren3() {
        var martian = new InnovatorMartian<>(123, null);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(new InnovatorMartian<>(227, martian));
        children.add(new InnovatorMartian<>(214, martian));
        children.add(new InnovatorMartian<>(23254, martian));
        assertArrayEquals(children.toArray(), martian.getChildren().toArray());
    }

    @Test
    void getDescendants1() {
        var martian = new ConservatorMartian<>(new InnovatorMartian<>(12, null));
        assertNotNull(martian.getDescendants());
        Collection<ConservatorMartian<Integer>> emptyCollection = new ArrayList<>();
        assertArrayEquals(martian.getDescendants().toArray(), emptyCollection.toArray());
    }

    @Test
    void getDescendants2() {
        var martian = new InnovatorMartian<>(1, null);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(new InnovatorMartian<>(21, martian));
        children.add(new InnovatorMartian<>(22, martian));
        children.add(new InnovatorMartian<>(23, martian));
        assertArrayEquals(children.toArray(), martian.getDescendants().toArray());
    }

    @Test
    void getDescendants3() {
        var martian = new InnovatorMartian<>(1, null);
        var child1 = new InnovatorMartian<>(21, martian);
        var child2 = new InnovatorMartian<>(22, martian);
        var child3 = new InnovatorMartian<>(23, martian);
        Collection<InnovatorMartian<Integer>> children = new ArrayList<>();
        children.add(child1);
        children.add(child2);
        children.add(child3);
        children.add(new InnovatorMartian<>(31, child1));
        children.add(new InnovatorMartian<>(32, child2));
        children.add(new InnovatorMartian<>(33, child3));
        children.add(new InnovatorMartian<>(34, child1));
        children.add(new InnovatorMartian<>(35, child2));
        children.add(new InnovatorMartian<>(36, child3));
        martian.getDescendants().forEach((x) -> assertTrue(children.contains(x)));
    }

    @Test
    void hasChildWithValue1() {
        var martian = new InnovatorMartian<>(123, null);
        new InnovatorMartian<>(227, martian);
        assertTrue(martian.hasChildWithValue(227));
    }

    @Test
    void hasChildWithValue2() {
        var martian = new InnovatorMartian<>(123, null);
        new InnovatorMartian<>(223, martian);
        assertFalse(martian.hasChildWithValue(333));
    }

    @Test
    void hasChildWithValue3() {
        var martian = new InnovatorMartian<>(12.23, null);
        new InnovatorMartian<>(13.370, martian);
        assertTrue(martian.hasChildWithValue(13.37));
    }

    @Test
    void hasChildWithValue4() {
        var martian = new InnovatorMartian<>(14.88, null);
        new InnovatorMartian<>(13.37, martian);
        var conservator = new ConservatorMartian<>(martian);
        assertFalse(conservator.hasChildWithValue(22.3));
    }

    @Test
    void hasChildWithValue5() {
        var martian = new InnovatorMartian<>("Dad", null);
        new InnovatorMartian<>("Son", martian);
        var conservator = new ConservatorMartian<>(martian);
        assertTrue(conservator.hasChildWithValue("Son"));
    }

    @Test
    void hasChildWithValue6() {
        var martian = new InnovatorMartian<>("Dad", null);
        new InnovatorMartian<>("Son", martian);
        var conservator = new ConservatorMartian<>(martian);
        assertFalse(conservator.hasChildWithValue("Daughter"));
    }

    @Test
    void hasDescendantWithValue1() {
        var martian = new InnovatorMartian<>(13, null);
        var child = new InnovatorMartian<>(10, martian);
        new InnovatorMartian<>(228, child);
        assertTrue(martian.hasDescendantWithValue(228));
    }

    @Test
    void hasDescendantWithValue2() {
        var martian = new InnovatorMartian<>(13, null);
        var child = new InnovatorMartian<>(10, martian);
        new InnovatorMartian<>(228, child);
        assertFalse(martian.hasDescendantWithValue(322));
    }

    @Test
    void hasDescendantWithValue3() {
        var martian = new InnovatorMartian<>(9.11, null);
        var child = new InnovatorMartian<>(13.32, martian);
        new InnovatorMartian<>(1.1, child);
        assertTrue(martian.hasDescendantWithValue(1.1));
    }

    @Test
    void hasDescendantWithValue4() {
        var martian = new InnovatorMartian<>(.8, null);
        var child = new InnovatorMartian<>(.7, martian);
        new InnovatorMartian<>(13.37, child);
        var conservator = new ConservatorMartian<>(martian);
        assertFalse(conservator.hasDescendantWithValue(14.88));
    }

    @Test
    void hasDescendantWithValue5() {
        var martian = new InnovatorMartian<>("Jiraya", null);
        var child = new InnovatorMartian<>("Minato", martian);
        new InnovatorMartian<>("Naruto", child);
        var conservator = new ConservatorMartian<>(martian);
        assertTrue(conservator.hasDescendantWithValue("Naruto"));
    }

    @Test
    void hasDescendantWithValue6() {
        var martian = new InnovatorMartian<>("Jiraya", null);
        var child = new InnovatorMartian<>("Minato", martian);
        new InnovatorMartian<>("Naruto", child);
        var conservator = new ConservatorMartian<>(martian);
        assertFalse(conservator.hasDescendantWithValue("Sasuke"));
    }
}