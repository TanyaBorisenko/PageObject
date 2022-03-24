using NUnit.Framework;

namespace PageObject.Tests
{
    public class CartTest : BaseTest
    {
        [Test]
        public void AddProductIntoTheCart_IconCartShouldShowAddedProduct_OnTheProductPage()
        {
            var amount = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
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
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .RemoveProduct("Sauce Labs Backpack")
                .GetCartBadgeAmount();

            Assert.AreEqual(0, amount);
        }

        //Click "Continue" button
        [Test]
        public void CheckContinueShoppingButton()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .ContinueShopping()
                .IsPageOpened();

            Assert.IsTrue(result);
        }

        //Click "Checkout" button
        [Test]
        public void CheckCheckoutButton()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .CheckoutButton()
                .IsPageOpened();

            Assert.IsTrue(result);
        }
    }
}