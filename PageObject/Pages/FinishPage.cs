using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class FinishPage : BasePage<FinishPage>
    {
        private readonly By _backButton = By.Id("back-to-products");
        private readonly By _completeHeader = By.ClassName("complete-header");

        public FinishPage(IWebDriver driver) : base(driver)
        {
        }

        public override FinishPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_completeHeader));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(FinishPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override FinishPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/checkout-complete.html");
            WaitForPageOpened();
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_completeHeader));
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
    }
}