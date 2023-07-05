import java.lang.annotation.Annotation;
import java.lang.reflect.Field;

/**
 * This abstract class represents all validation errors with basic methods
 * getFailedValue() and getPath()
 */
public abstract class ValidationErrorObject implements ValidationError {

    /**
     * This field has information about failed value's path
     */
    private final String path;

    /**
     * This field has an instance of failed object
     */
    private final Object object;

    /**
     * This field has an unvalidated annotation,
     * that is used to get annotation values
     * in inherited validation error classes
     */
    private final Annotation annotation;

    /**
     * This constructor is used to fill information about object,
     * it's path, and unvalidated annotation
     * @param path path to failed value
     * @param object instance of failed value
     * @param annotation unvalidated annotation
     */
    protected ValidationErrorObject(String path, Object object, Annotation annotation) {
        this.object = object;
        this.path = path;
        this.annotation = annotation;
    }

    /**
     * Getter for path field
     * @return path to failed value
     */
    @Override
    public String getPath() {
        return path;
    }

    /**
     * Getter for failed value
     * @return value that failed during validation
     */
    @Override
    public Object getFailedValue() {
        try {
            Class<?> objectClass = object.getClass();
            String name = getFieldName();
            if (name.lastIndexOf("]") == name.length() - 1) {
                return object;
            }
            else {
                Field field = objectClass.getDeclaredField(name);
                field.setAccessible(true);
                return field.get(object);
            }
        } catch (NoSuchFieldException | IllegalAccessException e) {
            e.printStackTrace();
        }
        return null;
    }

    /**
     * Getter for unvalidated annotation
     * @return annotation that failed validation
     */
    protected Annotation getAnnotation() {
        return annotation;
    }

    /**
     * This method gets the name of the field by cutting its path
     * @return field name where validation fails
     */
    protected String getFieldName() {
        return getPath().lastIndexOf(".") > 0 ?
                getPath().substring(getPath().lastIndexOf(".") + 1) :
                getPath();
    }
}
