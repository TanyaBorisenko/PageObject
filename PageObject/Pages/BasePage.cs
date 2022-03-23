using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public abstract class BasePage
    {
        protected readonly string Url = "https://www.saucedemo.com/";
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public abstract BasePage WaitForPageOpened();

        public abstract BasePage OpenPage();
    }
}