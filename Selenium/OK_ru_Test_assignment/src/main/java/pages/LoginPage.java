package pages;

import factories.TestsConfig;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Selenide.$;
import static com.codeborne.selenide.Selenide.open;

public class LoginPage {
    public final By LOGIN_BUTTON = By.xpath("//*[@id=\"anonymPageContent\"]/div[2]/div/div[3]/form/div[5]/div[1]/input");
    public final By EMAIL = By.name("st.email");
    public final By PASSWORD = By.name("st.password");

    public LoginPage() {
        open(TestsConfig.getProperty("BASE_URL"));
    }

    public MainPage login() {
        $(EMAIL).setValue(TestsConfig.getProperty("LOGIN"));
        $(PASSWORD).setValue(TestsConfig.getProperty("PASSWORD"));
        $(LOGIN_BUTTON).click();
        return new MainPage();
    }
}
