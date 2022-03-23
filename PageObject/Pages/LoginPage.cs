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
            catch (TimeoutException e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }

        public override LoginPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url);
            WaitForPageOpened();
            return this;
        }

        public ProductsPage ClickSingInButton(string username, string password)
        {
            Driver.FindElement(_usernameField).SendKeys(username);
            Driver.FindElement(_passwordField).SendKeys(password);
            Driver.FindElement(_singInButton).Click();
            return new ProductsPage(Driver);
        }
    }
}