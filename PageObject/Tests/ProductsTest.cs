using NUnit.Framework;

namespace PageObject.Tests
{
    public class ProductsTest : BaseTest

    {
        //Sorting products by the selection of sort from Z to A
        [Test]
        public void SortAtZaProductLabels()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .GetSortedAtZaProductLabels();

            Assert.That(result, Is.Ordered.Descending);
        }

        //Sorting products by the selection of sort from A to Z
        [Test]
        public void SortAtAzProductLabels()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .GetSortedAtAzProductLabels();
            Assert.That(result, Is.Ordered);
        }

        //Soring products by the selection of sort from Low price to High 
        [Test]
        public void SortAtLtoHProductLabels()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .GetSortedAtLtoHProductLabels();
            Assert.That(result, Is.Ordered);
        }

        // Sorting products by the selection of sort from High price to Low
        [Test]
        public void SortAtHtoLProductLabels()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .GetSortedAtHtoLProductLabels();
            Assert.That(result, Is.Ordered.Descending);
        }
    }
}