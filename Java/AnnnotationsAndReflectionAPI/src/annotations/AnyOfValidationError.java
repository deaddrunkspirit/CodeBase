import java.lang.annotation.Annotation;

/**
 * This class represents error that occurred during validation of an object with @AnyOf annotation
 */
public class AnyOfValidationError extends ValidationErrorObject {

    /**
     * This constructor creates an instance of AnyOfValidationError
     * Note that you should use only this constructor, other constructors aren't recommended to use
     * @param path path to failed value
     * @param object failed object instance
     * @param annotation unvalidated annotation
     */
    public AnyOfValidationError(String path, Object object, Annotation annotation) {
        super(path, object, annotation);
    }

    /**
     * This private empty constructor used to block the ability to create empty ValidationError objects
     */
    private AnyOfValidationError() {
        this("", "", null);
    }

    /**
     * This method returns a message in specific format for @AnyOf unvalidated annotation
     * @return message to user about failed object
     */
    @Override
    public String getMessage() {
            StringBuilder mes = new StringBuilder("must be one of ");;
            String[] values = ((AnyOf) getAnnotation()).value();
            for (int i = 0; i < values.length - 1; i++) {
                mes.append("'").append(values[i]).append("', ");
            }
            mes.append("'").append(values[values.length - 1]).append("'");
            return mes.toString();

    }
}
