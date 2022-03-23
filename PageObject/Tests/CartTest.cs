using NUnit.Framework;

namespace PageObject.Tests
{
    public class CartTest : BaseTest
    {
        //Add product into the cart
        [Test]
        public void AddProductIntoTheCart()
        {
            ProductsPage.AddProduct("Sauce Labs Backpack");
        }

        //Remove product from the cart
        [Test]
        public void RemoveProductFromCart()
        {
            ProductsPage.RemoveProduct("Sauce Labs Backpack");
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