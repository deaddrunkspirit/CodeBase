import java.util.Set;

/**
 * An interface used to validate annotations of an object
 */
public interface Validator {
    Set<ValidationError> validate(Object object);
}
