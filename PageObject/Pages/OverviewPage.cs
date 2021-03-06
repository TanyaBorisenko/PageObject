using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class OverviewPage : BasePage<OverviewPage>
    {
        private readonly By _finishButton = By.CssSelector("[class = 'btn btn_action btn_medium cart_button']");
        private readonly By _complete = By.Id("checkout_summary_container");

        public OverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public override OverviewPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_finishButton));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(OverviewPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override OverviewPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/checkout-step-two.html");
            WaitForPageOpened();
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_finishButton));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
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