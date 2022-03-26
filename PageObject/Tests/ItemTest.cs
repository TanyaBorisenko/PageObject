﻿using NUnit.Framework;

namespace PageObject.Tests
{
    public class ItemTest : BaseTest
    {
        // CheckProductDescription
        [Test]
        public void CheckProductDescriptionIsDisplayed()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .ClickOnImg("Sauce Labs Backpack")
                .WaitForPageOpened()
                .GetItem()
                .ClickBackButton()
                .IsPageOpened();

            Assert.IsTrue(result);
        }
    }
}