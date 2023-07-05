import java.lang.annotation.Annotation;

/**
 * This class represents error that occurred during validation of an object with @Size annotation
 */
public class SizeValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of SizeValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     * @param annotation unvalidated annotation
     */
    public SizeValidationError(String path, Object object, Annotation annotation) {
        super(path, object, annotation);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private  SizeValidationError() {
        super("", "", null);
    }

    /**
     * This method returns a message in specific format for @Size unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
        Size annotation = (Size) getAnnotation();
        return "size must be in range between " +
                annotation.min() +
                " to " +
                annotation.max();
    }
}
