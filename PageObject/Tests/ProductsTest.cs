using System.Linq;
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
                .GetSortedAtZaProductLabels().OrderByDescending(p => p);

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
            .GetSortedAtAzProductLabels().OrderBy(p => p);
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
                .GetSortedAtLtoHProductLabels().OrderBy(p => p);
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
                .GetSortedAtHtoLProductLabels().OrderByDescending(p => p);
            Assert.That(result, Is.Ordered.Descending);
        }
    }
}