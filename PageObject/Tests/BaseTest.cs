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
        public string Password = "secret_sauce";
        public CartMenu CartMenu;
        public CheckoutPage CheckoutPage;
        public FinishPage FinishPage;
        public ItemPage ItemPage;
        public LoginPage LoginPage;
        public ProductsPage ProductsPage;
        public MenuButton MenuButton;
        public OverviewPage OverviewPage;

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
            MenuButton = new MenuButton(_driver);
            OverviewPage = new OverviewPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
        
        // tanya govnokoder, ia pzdc bydy rjat esli ona etogo ne zametit
    }
}