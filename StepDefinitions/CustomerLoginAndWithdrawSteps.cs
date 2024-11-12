using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PageObject;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;

namespace Lab2.StepDefinitions
{
    [Binding]
    public sealed class CustomerLoginAndWithdrawSteps : BaseSteps
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private AccountPage accountPage;

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            driver = new ChromeDriver("D:\\chromedriver.exe");
            driver.Navigate().GoToUrl("https://www.globalsqa.com/angularJs-protractor/BankingProject");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("button[ng-click='customer()']")).Displayed);
            homePage = new HomePage(driver);
        }

        [When(@"I log in as ""([^""]*)""")]
        public void WhenILogInAs(string customerName)
        {
            loginPage = homePage.ClickLoginButton();

            loginPage.SelectCustomerName(customerName);

            accountPage = loginPage.ClickLoginButton();
        }

        [When(@"I withdraw ""([^""]*)""")]
        public void WhenIWithdraw(string amount)
        {
            accountPage.PerformWithdraw(amount);
        }

        [Then(@"I should see a success message ""(.*)""")]
        public void ThenIShouldSeeASuccessMessage(string expectedMessage)
        {
            accountPage.VerifyTransactionMessage(expectedMessage);
        }
    }
}