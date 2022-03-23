using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class OverviewPage : BasePage
    {
        private readonly By _finishButton = By.CssSelector("[class = 'btn btn_action btn_medium cart_button']");
        private readonly By _complete = By.Id("checkout_summary_container");

        public OverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public override BasePage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_finishButton));
            }
            catch (TimeoutException e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }

        public override BasePage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/checkout-step-two.html");
            WaitForPageOpened();
            return this;
        }

        public FinishPage ClickFinishButton()
        {
            Driver.FindElement(_finishButton).Click();
            return new FinishPage(Driver);
        }

        public OverviewPage Complete()
        {
            Wait.Until(d => d.FindElement(_complete));
            return this;
        }
    }
}