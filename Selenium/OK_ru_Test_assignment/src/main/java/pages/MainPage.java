package pages;

import factories.TestsConfig;
import org.openqa.selenium.By;

import static com.codeborne.selenide.Selenide.open;

public class MainPage {
    public final By NAVIGATION_USER_PAGE = By.xpath("//*[@id=\"hook_Block_Navigation\"]/div/div/a[1]/div");
    public MainPage() {
    }

    public SettingsPage goToSettings() {
        open(TestsConfig.getProperty("BASE_URL") + "/settings");
        return new SettingsPage();
    }
}
