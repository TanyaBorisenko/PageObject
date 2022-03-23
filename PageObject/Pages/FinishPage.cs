using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class FinishPage : BasePage
    {
        private readonly By _backButton = By.Id("back-to-products");
        private readonly By _completeHeader = By.ClassName("complete-header");

        public FinishPage(IWebDriver driver) : base(driver)
        {
        }

        public override BasePage WaitForPageOpened()
        {
            return this;
        }

        public override BasePage OpenPage()
        {
            Driver.FindElement(_completeHeader);
            return this;
        }

        public ProductsPage ClickBackButton()
        {
            Driver.FindElement(_backButton).Click();
            return new ProductsPage(Driver);
        }
    }
}