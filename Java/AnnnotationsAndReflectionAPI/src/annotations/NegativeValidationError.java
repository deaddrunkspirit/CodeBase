/**
 * This class represents error that occurred during validation of an object with @Negative annotation
 */
public class NegativeValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of NegativeValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     */
    public NegativeValidationError(String path, Object object) {
        super(path, object, null);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private NegativeValidationError() {
        super("", "", null);
    }

    /**
     * This method returns a message in specific format for @Negative unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
        return "must be negative";
    }
}
