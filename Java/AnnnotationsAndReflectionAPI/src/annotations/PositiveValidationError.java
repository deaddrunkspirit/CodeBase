/**
 * This class represents error that occurred during validation of an object with @Positive annotation
 */
public class PositiveValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of PositiveValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     */
    public PositiveValidationError(String path, Object object) {
        super(path, object, null);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private PositiveValidationError() {
        super("", "", null);
    }

    /**
     * This method returns a message in specific format for @Positive unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
        return "must be positive";
    }
}
