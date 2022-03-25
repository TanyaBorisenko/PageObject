using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class CartMenu : BasePage<CartMenu>
    {
        private readonly By _checkoutButton = By.Id("checkout");
        private readonly By _continueShoppingButton = By.Id("continue-shopping");
        private readonly By _headerLabel = By.XPath("//*[@class = 'title']");

        public CartMenu(IWebDriver driver) : base(driver)
        {
        }

        public override CartMenu WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_headerLabel));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(CartMenu)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override CartMenu OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/cart.html");
            WaitForPageOpened();
            return this;
        }

        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_headerLabel));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
        }

        public ProductsPage ContinueShopping()
        {
            Driver.FindElement(_continueShoppingButton).Click();
            return new ProductsPage(Driver);
        }

        public CheckoutPage CheckoutButton()
        {
            Driver.FindElement(_checkoutButton).Click();
            return new CheckoutPage(Driver);
        }
    }
}