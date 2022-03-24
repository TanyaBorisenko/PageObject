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
            try
            {
                Wait.Until(d => d.FindElement(_detailsContainer));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(ItemPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override ItemPage OpenPage()
        {
            WaitForPageOpened();
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_detailsContainer));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
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