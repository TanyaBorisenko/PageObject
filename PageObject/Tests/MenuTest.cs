using NUnit.Framework;

namespace PageObject.Tests
{
    public class MenuTest:BaseTest
    {
        //Click "Close" button 
        [Test]
        public void CloseMenu()
        {
            MenuButton.CloseButton();
        }
        //Check Logout Button
        [Test]
        public void ClickLogoutButton()
        {
            MenuButton.LogOutButton();
        }
    }
}