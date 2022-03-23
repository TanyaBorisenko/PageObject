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
            return this;
        }

        public override FinishPage OpenPage()
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