import org.junit.jupiter.api.Test;

import java.lang.reflect.Field;
import java.util.*;

import static org.junit.jupiter.api.Assertions.*;

class ValidationErrorTest {

    @Test
    void PositiveTest() {
        TestForm1 tf = new TestForm1();
        tf.positiveNumber = -1;
        PositiveValidationError error = new PositiveValidationError("positiveNumber", tf);
        assertEquals(error.getMessage(), "must be positive");
        assertEquals(error.getFailedValue(), -1);
        assertEquals(error.getPath(), "positiveNumber");
    }

    @Test
    void NegativeTest() {
        TestForm1 tf = new TestForm1();
        tf.negativeNumber = 1000 - 7;
        NegativeValidationError error = new NegativeValidationError("negativeNumber", tf);
        assertEquals(error.getMessage(), "must be negative");
        assertEquals(error.getFailedValue(), 993);
        assertEquals(error.getPath(), "negativeNumber");
    }

    @Test
    void AnyOfTest() throws NoSuchFieldException {
        TestForm1 tf = new TestForm1();
        tf.anyOf = "Luffy";
        Field anyOfField = tf.getClass().getDeclaredField("anyOf");
        AnyOfValidationError error = new AnyOfValidationError(
                "anyOf",
                tf,
                anyOfField.getAnnotatedType().getAnnotation(AnyOf.class)
        );
        assertEquals(error.getMessage(), "must be one of 'Sasuke', 'Naruto', 'Tsunade'");
        assertEquals(error.getFailedValue(), "Luffy");
        assertEquals(error.getPath(), "anyOf");
    }

    @Test
    void InRangeTest() throws NoSuchFieldException {
        TestForm1 tf = new TestForm1();
        tf.inRange = 1000 - 7;
        Field inRangeField = tf.getClass().getDeclaredField("inRange");
        InRangeValidationError error = new InRangeValidationError(
                "inRange",
                tf,
                inRangeField.getAnnotatedType().getAnnotation(InRange.class)
        );
        assertEquals(error.getMessage(), "number must be in range between 0 and 100");
        assertEquals(error.getFailedValue(), 993);
        assertEquals(error.getPath(), "inRange");
    }

    @Test
    void SizeTest() throws NoSuchFieldException {
        TestForm1 tf = new TestForm1();
        tf.someList = new ArrayList<Integer>();
        tf.someMap = new HashMap<Integer, Integer>();
        tf.someSet = new HashSet<Integer>();
        setListMapSet(tf);
        Field setField = tf.getClass().getDeclaredField("someSet");
        Field mapField = tf.getClass().getDeclaredField("someMap");
        Field listField = tf.getClass().getDeclaredField("someList");
        SizeValidationError error1 = new SizeValidationError(
                "someList",
                tf,
                listField.getAnnotatedType().getAnnotation(Size.class)
        );
        SizeValidationError error2 = new SizeValidationError(
                "someSet",
                tf,
                setField.getAnnotatedType().getAnnotation(Size.class)
        );
        SizeValidationError error3 = new SizeValidationError(
                "someMap",
                tf,
                mapField.getAnnotatedType().getAnnotation(Size.class)
        );
        assertEquals(error1.getMessage(), "size must be in range between 1 to 5");
        assertEquals(((List<?>)error1.getFailedValue()).size(), 6);
        assertEquals(error1.getPath(), "someList");
        assertEquals(error2.getMessage(), "size must be in range between 1 to 5");
        assertEquals(((Set<?>)error2.getFailedValue()).size(), 10);
        assertEquals(error2.getPath(), "someSet");
        assertEquals(error3.getMessage(), "size must be in range between 1 to 5");
        assertEquals(((Map<?, ?>)error3.getFailedValue()).size(), 8);
        assertEquals(error3.getPath(), "someMap");
    }

    private void setListMapSet(TestForm1 tf) {
        tf.someList.add(1);
        tf.someList.add(2);
        tf.someList.add(3);
        tf.someList.add(4);
        tf.someList.add(5);
        tf.someList.add(6);
        tf.someMap.put(1, 1);
        tf.someMap.put(2, 1);
        tf.someMap.put(3, 1);
        tf.someMap.put(4, 1);
        tf.someMap.put(5, 1);
        tf.someMap.put(6, 1);
        tf.someMap.put(7, 1);
        tf.someMap.put(8, 1);
        tf.someSet.add(1);
        tf.someSet.add(2);
        tf.someSet.add(3);
        tf.someSet.add(4);
        tf.someSet.add(5);
        tf.someSet.add(6);
        tf.someSet.add(7);
        tf.someSet.add(8);
        tf.someSet.add(9);
        tf.someSet.add(10);
    }

    @Test
    void NotNullTest() {
        TestForm1 tf = new TestForm1();
        tf.nullObject = null;
        NotNullValidationError error = new NotNullValidationError("nullObject", tf);
        assertEquals(error.getMessage(), "must not be null");
        assertNull(error.getFailedValue());
        assertEquals(error.getPath(), "nullObject");
    }

    @Test
    void NotEmptyTest() {
        TestForm1 tf = new TestForm1();
        tf.emptyString = "";
        tf.emptyList = new ArrayList<Integer>();
        NotEmptyValidationError error1 = new NotEmptyValidationError("emptyString", tf);
        NotEmptyValidationError error2 = new NotEmptyValidationError("emptyList", tf);
        assertEquals(error1.getMessage(), "must not be empty");
        assertEquals(error1.getFailedValue(), "");
        assertEquals(error1.getPath(), "emptyString");
        assertEquals(error2.getMessage(), "must not be empty");
        assertArrayEquals(((ArrayList<Integer>) error2.getFailedValue()).toArray(), (new ArrayList<Integer>()).toArray());
        assertEquals(error2.getPath(), "emptyList");
    }

    @Test
    void NotBlankTest() {
        TestForm1 tf = new TestForm1();
        tf.blankString = new String();
        NotBlankValidationError error = new NotBlankValidationError("blankString", tf);
        assertEquals(error.getMessage(), "must not be blank");
        assertEquals(error.getFailedValue(), "");
        assertEquals(error.getPath(), "blankString");
    }
}