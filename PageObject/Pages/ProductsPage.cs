using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class ProductsPage : BasePage<ProductsPage>
    {
        private readonly By _menuButton = By.Id("react-burger-menu-btn");
        private readonly By _cartButton = By.Id("shopping_cart_container");
        private readonly By _sortContainer = By.CssSelector("[class = 'product_sort_container']");
        private readonly string _addToCartButton = "//*[@class='inventory_item']//*[text()='Add to cart']";
        private readonly string _removeButton = "//*[@class='inventory_item']//*[text()='Remove']";
        private readonly By _nameProduct = By.CssSelector("[class = 'inventory_item_name']");
        private readonly By _productDescription = By.CssSelector("[class = 'inventory_item_desc']");
        string _productImg = "//div[@class ='inventory_item_img']";
        private readonly By _twitterButton = By.ClassName("social_twitter");
        private readonly By _facebookButton = By.ClassName("social_facebook");
        private readonly By _linkedinButton = By.ClassName("social_linkedin");
        private readonly By _cartBadgeIcon = By.ClassName("shopping_cart_badge");

        public ProductsPage(IWebDriver driver) : base(driver)
        {
        }

        public override ProductsPage WaitForPageOpened()
        {
            try
            {
                Wait.Until(d => d.FindElement(By.ClassName("app_logo")));
            }
            catch (TimeoutException e)
            {
                throw new Exception(e.Message);
            }

            return this;
        }

        public override ProductsPage OpenPage()
        {
            Driver.Navigate().GoToUrl(Url + "/inventory.html");
            WaitForPageOpened();
            return this;
        }

        public ProductsPage AddProduct(string product)
        {
            Driver.FindElement(By.XPath(string.Format(_addToCartButton, product))).Click();
            return this;
        }

        public ProductsPage RemoveProduct(string product)
        {
            Driver.FindElement(By.XPath(string.Format(_removeButton, product))).Click();
            return this;
        }

        public ProductsPage AddThenRemoveProduct(string product)
        {
            AddProduct(product);
            RemoveProduct(product);
            return this;
        }

        public ItemPage ClickOnImg(string productName)
        {
            Driver.FindElement(By.XPath(string.Format(_productImg, productName))).Click();
            return new ItemPage(Driver);
        }

        public ItemPage ClickOnName()
        {
            Driver.FindElement(_nameProduct).Click();
            return new ItemPage(Driver);
        }

        public ProductsPage ClickTwitterButton()
        {
            Driver.FindElement(_twitterButton).Click();
            return this;
        }

        public ProductsPage ClickFacebookButton()
        {
            Driver.FindElement(_facebookButton).Click();
            return this;
        }

        public ProductsPage ClickLinkedinButton()
        {
            Driver.FindElement(_linkedinButton).Click();
            return this;
        }

        public int GetCartBadgeAmount()
        {
            var amount = Driver.FindElement(_cartBadgeIcon).Text;
            return int.Parse(amount);
        }

        public bool DescriptionIsDisplayed()
        {
            try
            {
                Driver.FindElement(_productDescription);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public MenuButton ClickMenuButton()
        {
            Driver.FindElement(_menuButton).Click();
            return new MenuButton(Driver);
        }

        public CartMenu ClickCartButton()
        {
            Driver.FindElement(_cartButton).Click();
            return new CartMenu(Driver);
        }

        public IList<string> GetSortedAtZaProductLabels()
        {
            Driver.FindElement(_sortContainer).Click();
            Driver.FindElement(By.XPath("//*[@class = 'product_sort_container']//following::*[@value = 'za']")).Click();
            var products = Driver.FindElements(_nameProduct).Select(e => e.Text).ToList();

            return products;
        }

        public IList<string> GetSortedAtAzProductLabels()
        {
            Driver.FindElement(_sortContainer).Click();
            Driver.FindElement(By.XPath("//*[@class = 'product_sort_container']//following::*[@value = 'az']")).Click();
            var products = Driver.FindElements(_nameProduct).Select(e => e.Text).ToList();

            return products;
        }

        public IList<string> GetSortedAtLtoHProductLabels()
        {
            Driver.FindElement(_sortContainer).Click();
            Driver.FindElement(By.XPath("//*[@class = 'product_sort_container']//following::*[@value = 'lohi']"))
                .Click();
            var products = Driver.FindElements(By.CssSelector("[class = 'inventory_item_price']")).Select(e => e.Text)
                .ToList();

            return products;
        }

        public IList<string> GetSortedAtHtoLProductLabels()
        {
            Driver.FindElement(_sortContainer).Click();
            Driver.FindElement(By.XPath("//*[@class = 'product_sort_container']//following::*[@value = 'hilo']"))
                .Click();
            var products = Driver.FindElements(By.CssSelector("[class = 'inventory_item_price']")).Select(e => e.Text)
                .ToList();

            return products;
        }
    }
}