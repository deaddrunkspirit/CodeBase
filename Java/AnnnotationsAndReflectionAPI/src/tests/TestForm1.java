import java.util.List;
import java.util.Map;
import java.util.Set;

@Constrained
class TestForm1 {
    @Positive
    int positiveNumber;

    @Negative
    int negativeNumber;

    @NotBlank
    String blankString;

    @NotNull
    Object nullObject;

    @NotEmpty
    List<Integer> emptyList;

    @NotEmpty
    String emptyString;

    @Size(min=1, max=5)
    List<Integer> someList;

    @Size(min=1, max=5)
    Map<Integer, Integer> someMap;

    @Size(min=1, max=5)
    Set<Integer> someSet;

    @InRange(min=0, max=100)
    Integer inRange;

    @AnyOf({"Sasuke", "Naruto", "Tsunade"})
    String anyOf;

    @Positive
    @Negative
    Integer positiveAndNegative;

    @NotNull
    List<@Positive @Negative Integer> positiveNegativeField;

    List<@Positive Integer> positiveNumberList;

    List<@Negative Integer> negativeNumberList;

    List<@NotBlank String> blankStringList;

    List<@NotEmpty List<Integer>> emptyListList;

    List<@NotEmpty String> emptyStringList;

    List<@InRange(min=0, max=100) Integer> inRangeList;

    List<@AnyOf({"Sasuke", "Naruto", "Tsunade"}) String> anyOfList;

}