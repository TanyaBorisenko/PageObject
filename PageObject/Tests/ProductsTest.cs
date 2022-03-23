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
            ProductsPage.GetSortedAtZaProductLabels();
            var product = ProductsPage.GetSortedAtZaProductLabels().OrderByDescending(p => p);
            Assert.That(product, Is.Ordered.Descending);

        }

        //Sorting products by the selection of sort from A to Z
        [Test]
        public void SortAtAzProductLabels()
        {
            ProductsPage.GetSortedAtAzProductLabels();
            var product = ProductsPage.GetSortedAtAzProductLabels().OrderBy(p => p);
            Assert.That(product, Is.Ordered);
        }

        //Soring products by the selection of sort from Low price to High 
        [Test]
        public void SortAtLtoHProductLabels()
        {
            ProductsPage.GetSortedAtLtoHProductLabels();
            var product = ProductsPage.GetSortedAtLtoHProductLabels().OrderBy(p => p);
            Assert.That(product, Is.Ordered);
            
        }

        // Sorting products by the selection of sort from High price to Low
        [Test]
        public void SortAtHtoLProductLabels()
        {
            ProductsPage.GetSortedAtHtoLProductLabels();
            var product = ProductsPage.GetSortedAtHtoLProductLabels().OrderByDescending(p => p);
            Assert.That(product, Is.Ordered.Descending);
        }
    }
}