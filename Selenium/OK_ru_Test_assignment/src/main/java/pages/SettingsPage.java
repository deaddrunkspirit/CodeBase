package pages;

import com.codeborne.selenide.Condition;
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;

import static com.codeborne.selenide.Selenide.$;

public class SettingsPage {
    public final By NAME = By.name("fr.name");
    public final By SURNAME = By.name("fr.surname");
    public final By BIRTH_DAY = By.name("fr.bday");
    public final By BIRTH_MONTH = By.name("fr.bmonth");
    public final By BIRTH_YEAR = By.name("fr.byear");
    public final By GENDER_MALE = By.id("field_gender_1");
    public final By GENDER_FEMALE = By.id("field_gender_2");
    public final By CURRENT_LOCATION= By.name("fr.citySugg_SearchInput");
    public final By NATIVE_LOCATION = By.name("fr.cityBSugg_SearchInput");
    public final By SAVE_BUTTON = By.name("button_savePopLayerEditUserProfileNew");
    public final By CURRENT_LOCATION_MSC = By.xpath("//*[@id=\"citySugg_InputContainer_10407994421\"]");
    public final By CURRENT_LOCATION_OTHER = By.xpath("//*[@id=\"citySugg_InputContainer_23359457760\"]");
    public final By NATIVE_LOCATION_MSC = By.xpath("//*[@id=\"cityBSugg_InputContainer_10407994421\"]");
    public final By NATIVE_LOCATION_OTHER = By.xpath("//*[@id=\"cityBSugg_InputContainer_23359457760\"]");
    public final By USER_PERSONAL_DATA = By.xpath("//*[@id=\"hook_Block_UserConfigMRB\"]/div/div[2]/a[1]");
    public final By DATE_ERROR =
            By.xpath("//*[@id=\"hook_Form_PopLayerEditUserProfileNewForm\"]/form/div[1]/div[3]/span[2]");
    public final By CURRENT_LOCATION_ERROR =
            By.xpath("//*[@id=\"hook_Form_PopLayerEditUserProfileNewForm\"]/form/div[1]/div[5]/span");
    public final By NATIVE_LOCATION_ERROR =
            By.xpath("//*[@id=\"hook_Form_PopLayerEditUserProfileNewForm\"]/form/div[1]/div[6]/span");
    public final By SURNAME_ERROR =
            By.xpath("//*[@id=\"hook_Form_PopLayerEditUserProfileNewForm\"]/form/div[1]/div[2]/span[2]");
    public final By NAME_ERROR =
            By.xpath("//*[@id=\"hook_Form_PopLayerEditUserProfileNewForm\"]/form/div[1]/div[1]/span[2]");

    public SettingsPage() {

    }

    public SettingsPage openEditPersonalDataForm() {
        $(USER_PERSONAL_DATA).shouldBe(Condition.visible).click();
        return this;
    }

    public SettingsPage changeName(String newName) {
        $(NAME).click();
        $(NAME).sendKeys(Keys.BACK_SPACE);
        $(NAME).setValue(newName);
        return this;
    }

    public SettingsPage changeSurname(String newSurname) {
        $(SURNAME).click();
        $(SURNAME).sendKeys(Keys.BACK_SPACE);
        $(SURNAME).setValue(newSurname);
        return this;
    }

    public SettingsPage changeBirthDay(String optionText) {
        $(BIRTH_DAY).selectOptionContainingText(optionText);
        return this;
    }

    public SettingsPage changeBirthMonth(String optionText) {
        $(BIRTH_MONTH).selectOptionContainingText(optionText);
        return this;
    }

    public SettingsPage changeBirthYear(String optionText) {
        $(BIRTH_YEAR).selectOptionContainingText(optionText);
        return this;
    }

    public SettingsPage selectMaleGender() {
        $(GENDER_MALE).click();
        return this;
    }

    public SettingsPage selectFemaleGender() {
        $(GENDER_FEMALE).click();
        return this;
    }

    public SettingsPage changeNativeLocationMSC() {
        $(NATIVE_LOCATION).click();
        $(NATIVE_LOCATION).clear();
        $(NATIVE_LOCATION_MSC).click();
        $(NAME).click();
        return this;
    }

    public SettingsPage changeNativeLocationOther() {
        $(NATIVE_LOCATION).click();
        $(NATIVE_LOCATION).clear();
        $(NATIVE_LOCATION_OTHER).click();
        $(NAME).click();
        return this;
    }

    public SettingsPage changeCurrentLocationMSC() {
        $(CURRENT_LOCATION).click();
        $(CURRENT_LOCATION).clear();
        $(CURRENT_LOCATION_MSC).click();
        $(NAME).click();
        return this;
    }

    public SettingsPage changeCurrentLocationOther() {
        $(CURRENT_LOCATION).click();
        $(CURRENT_LOCATION).clear();
        $(CURRENT_LOCATION_OTHER).click();
        $(NAME).click();
        return this;
    }

    public SettingsPage saveEdition() {
        $(SAVE_BUTTON).click();
        return this;
    }
}
