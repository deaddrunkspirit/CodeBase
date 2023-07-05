/**
 * Interface representing all validation errors
 */
public interface ValidationError {

    /**
     * Getter for ValidationError message to user
     * @return message
     */
    String getMessage();

    /**
     * Getter for path to failed value
     * @return path to value
     */
    String getPath();

    /**
     * Getter for failed value
     * @return failed value
     */
    Object getFailedValue();
}
