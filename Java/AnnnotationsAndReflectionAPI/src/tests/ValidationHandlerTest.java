import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.util.*;

import static org.junit.jupiter.api.Assertions.*;

class ValidationHandlerTest {

    /**
     * Test case where library used by its intended purpose
     * with different types of annotations and without exceptions
     */
    @DisplayName("BookingForm test")
    @Test
    void validateBookingForm1() {
        Validator validator = new ValidationHandler();
        List<GuestForm> guests = List.of(
                new GuestForm(null, "Def", 21),
                new GuestForm("", "Ijk", -3)
        );
        Unrelated unrelated = new Unrelated(-1);
        BookingForm bookingForm = new BookingForm(
                guests,
                List.of("TV", "Piano"),
                "Apartment",
                unrelated
        );
        Set<ValidationError> validationErrors = validator.validate(bookingForm);
        ArrayList<String> paths = new ArrayList<>();
        ArrayList<Object> values = new ArrayList<>();
        ArrayList<String> messages = new ArrayList<>();
        validationErrors.forEach(error -> {
            paths.add(error.getPath());
            values.add(error.getFailedValue());
            messages.add(error.getMessage());
        });

        assertTrue(paths.contains("guests[0].firstName") &&
                messages.contains("must not be null")
        );
        assertTrue(paths.contains("guests[1].age") &&
                messages.contains("number must be in range between 0 and 200")
        );
        assertTrue(paths.contains("guests[1].firstName") &&
                messages.contains("must not be blank")
        );
        assertTrue(paths.contains("amenities[1]") &&
                messages.contains("must be one of 'TV', 'Kitchen'")
        );
        assertTrue(paths.contains("propertyType") &&
                messages.contains("must be one of 'House', 'Hostel'")
        );
        // guests[0].firstName  | must not be null                      | null
        // guests[1].age        | must be in range between 0 and 200    | -3
        // guests[1].firstName  | must not be blank                     | ""
        // amenities[1]         | must be one of 'TV', 'Kitchen'        | Piano
        // propertyType         | must be one of 'House', 'Hostel'      | Apartment
    }

    /**
     * Test case where validation proceeds without @Constrained annotation
     */
    @Test
    void classWithoutConstrainedTest() {
        Validator validator = new ValidationHandler();
        Unrelated unrelated = new Unrelated(-10);
        assertThrows(IllegalArgumentException.class,
                () -> validator.validate(unrelated)
        );
    }

    /**
     * Test case where validation proceeds with null object
     */
    @Test
    void nullValidationTest() {
        Validator validator = new ValidationHandler();
        Object object = null;
        assertThrows(NullPointerException.class,
                () -> validator.validate(object)
        );
    }

    @DisplayName("Class cast @Positive")
    @Test
    void positiveClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastPositive = "qwerty";
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @Negative")
    @Test
    void negativeClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastNegative = "qwerty";
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @AnyOf")
    @Test
    void anyOfClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastAnyOf = 12;
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @Size")
    @Test
    void sizeClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastSize = 6.4;
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @InRange")
    @Test
    void inRangeClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastInRange = 3.22;
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @NotBlank")
    @Test
    void notBlankClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastNotBlank = 228;
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    @DisplayName("Class cast @NotEmpty")
    @Test
    void notEmptyClassCastExceptionTest() {
        Validator validator = new ValidationHandler();
        TestForm2 tf = new TestForm2();
        tf.classCastNotEmpty = 1000 - 7;
        assertThrows(ClassCastException.class, () -> validator.validate(tf));
    }

    /**
     * Test case that checks all kinds of annotations applied to fields
     */
    @DisplayName("All annotations on fields")
    @Test
    void allAnnotationFieldsTest() {
        Validator validator = new ValidationHandler();
        TestForm1 tf = new TestForm1();
        tf.someSet = new HashSet<>(100);
        tf.someList = new ArrayList<>(100);
        tf.positiveNumber = -1;
        tf.negativeNumber = 1;
        tf.blankString = new String();
        tf.nullObject = null;
        tf.emptyString = "";
        tf.emptyList = new ArrayList<>();
        tf.inRange = 228;
        Set<ValidationError> errors = validator.validate(tf);
        assertEquals(errors.size(), 10);

    }

    /**
     * Test case that checks all kinds of annotations applied to list elements
     */
    @DisplayName("All annotations as list parameters")
    @Test
    void allAnnotationsListTest() {
        Validator validator = new ValidationHandler();
        TestForm1 tf = new TestForm1();
        tf.emptyListList = new ArrayList<>();
        tf.emptyListList.add(new ArrayList<>());
        tf.emptyListList.add(new ArrayList<>());
        tf.emptyListList.add(new ArrayList<>());

        tf.negativeNumberList = new ArrayList<>();
        tf.negativeNumberList.add(1);
        tf.negativeNumberList.add(2);
        tf.negativeNumberList.add(3);

        tf.positiveNumberList = new ArrayList<>();
        tf.positiveNumberList.add(-1);
        tf.positiveNumberList.add(-2);
        tf.positiveNumberList.add(-3);

        tf.anyOfList = new ArrayList<>();
        tf.anyOfList.add("Luffy");
        tf.anyOfList.add("Goku");
        tf.anyOfList.add("Kaneki");

        tf.inRangeList = new ArrayList<>();
        tf.inRangeList.add(1488);
        tf.inRangeList.add(1488);
        tf.inRangeList.add(1488);

        tf.emptyStringList = new ArrayList<>();
        tf.emptyStringList.add("");
        tf.emptyStringList.add("");
        tf.emptyStringList.add("");

        tf.blankStringList = new ArrayList<>();
        tf.blankStringList.add(new String());
        tf.blankStringList.add(new String());
        tf.blankStringList.add(new String());

        Set<ValidationError> errors = validator.validate(tf);
        assertEquals(22, errors.size());
    }
}