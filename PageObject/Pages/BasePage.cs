using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObject.Pages
{
    public abstract class BasePage<T>
    {
        protected readonly string Url = "https://www.saucedemo.com/";
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public abstract T WaitForPageOpened();

        public abstract T OpenPage();

        public abstract bool IsPageOpened();
    }
}