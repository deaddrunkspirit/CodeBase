package martians;

import java.util.ArrayList;

/**
 * Class of genealogical tree, that stores root martian of the tree
 * and can serialize and deserialize martian genealogical tree from string and to string
 */
public class Tree  {
    public Martian<?> root;

    /**
     * This constructor creates a tree based on string representation
     * @param text text with string representation of martians
     */
    public Tree(String text) {
        deserializeTree(text);
    }

    /**
     * This constructor creates a tree based on martian
     * @param parent root of the tree
     */
    public Tree(Martian<?> parent) {
        this.root = parent;
    }

    /**
     * This method serializes tree to string format
     * @return string representation of a tree
     */
    public String serializeTree() {
        return root.treeToString("", new StringBuilder());
    }

    /**
     * This method converts string to tree
     * We create an innovator tree and if the tree
     * is conservator's creates a new tree based on root
     * @param text string to get tree from
     */
    public void deserializeTree(String text) {
        checkTextForValidity(text);
        String[] strings = text.split("\n");
        String martianType = strings[0].substring(0, strings[0].indexOf('('));
        InnovatorMartian<?> root = getMartian(strings[0], null);
        getInnovatorTree(strings, root);
        if (martianType.equals("ConservatorMartian")) {
            this.root = new ConservatorMartian<>((InnovatorMartian<?>) root);
        }
        else if (martianType.equals("InnovatorMartian")) {
            this.root = root;
        }
    }

    /**
     * This method gets an innovator tree based on list of strings and root of the tree
     * @param strings list of strings to parse
     * @param root root of the tree
     */
    private void getInnovatorTree(String[] strings, InnovatorMartian<?> root) {
        ArrayList<InnovatorMartian<?>> parents = new ArrayList<>();
        parents.add(root);
        InnovatorMartian<?> currParent;
        int tabsCountCurr;
        for (int i = 1; i < strings.length; i++) {
            String str = strings[i];
            tabsCountCurr = countTabs(str);
            currParent = parents.get(tabsCountCurr - 1);
            parentDepthUpdate(parents, getMartian(str, currParent), tabsCountCurr);
        }
    }

    /**
     * This method updates the list of stored tree depth
     * @param list list where we store current depth parents
     * @param parent parent to store in list
     * @param countTabs count of four spaces befor martian representation in string
     */
    private void parentDepthUpdate(ArrayList<InnovatorMartian<?>> list,
                                   InnovatorMartian<?> parent, int countTabs) {
        if (list.size() <= countTabs) {
            list.add(parent);
        }
        else {
            list.set(countTabs, parent);
        }
    }

    /**
     * This method gets an innovator martian from string
     * @param string string to parse
     * @param parent parent of this child
     * @return parsed innovator
     */
    private InnovatorMartian<?> getMartian(String string,
                                            InnovatorMartian<?> parent) {
        String geneticType = string.substring(string.indexOf('(') + 1, string.indexOf(':'));
        String geneticCode = string.substring(string.indexOf(':') + 1, string.indexOf(')'));
        switch (geneticType) {
            case "String":
                return new InnovatorMartian<>(geneticCode, (InnovatorMartian<String>) parent);
            case "Integer":
                return new InnovatorMartian<>(Integer.parseInt(geneticCode), (InnovatorMartian<Integer>) parent);
            case "Double":
                return new InnovatorMartian<>(Double.parseDouble(geneticCode), (InnovatorMartian<Double>) parent);
            default:
                throw new IllegalArgumentException("Invalid genetic type");
        }
    }

    /**
     * This method checks if string have normal format for deserialization
     * @param text string to check
     */
    private void checkTextForValidity(String text) {
        String rootLine = text.substring(0, text.indexOf("\n"));
        String type = rootLine.substring(rootLine.indexOf("(") + 1, rootLine.indexOf(":"));
        if (!type.equals("Double") && !type.equals("String") && !type.equals("Integer")) {
            throw new IllegalArgumentException("Incorrect type");
        }
        if (!rootLine.startsWith("C") && !rootLine.startsWith("I")) {
            throw new IllegalArgumentException("No parent");
        }
        else {
            if (text.startsWith("ConservatorMartian")) {
                checkMartiansFormat(text.replaceFirst(rootLine, ""),
                        "ConservatorMartian", type);
            }
            else if (text.startsWith("InnovatorMartian")) {
                checkMartiansFormat(text.replaceFirst(rootLine + "\n", ""),
                        "InnovatorMartian", type);
            }
        }
    }

    /**
     * This method checks martian for correct format in each line of string
     * @param text string to check martian's format
     * @param martianType first character of martian
     * @param geneticType type of martian genetic code
     */
    private void checkMartiansFormat(String text, String martianType, String geneticType) {
        var lines = text.split("\n");
        for (int i = 1; i < lines.length; i++) {
            if (!lines[i].trim().startsWith(martianType)) {
                throw new IllegalArgumentException("Invalid tree structure");
            }
            if (!lines[i].contains(geneticType)) {
                throw new IllegalArgumentException("Invalid type");
            }
            if (!lines[i].startsWith(" ")) {
                throw new IllegalArgumentException("Second parent");
            }
        }
    }

    /**
     * This method counts tabs in string before martian's string representation
     * @param line line to count tabs
     * @return returns the number of four spaces in line (before martian representation)
     */
    private int countTabs(String line) {
        int count = 0;
        for (int i = 0; i < line.length(); i++) {
            if (line.charAt(i) == 'C' || line.charAt(i) == 'I') {
                return count / 4;
            }
            else count++;
        }
        return count / 4;
    }
}
