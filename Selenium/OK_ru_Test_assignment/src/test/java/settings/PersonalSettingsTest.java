package settings;


import factories.TestsConfig;
import org.openqa.selenium.Keys;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.Test;
import pages.LoginPage;
import pages.SettingsPage;

import static com.codeborne.selenide.Condition.text;
import static com.codeborne.selenide.Condition.visible;
import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.open;

@Test
public class PersonalSettingsTest {

    @BeforeClass
    static void login() {
        new LoginPage().login().goToSettings();
    }

    @AfterMethod
    void prepare() {
        open(TestsConfig.getProperty("BASE_URL") + "/settings");
    }

    @Test (priority = 2, enabled = false)
    void test_change_name_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeName("Ivan").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("Ivan"));
    }

    @Test (priority = 2, enabled = false)
    void test_change_surname_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeSurname("Ivanov").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("Ivanov"));
    }

    @Test (priority = 2, testName = "Day change")
    void test_change_birth_day_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthDay("20").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("20"));
    }

    @Test (priority = 2, testName = "Month change")
    void test_change_birth_month_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthMonth("июнь").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("июня"));
    }

    @Test (priority = 2, testName = "Year valid")
    void test_change_birth_year_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthYear("1999").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("1999"));
    }

    @Test (priority = 2, testName = "Leap year")
    void test_change_birt_date_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthDay("29").changeBirthMonth("февраль").changeBirthYear("2000").saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("29 февраля 2000"));
    }

    @Test (priority = 2, testName = "Man")
    void test_change_gender_men() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.selectMaleGender().saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("родился"));
    }

    @Test (priority = 2, testName = "Woman")
    void test_change_gender_women() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.selectFemaleGender().saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("родилась"));
    }

    @Test (priority = 2, testName = "Current address")
    void test_change_current_address_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeCurrentLocationOther().saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldHave(text("Зеленоград"));
    }

    @Test (priority = 2, testName = "Native address")
    void test_change_native_address_valid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeNativeLocationOther().saveEdition();
        $(settingsPage.USER_PERSONAL_DATA).shouldBe(visible).shouldHave(text("Зеленоград"));
    }


    @Test (priority = 3, testName = "Numbers in name", enabled = false)
    void test_change_name_invalid_1() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeSurname("123").saveEdition();
        $(settingsPage.SURNAME_ERROR).shouldHave(text("Пожалуйста, используйте только буквы"));
    }

    @Test (priority = 3, testName = "Empty name")
    void test_change_name_invalid_2() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        for (int i = 0; i < 10; i++) {
            $(settingsPage.NAME).sendKeys(Keys.BACK_SPACE);
        }
        settingsPage.saveEdition();
        $(settingsPage.NAME_ERROR).shouldHave(text("Пожалуйста, укажите ваше имя"));
    }

    @Test (priority = 3, testName = "Invalid symbols in name")
    void test_change_name_invalid_3() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        $(settingsPage.NAME).sendKeys(Keys.BACK_SPACE);
        $(settingsPage.NAME).sendKeys("#$%^");
        settingsPage.saveEdition();
        $(settingsPage.NAME_ERROR).shouldHave(text("Пожалуйста, используйте только буквы"));
    }


    @Test (priority = 3, testName = "Numbers in surname", enabled = false)
    void test_change_surname_invalid_1() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeSurname("1234").saveEdition();
        $(settingsPage.SURNAME_ERROR).shouldHave(text("Пожалуйста, используйте только буквы"));
    }

    @Test (priority = 3, testName = "Empty surname")
    void test_change_surname_invalid_2() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        for (int i = 0; i < 10; i++) {
            $(settingsPage.SURNAME).sendKeys(Keys.BACK_SPACE);
        }
        settingsPage.saveEdition();
        $(settingsPage.SURNAME_ERROR).shouldHave(text("Пожалуйста, укажите вашу фамилию"));
    }

    @Test (priority = 3, testName = "Invalid symbols in surname")
    void test_change_surname_invalid_3() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        $(settingsPage.SURNAME).sendKeys(Keys.BACK_SPACE);
        $(settingsPage.SURNAME).sendKeys("#$%^");
        settingsPage.saveEdition();
        $(settingsPage.SURNAME_ERROR).shouldHave(text("Пожалуйста, используйте только буквы"));
    }


    @Test (priority = 3, testName = "February 31")
    void test_change_birt_date_invalid_1() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthDay("31").changeBirthMonth("февраль").saveEdition();
        $(settingsPage.DATE_ERROR).shouldHave(text("День вашего рождения указан некорректно"));
    }

    @Test (priority = 3, testName = "June 31")
    void test_change_birt_date_invalid_2() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthDay("31").changeBirthMonth("июнь").saveEdition();
        $(settingsPage.DATE_ERROR).shouldHave(text("День вашего рождения указан некорректно"));
    }

    @Test (priority = 3, testName = "Leap year invalid")
    void test_change_birt_date_invalid_3() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        settingsPage.changeBirthDay("29").changeBirthMonth("февраль").changeBirthYear("2001").saveEdition();
        $(settingsPage.DATE_ERROR).shouldHave(text("День вашего рождения указан некорректно"));
    }

    @Test (priority = 3, testName = "Invalid current address")
    void test_change_current_address_invalid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        $(settingsPage.CURRENT_LOCATION).sendKeys(Keys.BACK_SPACE);
        $(settingsPage.CURRENT_LOCATION).sendKeys("Москва");
        settingsPage.saveEdition();
        $(settingsPage.CURRENT_LOCATION_ERROR).shouldHave(text("Пожалуйста, выберите место проживания из списка"));
    }

    @Test (priority = 3, testName = "Invalid native address")
    void test_change_native_address_invalid() {
        var settingsPage = new SettingsPage().openEditPersonalDataForm();
        $(settingsPage.NATIVE_LOCATION).sendKeys(Keys.BACK_SPACE);
        $(settingsPage.NATIVE_LOCATION).sendKeys("Москва");
        settingsPage.saveEdition();
        $(settingsPage.NATIVE_LOCATION_ERROR).shouldHave(text("Пожалуйста, выберите родной город из списка"));
    }
}
