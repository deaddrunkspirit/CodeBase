import java.util.List;

@Constrained
public class TestForm2 {

    @Positive
    String classCastPositive;

    @Negative
    String classCastNegative;

    @NotBlank
    Integer classCastNotBlank;

    @NotEmpty
    Integer classCastNotEmpty;

    @AnyOf({"UNO", "DOS", "TRES"})
    Integer classCastAnyOf;

    @Size(min=1, max=10)
    Double classCastSize;

    @InRange(min=1, max = 10)
    Double classCastInRange;
}
