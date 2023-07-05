import java.lang.annotation.Annotation;

/**
 * This class represents error that occurred during validation of an object with @InRange annotation
 */
public class InRangeValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of InRangeValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     * @param annotation unvalidated annotation
     */
    public InRangeValidationError(String path, Object object, Annotation annotation) {
        super(path, object, annotation);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private InRangeValidationError() {
        super("", "", null);
    }

    /**
     * This method returns a message in specific format for @InRange unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
            InRange annotation = (InRange) getAnnotation();
            return "number must be in range between " +
                    annotation.min() +
                    " and " +
                    annotation.max();
    }
}
