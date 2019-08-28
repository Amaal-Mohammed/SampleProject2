using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Pages
{
    class Payout
    {
        IWebDriver driver;
        public Payout(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickProceed()
        {

            driver.FindElement(By.XPath("//div[3]/div[1]/p[2]/a[1]/span[1]")).Click();
            driver.FindElement(By.XPath("//button[@name='processAddress']/span[1]")).Click();

        }

        public void checkAggreementAndProceed()
        {
            driver.FindElement(By.XPath("//input[@id='cgv']")).Click();
            driver.FindElement(By.XPath("//button[@name='processCarrier']/span")).Click();

        }

        public void selectPaymentMethodAndConfirm()
        {
            driver.FindElement(By.XPath("//a[@class='bankwire']")).Click();
            driver.FindElement(By.XPath("//span[contains(text(),'I confirm my order')]")).Click();

        }

        public String getConfirmationMsg()
        {

            String text = driver.FindElement(By.XPath("//strong[contains(text(),'Your order on My Store is complete.')]")).Text;
            return text;
        }

    }
}
