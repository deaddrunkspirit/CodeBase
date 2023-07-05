package martians;

import java.util.ArrayList;
import java.util.Collection;

/**
 * This class represents Innovator Martians, who can change their parents or children.
 * Innovators can even change their genetic code
 * @param <T> can be a Double, Integer or String
 */
public class InnovatorMartian<T> implements Martian<T> {
    private T geneticCode;
    private InnovatorMartian<T> parent;
    private Collection<InnovatorMartian<T>> children;

    /**
     * This constructor creates an innovator based on genetic code and his parent
     * @param geneticCode innovator's genetic code
     * @param parent innovator's parent (can be null if needed)
     */
    public InnovatorMartian(T geneticCode, InnovatorMartian<T> parent) {
        setGeneticCode(geneticCode);
        children = new ArrayList<>();
        this.parent = parent;
        if (parent != null) parent.addChild(this);
    }

    /**
     * This method sets new genetic code to innovator
     * @param geneticCode new genetic code
     */
    public void setGeneticCode(T geneticCode) {
        this.geneticCode = geneticCode;
    }

    /**
     * This method sets new parent to innovator and informs old parent about his loss.
     * New parent can't be null, can't be innovator's current
     * parent and innovator can't be a parent for himself.
     * @param parent new parent
     * @return whether new parent set or not
     */
    public boolean setParent(InnovatorMartian<T> parent) {
        if (parent == null || parent == getParent() || parent == this) return false;
        var save = this.parent;
        this.parent = parent;
        if (save != null) {
            save.removeChild(this);
        }
        return true;
    }

    /**
     * This method sets new children to innovator and informs old children about their loss.
     * New children can't be null or old children
     * @param children collection of new children
     * @return whether new children set or not
     */
    public boolean setChildren(Collection<InnovatorMartian<T>> children) {
        if (getChildren().equals(children) || children == null) return false;
        for (var child: this.children) {
            child.setParent(null);
        }
        for (var child: children) {
            child.setParent(this);
        }
        this.children = children;
        return true;
    }

    /**
     * This method adds new child to innovator and informs him about his new parent.
     * New child can't be null, existing child, or someone who is already in the tree
     * @param child new child
     * @return true if child added and no otherwise
     */
    public boolean addChild(InnovatorMartian<T> child) {
        InnovatorMartian<T> rootMartian = getRoot();
        if (child == null) return false;
        if (this == child) return false;
        if (this.getParent() == child) return false;
        for (var martian: rootMartian.getDescendants()) {
            if (martian == child) {
                return false;
            }
        }
        child.setParent(this);
        children.add(child);
        return true;
    }

    /**
     * This method gets the origin of the tree by recurrently getting parents
     * @return the root of the tree
     */
    public InnovatorMartian<T> getRoot() {
        if (getParent() != null){
            return ((InnovatorMartian<T>) getParent()).getRoot();
        }
        else {
            return this;
        }
    }

    /**
     * This method removes child if this child exists
     * @param child child to remove
     * @return true if child removed and false otherwise
     */
    public boolean removeChild(InnovatorMartian<T> child) {
        boolean hasChild = false;
        for (var check: children) {
            if (child == check) {
                hasChild = true;
                break;
            }
        }
        if (!hasChild) return false;
        child.setParent(null);
        children.remove(child);
        return true;
    }

    /**
     * Gets genetic code of innovator martian
     * @return current genetic code
     */
    @Override
    public T getGeneticCode() {
        return geneticCode;
    }

    /**
     * This method gets innovator's parent
     * @return innovator's parent
     */
    @Override
    public Martian<T> getParent() {
        return parent;
    }

    /**
     * This method gets all innovator children
     * @return innovator's children
     */
    @Override
    public Collection<Martian<T>> getChildren() {
        return new ArrayList<>(children);
    }

    /**
     * This method returns innovator martian's string representation
     * @return string representation of innovator martian
     */
    @Override
    public String toString() {
        return getClass().getSimpleName() +
                "(" +
                geneticCode.getClass().getSimpleName() +
                ":" +
                geneticCode +
                ")";
    }
}
