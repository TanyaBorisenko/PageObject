using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Pages;

namespace PageObject.Tests
{
    public abstract class BaseTest
    {
        private WebDriver _driver;
        protected string UserName = "standard_user";
        protected string Password = "secret_sauce";
        protected CartMenu CartMenu;
        protected CheckoutPage CheckoutPage;
        protected FinishPage FinishPage;
        protected ItemPage ItemPage;
        protected LoginPage LoginPage;
        protected ProductsPage ProductsPage;
        protected MenuPage MenuPage;
        protected OverviewPage OverviewPage;

        [SetUp]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            
            CartMenu = new CartMenu(_driver);
            CheckoutPage = new CheckoutPage(_driver);
            FinishPage = new FinishPage(_driver);
            ItemPage = new ItemPage(_driver);
            LoginPage = new LoginPage(_driver);
            ProductsPage = new ProductsPage(_driver);
            MenuPage = new MenuPage(_driver);
            OverviewPage = new OverviewPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}