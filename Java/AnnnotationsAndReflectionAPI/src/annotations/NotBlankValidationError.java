/**
 * This class represents error that occurred during validation of an object with @NotBlank annotation
 */
public class NotBlankValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of NotBlankValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     */
    public NotBlankValidationError(String path, Object object) {
        super(path, object, null);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private NotBlankValidationError() {
        super("", "", null);
    }

    /**
     * This method returns a message in specific format for @NotBlank unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
        return "must not be blank";
    }
}
