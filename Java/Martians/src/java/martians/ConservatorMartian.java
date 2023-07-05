package martians;

import java.util.ArrayList;
import java.util.Collection;

/**
 * This class represents a Martian who decided not to change anything in his life
 * All conservator's fields are final so no one can change them
 * @param <T> can be Integer, Double or String
 */
public class ConservatorMartian<T> implements Martian<T> {
    private final T geneticCode;
    private final ConservatorMartian<T> parent;
    private final Collection<ConservatorMartian<T>> children;

    /**
     * This constructor creates a conservator martian based on innovator martian
     * Innovator's children become conservator's and Innovator becomes the root of a new tree
     * @param martian an innovator martian who decided to become conservator
     */
    public ConservatorMartian(InnovatorMartian<T> martian) {
        geneticCode = martian.getGeneticCode();
        this.parent = null;
        children = setChildren(martian);
    }

    /**
     * This private constructor made to fill conservator's tree
     * @param martian innovator from whom we creates conservator
     * @param parent parent for current conservator
     */
    private ConservatorMartian(InnovatorMartian<T> martian, ConservatorMartian<T> parent) {
        geneticCode = martian.getGeneticCode();
        this.parent = parent;
        children = setChildren(martian);
    }

    /**
     * This method sets children for conservator martian
     * @param martian innovator whose children become conservators
     * @return collection of conservator's children
     */
    private Collection<ConservatorMartian<T>> setChildren(InnovatorMartian<T> martian) {
        ArrayList<ConservatorMartian<T>> newChildren = new ArrayList<>();
        for (var child: martian.getChildren()) {
            newChildren.add(new ConservatorMartian<T>((InnovatorMartian<T>) child, this));
        }
        return newChildren;
    }

    /**
     * This method returns conservator's parent or null (if conservator is the root of his tree)
     * @return conservator's parent
     */
    @Override
    public Martian<T> getParent() {
        return parent;
    }

    /**
     * This method returns conservator's genetic code
     * @return genetic code of conservator martian
     */
    @Override
    public T getGeneticCode() {
        return geneticCode;
    }

    /**
     * This method gets children or an empty children collection if there are no children
     * @return collection of martians
     */
    @Override
    public Collection<Martian<T>> getChildren() {
        return new ArrayList<>(children);
    }

    /**
     * This method converts ConservatorMartian to string
     * @return string representation of martian
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
