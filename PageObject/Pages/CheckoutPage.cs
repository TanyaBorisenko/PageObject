using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class CheckoutPage : BasePage<CheckoutPage>
    {
        private readonly By _cancelButton = By.CssSelector(".btn btn_secondary back.btn_medium cart_cancel_link");
        private readonly By _continueButton = By.Id("continue");
        private readonly By _firstNameInfo = By.Id("first-name");
        private readonly By _lastNameInfo = By.Id("last-name");
        private readonly By _postalCodeInfo = By.Id("postal-code");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public override CheckoutPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(By.XPath("//*[@class = 'title']")));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(CheckoutPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override CheckoutPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/checkout-step-one.html");
            WaitForPageOpened();
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(By.XPath("//*[@class = 'title']")));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
        }

        public OverviewPage InsertData(string firstName, string lastname, string zipCode)
        {
            Driver.FindElement(_firstNameInfo).SendKeys(firstName);
            Driver.FindElement(_lastNameInfo).SendKeys(lastname);
            Driver.FindElement(_postalCodeInfo).SendKeys(zipCode);
            Driver.FindElement(_continueButton).Click();
            return new OverviewPage(Driver);
        }

        public CartMenu CancelButton()
        {
            Driver.FindElement(_cancelButton).Click();
            return new CartMenu(Driver);
        }
    }
}