using NUnit.Framework;

namespace PageObject.Tests
{
    public class CheckoutTest : BaseTest
    {
        //Enter all data correctly
        [Test]
        public void EnterValidDataOnCheckoutPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .CheckoutButton()
                .InsertData("Tanya", "borisenko", "123445")
                .IsPageOpened();
            
            Assert.IsTrue(result);
        }

        //Checking operation with empty slings
        [Test]
        public void EnterEmptyDataOnCheckoutPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .CheckoutButton()
                .InsertData(" ", "", "")
                .IsPageOpened();
            
            Assert.IsFalse(result);
            
        }

        //Click Cancel button
        [Test]
        public void ReturnToCartPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .CheckoutButton()
                .CancelButton()
                .IsPageOpened();
            
            Assert.IsTrue(result);
        }
    }
}