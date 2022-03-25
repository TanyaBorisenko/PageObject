using NUnit.Framework;

namespace PageObject.Tests
{
    public class MenuTest : BaseTest
    {
        //Click "Close" button 
        [Test]
        public void OpenAndCloseMenuPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .ClickMenuButton()
                .WaitForPageOpened()
                .CloseButton()
                .IsPageOpened();

            Assert.IsTrue(result);
        }

        //Check Logout Button
        [Test]
        public void ClickLogoutButtonOnMenuPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .ClickMenuButton()
                .WaitForPageOpened()
                .LogOutButton()
                .IsPageOpened();

            Assert.IsTrue(result);
        }
    }
}