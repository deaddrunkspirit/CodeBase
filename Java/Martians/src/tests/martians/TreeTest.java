package martians;

import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.Scanner;

import static org.junit.jupiter.api.Assertions.*;

class TreeTest {

    File textDirectory = new File("src\\tests\\text_tests");

    private String readAllFileLines(String fileName) throws FileNotFoundException {
        FileReader reader = new FileReader(textDirectory + "\\" + fileName);
        Scanner scanner = new Scanner(reader);
        StringBuilder test = new StringBuilder();
        while (scanner.hasNextLine()) {
            test.append(scanner.nextLine()).append("\n");
        }
        return test.toString();
    }

    @Test
    void serializeConservatorTree1() {
        String text = "ConservatorMartian(String:Ivan)\n";
        var martian = new ConservatorMartian<>(new InnovatorMartian<>("Ivan", null));
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeConservatorTree2() {
        String text = "ConservatorMartian(String:Dad)\n    ConservatorMartian(String:Son)\n";
        var innovator = new InnovatorMartian<>("Dad", null);
        new InnovatorMartian<>("Son", innovator);
        var martian = new ConservatorMartian<>(innovator);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeConservatorTree3() {
        String text = "ConservatorMartian(Integer:1)" +
                "\n    ConservatorMartian(Integer:2)" +
                "\n        ConservatorMartian(Integer:31)" +
                "\n        ConservatorMartian(Integer:32)" +
                "\n        ConservatorMartian(Integer:33)\n";
        var innovator = new InnovatorMartian<>(1, null);
        var child = new InnovatorMartian<>(2, innovator);
        new InnovatorMartian<>(31, child);
        new InnovatorMartian<>(32, child);
        new InnovatorMartian<>(33, child);
        var martian = new ConservatorMartian<>(innovator);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeConservatorTree4() {
        String text = "ConservatorMartian(Integer:1)" +
                "\n    ConservatorMartian(Integer:2)" +
                "\n        ConservatorMartian(Integer:31)" +
                "\n            ConservatorMartian(Integer:1423)" +
                "\n            ConservatorMartian(Integer:75)" +
                "\n        ConservatorMartian(Integer:32)" +
                "\n            ConservatorMartian(Integer:123)" +
                "\n            ConservatorMartian(Integer:432)" +
                "\n        ConservatorMartian(Integer:33)" +
                "\n            ConservatorMartian(Integer:978)" +
                "\n            ConservatorMartian(Integer:713)\n";
        var innovator = new InnovatorMartian<>(1, null);
        var child = new InnovatorMartian<>(2, innovator);
        var grandson1 = new InnovatorMartian<>(31, child);
        var grandson2 = new InnovatorMartian<>(32, child);
        var grandson3 = new InnovatorMartian<>(33, child);
        new InnovatorMartian<>(1423, grandson1);
        new InnovatorMartian<>(75, grandson1);
        new InnovatorMartian<>(123, grandson2);
        new InnovatorMartian<>(432, grandson2);
        new InnovatorMartian<>(978, grandson3);
        new InnovatorMartian<>(713, grandson3);
        var martian = new ConservatorMartian<>(innovator);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeInnovatorTree1() {
        String text = "InnovatorMartian(Double:14.88)\n";
        var martian = new InnovatorMartian<>(14.88, null);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeInnovatorTree2() {
        String text = "InnovatorMartian(Double:2.28)\n    InnovatorMartian(Double:3.22)\n";
        var martian = new InnovatorMartian<>(2.28, null);
        new InnovatorMartian<>(3.22, martian);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeInnovatorTree3() {
        String text = "InnovatorMartian(Integer:1)" +
                "\n    InnovatorMartian(Integer:2)" +
                "\n        InnovatorMartian(Integer:31)" +
                "\n        InnovatorMartian(Integer:32)" +
                "\n        InnovatorMartian(Integer:33)\n";
        var martian = new InnovatorMartian<>(1, null);
        var child = new InnovatorMartian<>(2, martian);
        new InnovatorMartian<>(31, child);
        new InnovatorMartian<>(32, child);
        new InnovatorMartian<>(33, child);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void serializeInnovatorTree4() {
        String text = "InnovatorMartian(Integer:1)" +
                "\n    InnovatorMartian(Integer:2)" +
                "\n        InnovatorMartian(Integer:31)" +
                "\n            InnovatorMartian(Integer:1423)" +
                "\n            InnovatorMartian(Integer:75)" +
                "\n        InnovatorMartian(Integer:32)" +
                "\n            InnovatorMartian(Integer:123)" +
                "\n            InnovatorMartian(Integer:432)" +
                "\n        InnovatorMartian(Integer:33)" +
                "\n            InnovatorMartian(Integer:978)" +
                "\n            InnovatorMartian(Integer:713)\n";
        var martian = new InnovatorMartian<>(1, null);
        var child = new InnovatorMartian<>(2, martian);
        var grandson1 = new InnovatorMartian<>(31, child);
        var grandson2 = new InnovatorMartian<>(32, child);
        var grandson3 = new InnovatorMartian<>(33, child);
        new InnovatorMartian<>(1423, grandson1);
        new InnovatorMartian<>(75, grandson1);
        new InnovatorMartian<>(123, grandson2);
        new InnovatorMartian<>(432, grandson2);
        new InnovatorMartian<>(978, grandson3);
        new InnovatorMartian<>(713, grandson3);
        var tree = new Tree(martian);
        String str = tree.serializeTree();
        assertEquals(text, str);
    }

    @Test
    void deserializeInnovatorTreeCorrect1() {
        try {
            String text = readAllFileLines("innovator_tree_1.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeCorrect2() {
        try {
            String text = readAllFileLines("innovator_tree_2.txt");
            var tree = new Tree(text);
            assertEquals(tree.serializeTree(), text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeCorrect3() {
        try {
            String text = readAllFileLines("innovator_tree_3.txt");
            var tree = new Tree(text);
            assertEquals(tree.serializeTree(), text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeCorrect4() {
        try {
            String text = readAllFileLines("innovator_tree_4.txt");
            var tree = new Tree(text);
            assertEquals(tree.serializeTree(), text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeCorrect5() {
        try {
            String text = readAllFileLines("innovator_tree_5.txt");
            var tree = new Tree(text);
            assertEquals(tree.serializeTree(), text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeIncorrect1() {
        try {
            String text = readAllFileLines("innovator_tree_6.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeIncorrect2() {
        try {
            String text = readAllFileLines("innovator_tree_7.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeIncorrect3() {
        try {
            String text = readAllFileLines("innovator_tree_8.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeIncorrect4() {
        try {
            String text = readAllFileLines("innovator_tree_9.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeInnovatorTreeIncorrect5() {
        try {
            String text = readAllFileLines("innovator_tree_10.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeCorrect1() {
        try {
            String text = readAllFileLines("conservator_tree_1.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeCorrect2() {
        try {
            String text = readAllFileLines("conservator_tree_2.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeCorrect3() {
        try {
            String text = readAllFileLines("conservator_tree_3.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeCorrect4() {
        try {
            String text = readAllFileLines("conservator_tree_4.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeCorrect5() {
        try {
            String text = readAllFileLines("conservator_tree_5.txt");
            var tree = new Tree(text);
            String val1 = tree.serializeTree();
            assertEquals(val1, text);
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeIncorrect1() {
        try {
            String text = readAllFileLines("conservator_tree_6.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeIncorrect2() {
        try {
            String text = readAllFileLines("conservator_tree_7.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeIncorrect3() {
        try {
            String text = readAllFileLines("conservator_tree_8.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeIncorrect4() {
        try {
            String text = readAllFileLines("conservator_tree_9.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }

    @Test
    void deserializeConservatorTreeIncorrect5() {
        try {
            String text = readAllFileLines("conservator_tree_10.txt");
            assertThrows(IllegalArgumentException.class, () -> new Tree(text));
        }
        catch (Exception e) {
            System.out.println(e.getMessage());
            fail();
        }
    }
}