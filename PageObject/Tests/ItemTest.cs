using NUnit.Framework;

namespace PageObject.Tests
{
    public class ItemTest : BaseTest
    {
        //Back to products menu
        [Test]
        public void AfterFinishBackToProductsMenu()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .AddProduct("Sauce Labs Backpack")
                .ClickCartButton()
                .CheckoutButton()
                .InsertData("Tanya", "borisenko", "123445")
                .WaitForPageOpened()
                .ClickFinishButton()
                .WaitForPageOpened()
                .ClickBackButton()
                .IsPageOpened();

            Assert.IsTrue(result);
        }
    }
}