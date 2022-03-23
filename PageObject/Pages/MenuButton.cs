using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class MenuButton : BasePage<MenuButton>
    {
        private readonly By _menuList = By.ClassName("bm-item-list");
        private readonly By _logoutButton = By.XPath("//*[contains(text() , 'Logout')]");
        private readonly By _closeMenuButton = By.Id("react-burger-cross-btn");

        public MenuButton(IWebDriver driver) : base(driver)
        {
        }

        public override MenuButton WaitForPageOpened()
        {
            return this;
        }

        public override MenuButton OpenPage()
        {
            Driver.FindElement(_menuList);
            return this;
        }

        public ProductsPage CloseButton()
        {
            Driver.FindElement(_closeMenuButton).Click();
            return new ProductsPage(Driver);
        }

        public LoginPage LogOutButton()
        {
            Driver.FindElement(_logoutButton).Click();
            return new LoginPage(Driver);
        }
    }
}