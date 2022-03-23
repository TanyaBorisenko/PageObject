using NUnit.Framework;

namespace PageObject.Tests
{
    public class CartTest : BaseTest
    {
        [Test]
        public void AddProductIntoTheCart_IconCartShouldShowAddedProduct_OnTheProductPage()
        {
            // // Open Sauce Demo Login Page
            // LoginPage.OpenPage();
            //
            // // Login
            // LoginPage.ClickSingInButton(UserName, Password);
            //
            // // I am in Product Page
            // ProductsPage.WaitForPageOpened();
            //
            // // Add product
            // ProductsPage.AddProduct("Sauce Labs Backpack");
            //
            // // Get amount from cart badge
            // var amount = ProductsPage.GetCartBadgeAmount();

           var amount = LoginPage
                .OpenPage()
                .ClickSingInButton(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .GetCartBadgeAmount();

           Assert.AreEqual(1, amount);
        }

        //Remove product from the cart
        [Test]
        public void RemoveProductFromCart_IconCartShouldNotShowAddedProduct_OnTheProductPage()
        {
            var amount = LoginPage
                .OpenPage()
                .ClickSingInButton(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .RemoveProduct("Sauce Labs Backpack")
                .GetCartBadgeAmount();

            Assert.AreEqual(0, amount);
        }

        //Click "Continue" button
        [Test]
        public void ContinueShoppingButton()
        {
            CartMenu.ContinueShopping();
        }

        //Click "Checkout" button
        [Test]
        public void ClickCheckoutButton()
        {
            CartMenu.CheckoutButton();
        }
    }
}