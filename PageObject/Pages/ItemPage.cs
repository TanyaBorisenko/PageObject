using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class ItemPage : BasePage<ItemPage>

    {
        private readonly By _backButton = By.Id("back-to-products");
        private readonly By _detailsContainer = By.CssSelector("[class ='inventory_details_desc_container']");

        public ItemPage(IWebDriver driver) : base(driver)
        {
        }

        public override ItemPage WaitForPageOpened()
        {
            return this;
        }

        public override ItemPage OpenPage()
        {
            return this;
        }

        public ItemPage ClickBackButton()
        {
            Driver.FindElement(_backButton).Click();
            return this;
        }

        public string GetItem()
        {
            return Driver.FindElement(_detailsContainer).Text;
        }
    }
}