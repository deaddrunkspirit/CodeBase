import java.lang.annotation.Annotation;
import java.lang.reflect.AnnotatedParameterizedType;
import java.lang.reflect.AnnotatedType;
import java.lang.reflect.Field;
import java.util.*;

/**
 * This class helps to check and handle unvalidated annotations with method validate()
 * it returns a list of ValidationErrors occurred while checking an object
 *
 * An object you want to validate must be not null and marked @Constrained
 *
 * List of annotation this class handles:
 * \ @NotNull, @Positive, @Negative,
 * \ @Constrained, @Size, @InRange,
 * \ @NotBlank, @NotEmpty
 *
 * Note that  @Positive and @Negative annotations can't pe applied to the same object
 * Note that null is a valid value of object with every annotation except @NotNull
 */
public class ValidationHandler implements Validator {

    /**
     * This field is used to save path to a field in object
     */
    private String currentPath;

    /**
     * This field is used to save object instance
     */
    private Object currentObject;

    /**
     * This public constructor creates an instance of ValidationHandler
     */
    public ValidationHandler() {
        currentPath = "";
        currentObject = null;
    }

    /**
     * This method checks the entire object
     * and validates every field that marked with one of annotations:
     * \ @NotNull, @Positive, @Negative,
     * \ @Constrained, @Size, @InRange,
     * \ @NotBlank, @NotEmpty
     * @param object Object to check annotations
     *               (Must not be null and marked as @Constrained)
     * @return Set of ValidationError occurred
     * while checking all annotations of specific object
     */
    @Override
    public Set<ValidationError> validate(Object object) {
        if (object == null) {
            throw new NullPointerException("Validating object cannot be null!");
        }
        Set<ValidationError> errors = new HashSet<>();
        if (object.getClass().isAnnotationPresent(Constrained.class) ||
                List.class.isAssignableFrom(object.getClass())) {
            for (Field field : object.getClass().getDeclaredFields()) {
                field.setAccessible(true);
                currentPath = currentPath.isEmpty() ?
                        field.getName() :
                        currentPath + "." + field.getName();
                currentObject = object;
                validateField(field, errors);
            }
        }
        else {
            throw new IllegalArgumentException(
                    "Can't validate an object without @Constrained annotation!"
            );
        }
        return errors;
    }

    /**
     * This method validates specific field by checking all annotations
     * and checking if this field is an instance of a List,
     * in that case specific method is called recursively
     * @param field field to validate
     * @param errors Set of ValidationErrors to record unvalidated annotations
     */
    private void validateField(Field field, Set<ValidationError> errors) {
        AnnotatedType type = field.getAnnotatedType();
        Annotation[] annotations = type.getDeclaredAnnotations();
        try {
            field.setAccessible(true);
            Object object = field.get(currentObject);
            checkAnnotations(errors, annotations, object);
            if (type instanceof AnnotatedParameterizedType) {
                AnnotatedParameterizedType parametrizedType =
                        (AnnotatedParameterizedType) type;
                if (object instanceof List<?>) {
                    for (AnnotatedType typeArgument :
                            parametrizedType.getAnnotatedActualTypeArguments()) {
                        validateList(errors, (List<?>) object, annotations, typeArgument);
                    }
                }
            }
        } catch (IllegalAccessException ex) {
            ex.printStackTrace();
        }
        currentPath = currentPath.lastIndexOf("]") > 0 ?
                currentPath.substring(0, currentPath.lastIndexOf("]") + 1) : "";
    }


    /**
     * This method validates list, checking all annotations of list elements
     * and records them in Set of errors
     * @param errors Set of errors in validating object
     * @param list list to validate
     * @param annotations annotations of the list elements
     * @param elementType type of elements in list
     */
    public void validateList(Set<ValidationError> errors, List<?> list,
                             Annotation[] annotations, AnnotatedType elementType) {
        for (int i = 0; i < list.size(); i++) {
            String savePath = currentPath;
            Object element = list.get(i);
            currentObject = element;
            currentPath = String.format("%s[%d]", currentPath, i);
            if (element.getClass().isAnnotationPresent(Constrained.class)) {
                errors.addAll(validate(element));
            } else if (List.class.isAssignableFrom(element.getClass())) {
                checkAnnotations(errors, annotations, element);
                AnnotatedType type = ((AnnotatedParameterizedType) elementType)
                        .getAnnotatedActualTypeArguments()[0];
                Annotation[] nestedListAnnotations = type.getDeclaredAnnotations();
                validateList(errors, (List<?>) element, nestedListAnnotations, type);
            } else {
                checkAnnotations(errors, elementType.getAnnotations(), element);

            }
            currentPath = savePath;
        }
    }

    /**
     * This method checks annotations of specific object
     * and records errors that occur during validation
     * @param errors Set of errors to record
     * @param annotations annotations of the object to check
     * @param object object to check annotations from
     */
    private void checkAnnotations(Set<ValidationError> errors, Annotation[] annotations, Object object) {
        boolean hasPositiveAnnotation = false;
        boolean hasNegativeAnnotation = false;
        for (var annotation : annotations) {
            if (hasPositiveAnnotation && hasNegativeAnnotation) {
                throw new RuntimeException(
                        "@Positive and @Negative annotations can't be applied to the same object"
                );
            }
            Class<? extends Annotation> fieldClass = annotation.annotationType();
            if (fieldClass.isAssignableFrom(NotNull.class)) {
                hasNotNull(errors, object);
            } else if (fieldClass.isAssignableFrom(Positive.class)) {
                hasPositive(errors, object);
                hasPositiveAnnotation = true;
            } else if (fieldClass.isAssignableFrom(Negative.class)) {
                hasNegative(errors, object);
                hasNegativeAnnotation = true;
            } else if (fieldClass.isAssignableFrom(AnyOf.class)) {
                hasAnyOf(errors, object, (AnyOf) annotation);
            } else if (fieldClass.isAssignableFrom(Size.class)) {
                hasSize(errors, object, (Size) annotation);
            } else if (fieldClass.isAssignableFrom(InRange.class)) {
                hasInRange(errors, object, (InRange) annotation);
            } else if (fieldClass.isAssignableFrom(NotBlank.class)) {
                hasNotBlank(errors, object);
            } else if (fieldClass.isAssignableFrom(NotEmpty.class)) {
                hasNotEmpty(errors, object);
            }
        }
    }

    /**
     * This method is called when @NotNull annotation detected and records the specific error
     * @param errors Set of errors to record NotNullValidation error
     * @param object object that has a @NotNull annotation
     */
    private void hasNotNull(Set<ValidationError> errors, Object object) {
        if (object == null) {
            errors.add(new NotNullValidationError(currentPath, currentObject));
        }
    }

    /**
     * This method is called when @Positive annotation detected and records the specific error
     * @param errors Set of errors to record PositiveValidationError
     * @param object object that has a @Positive annotation
     */
    private void hasPositive(Set<ValidationError> errors, Object object) {
        if (object != null) {
            Class<?> clazz = object.getClass();
            boolean isNumber = Integer.class.isAssignableFrom(clazz) ||
                    Short.class.isAssignableFrom(clazz) ||
                    Byte.class.isAssignableFrom(clazz) ||
                    Long.class.isAssignableFrom(clazz);
            if (!isNumber) {
                throw new ClassCastException("Invalid type of object with @Positive annotation");
            } else if (((Number) object).longValue() <= 0) {
                errors.add(new NegativeValidationError(currentPath, currentObject));
            }
        }
    }

    /**
     * This method is called when @Negative annotation detected and records the specific error
     * @param errors Set of errors to record NegativeValidationError
     * @param object object that has a @Negative annotation
     */
    private void hasNegative(Set<ValidationError> errors, Object object) {
        if (object != null) {
            Class<?> clazz = object.getClass();
            boolean isNumber = Integer.class.isAssignableFrom(clazz) ||
                    Short.class.isAssignableFrom(clazz) ||
                    Byte.class.isAssignableFrom(clazz) ||
                    Long.class.isAssignableFrom(clazz);
            if (!isNumber) {
                throw new ClassCastException("Invalid type of object with @Negative annotation");
            } else if (((Number) object).longValue() >= 0) {
                errors.add(new NegativeValidationError(currentPath, currentObject));
            }
        }
    }

    /**
     * This method is called when @Size annotation detected and records the specific error
     * @param errors Set of errors to record SizeValidationError
     * @param object object that has a @Size annotation
     * @param annotation @Size annotation instance to get values from
     */
    private void hasSize(Set<ValidationError> errors, Object object, Size annotation) {
        if (object != null) {
            boolean isCollection = List.class.isAssignableFrom(object.getClass()) ||
                    Map.class.isAssignableFrom(object.getClass()) ||
                    Set.class.isAssignableFrom(object.getClass());
            boolean isString = String.class.isAssignableFrom(object.getClass());
            if (!isString && !isCollection) {
                throw new ClassCastException("Invalid type of object with @Size annotation");
            } else if (isCollection) {
                if (((Collection<?>) object).size() > annotation.max() ||
                        ((Collection<?>) object).size() < annotation.min()) {
                    errors.add(new SizeValidationError(currentPath, currentObject, annotation));
                }
            } else {
                if (((String) object).length() > annotation.max() ||
                        ((String) object).length() > annotation.min()) {
                    errors.add(new SizeValidationError(currentPath, currentObject, annotation));
                }
            }
        }
    }

    /**
     * This method is called when @InRange annotation detected and records the specific error
     * @param errors Set of errors to record InRangeValidationError
     * @param object object that has a @InRange annotation
     * @param annotation @InRange annotation instance to get values from
     */
    private void hasInRange(Set<ValidationError> errors, Object object, InRange annotation) {
        if (object != null) {
            Class<?> clazz = object.getClass();
            boolean isNumber = Integer.class.isAssignableFrom(clazz) ||
                    Short.class.isAssignableFrom(clazz) ||
                    Byte.class.isAssignableFrom(clazz) ||
                    Long.class.isAssignableFrom(clazz);
            if (!isNumber) {
                throw new ClassCastException("Invalid type of object with @Negative annotation");
            } else if (((Number) object).longValue() > annotation.max() ||
                    ((Number) object).longValue() < annotation.min()) {
                errors.add(new InRangeValidationError(currentPath, currentObject, annotation));
            }
        }
    }

    /**
     * This method is called when @NotBlank annotation detected and records the specific error
     * @param errors Set of errors to record NotBlankValidationError
     * @param object object that has a @NotBlank annotation
     */
    private void hasNotBlank(Set<ValidationError> errors, Object object) {
        if (object != null) {
            boolean isString = String.class.isAssignableFrom(object.getClass());
            if (!isString) {
                throw new ClassCastException("Invalid type of object with @NotBlank annotation");
            } else if (((String) object).isBlank()) {
                errors.add(new NotBlankValidationError(currentPath, currentObject));
            }
        }
    }

    /**
     * This method is called when @NotEmpty annotation detected and records the specific error
     * @param errors Set of errors to record NotEmptyValidationError
     * @param object object that has a @NotEmpty annotation
     */
    private void hasNotEmpty(Set<ValidationError> errors, Object object) {
        if (object != null) {
            boolean isCollection = List.class.isAssignableFrom(object.getClass()) ||
                    Map.class.isAssignableFrom(object.getClass()) ||
                    Set.class.isAssignableFrom(object.getClass());
            boolean isString = String.class.isAssignableFrom(object.getClass());
            if (!isCollection && !isString) {
                throw new ClassCastException("Invalid type of object with @NotEmpty annotation");
            } else if (isString && ((String) object).isEmpty() ||
                    isCollection && ((Collection<?>) object).isEmpty()) {
                errors.add(new NotEmptyValidationError(currentPath, currentObject));
            }
        }
    }


    /**
     * This method is called when @AnyOf annotation detected and records the specific error
     * @param errors Set of errors to record AnyOfValidationError
     * @param object object that has a @AnyOf annotation
     * @param annotation @AnyOf annotation instance to get values from
     */
    private void hasAnyOf(Set<ValidationError> errors, Object object, AnyOf annotation) {
        if (object != null) {
            boolean isString = String.class.isAssignableFrom(object.getClass());
            if (!isString) {
                throw new ClassCastException("Invalid type of object with @AnyOf annotation");
            }
            String str = (String) object;
            List<String> variants = Arrays.asList(annotation.value());
            if (!variants.contains(str)) {
                errors.add(new AnyOfValidationError(currentPath, currentObject, annotation));
            }
        }
    }
}
