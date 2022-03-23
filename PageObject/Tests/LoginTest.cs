using NUnit.Framework;

namespace PageObject.Tests
{
    public class LoginTest : BaseTest
    {
        //Login in app
        [Test]
        public void OpenProductsPage()
        {
            LoginPage.ClickSingInButton(UserName, Password);
        }

        //Fail login
        [Test]
        public void EnterErrorPassword()
        {
            LoginPage.ClickSingInButton(UserName, " ghypo ");
        }
    }
}