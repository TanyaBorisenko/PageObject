using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class MenuPage : BasePage<MenuPage>
    {
        private readonly By _menuList = By.ClassName("bm-item-list");
        private readonly By _logoutButton = By.XPath("//*[contains(text() , 'Logout')]");
        private readonly By _closeMenuButton = By.Id("react-burger-cross-btn");

        public MenuPage(IWebDriver driver) : base(driver)
        {
        }

        public override MenuPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_menuList));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(CheckoutPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override MenuPage OpenPage()
        {
            Driver.FindElement(_menuList);
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_menuList));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
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