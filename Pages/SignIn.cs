using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Pages
{
    class SignIn
    {
        IWebDriver driver;
        public SignIn(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void createAccount()
        {
            String email = Helpers.Helpers.generateEmail();
            TimeSpan span = new TimeSpan(0, 0, 0, 20, 500);
            WebDriverWait wait = new WebDriverWait(driver, span);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email_create")));

            driver.FindElement(By.Id("email_create")).SendKeys(email);
        }

        public void clickCreateAccount()
        {
            driver.FindElement(By.Id("SubmitCreate")).Click();
        }
    }
}
