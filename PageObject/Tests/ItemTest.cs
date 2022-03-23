using NUnit.Framework;

namespace PageObject.Tests
{
    public class ItemTest:BaseTest
    {
        //Back to products menu
        [Test]
        public void BackToProductsMenu()
        {
            ItemPage.ClickBackButton();
        }
    }
}