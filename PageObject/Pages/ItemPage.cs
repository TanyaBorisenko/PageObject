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
            Driver.Navigate().GoToUrl(Url + "/inventory-item.html");
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

        public ProductsPage ClickBackButton()
        {
            Driver.FindElement(_backButton).Click();
            return new ProductsPage(Driver);
        }

        public ItemPage GetItem()
        {
            Driver.FindElement(_detailsContainer);
            
            return this;
        }
    }
}