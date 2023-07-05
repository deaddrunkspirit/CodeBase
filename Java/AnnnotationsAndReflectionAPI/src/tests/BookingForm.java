import java.util.List;

@Constrained
public class BookingForm {
    @NotNull
    @Size(min = 1, max = 5)
    private List<@NotNull GuestForm> guests;
    @NotNull
    private List<@AnyOf({"TV", "Kitchen"}) String> amenities;
    @NotNull
    @AnyOf({"House", "Hostel"})
    private String propertyType;
    @NotNull
    private Unrelated unrelated;
    public BookingForm(List<GuestForm> guests, List<String> amenities, String
            propertyType, Unrelated unrelated) {
        this.guests = guests;
        this.amenities = amenities;
        this.unrelated = unrelated;
        this.propertyType = propertyType;
    }
}