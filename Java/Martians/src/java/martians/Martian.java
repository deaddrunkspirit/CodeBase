package martians;

import java.util.ArrayList;
import java.util.Collection;

/**
 * This interface describes a martian with a genetic code,
 * who have children and descendants.
 * @param <T> Can be a Double, Integer or a String
 */
interface Martian<T> {
    /**
     * This method gets martian parent
     * @return martian's parent
     */
    Martian<T> getParent();

    /**
     * This method gets martian parent
     * @return martian's genetic code
     */
    T getGeneticCode();

    /**
     * This method gets martian's children
     * @return martian's children
     */
    Collection<Martian<T>> getChildren();

    /**
     * This method gets all martian descendants
     * @return martian's descendants
     */
    default Collection<Martian<T>> getDescendants() {
        var children = this.getChildren();
        ArrayList<Martian<T>> descendants = new ArrayList<>();
        for (var martian: children) {
            if (!martian.getChildren().isEmpty()) {
                descendants.addAll(martian.getDescendants());
            }
        }
        children.addAll(descendants);
        return children;
    }

    /**
     * This method returns whether a martian have a child with specific genetic code
     * @param value genetic code to check
     * @return true if martian has such child and false otherwise
     */
    default boolean hasChildWithValue(T value) {
        for (var martian: getChildren()) {
            var check = martian.getGeneticCode();
            if (check.equals(value)) {
                return true;
            }
        }
        return false;
    }

    /**
     * This method returns whether a martian have a descendant with specific genetic code
     * @param value genetic code to check
     * @return true if martian has such descendant and false otherwise
     */
    default boolean hasDescendantWithValue(T value) {
        for (Martian<T> martian: getDescendants()) {
            if (martian.getGeneticCode().equals(value)) return true;
        }
        return false;
    }

    /**
     * A martian must have a string representation
     * @return martian's string representation
     */
    @Override
    String toString();

    /**
     * This method converts martian's genealogical tree starting from him
     * @param spaces inline spacing to see the depth of the tree
     * @param res stringBuilder to build a tree
     * @return string representation of genealogical tree
     */
    default String treeToString(String spaces, StringBuilder res) {
        res.append(spaces).append(toString()).append("\n");
        for (var child: getChildren()) {
            child.treeToString(spaces + " ".repeat(4), res);
        }
        return res.toString();
    }
}
