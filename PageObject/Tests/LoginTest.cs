using NUnit.Framework;

namespace PageObject.Tests
{
    public class LoginTest : BaseTest
    {
        //Login in app
        [Test]
        public void LoginAndOpenProductsPage()
        {
            var result = LoginPage
                .OpenPage()
                .LoginInApp(UserName, Password)
                .WaitForPageOpened()
                .IsPageOpened();
            
            Assert.IsTrue(result);

        }

        //Fail login
        [Test]
        public void Login_EnterErrorPassword()
        {
            var result = LoginPage
            .OpenPage()
                .LoginInApp(UserName, " privet")
            .WaitForPageOpened()
                .IsPageOpened();
            
            Assert.IsFalse(result);
        }
    }
}