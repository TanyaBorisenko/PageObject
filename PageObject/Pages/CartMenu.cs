using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class CartMenu : BasePage
    {
        private readonly By _checkoutButton = By.Id("checkout");
        private readonly By _continueShoppingButton = By.Id("continue-shopping");

        public CartMenu(IWebDriver driver) : base(driver)
        {
        }

        public override BasePage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(By.XPath("//*[@class = 'title']")));
            }
            catch (TimeoutException e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }

        public override BasePage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/cart.html");
            WaitForPageOpened();
            return this;
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