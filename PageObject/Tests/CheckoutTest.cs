using NUnit.Framework;

namespace PageObject.Tests
{
    public class CheckoutTest : BaseTest
    {
        //Enter all data correctly
        [Test]
        public void EnterValidData()
        {
            CheckoutPage.InsertData("Tanya", "borisenko", "123445");
        }

        //Checking operation with empty slings
        [Test]
        public void EmptyData()
        {
            CheckoutPage.InsertData(" ", "", "");
        }

        //Click Cancel button
        [Test]
        public void ReturnToProductPage()
        {
            CheckoutPage.CancelButton();
        }
    }
}