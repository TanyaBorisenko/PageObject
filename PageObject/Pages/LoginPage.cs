using System;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class LoginPage : BasePage<LoginPage>
    {
        private readonly By _usernameField = By.Id("user-name");
        private readonly By _passwordField = By.Id("password");
        private readonly By _singInButton = By.Id("login-button");


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override LoginPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(_singInButton));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new WebDriverTimeoutException($"Page {nameof(LoginPage)} is not opened. Message : {e.Message}");
            }

            return this;
        }

        public override LoginPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageOpened();
            return this;
        }
        
        public override bool IsPageOpened()
        {
            {
                bool isOpened;
                try
                {
                    Wait.Until(d => d.FindElement(_singInButton));
                    isOpened = true;
                }
                catch (WebDriverTimeoutException e)
                {
                    isOpened = false;
                }

                return isOpened;
            }
        }
        

        public ProductsPage LoginInApp(string username, string password)
        {
            Driver.FindElement(_usernameField).SendKeys(username);
            Driver.FindElement(_passwordField).SendKeys(password);
            Driver.FindElement(_singInButton).Click();
            return new ProductsPage(Driver);
        }
    }
}