using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Pages
{
    class Home
    {
        IWebDriver driver;
        public Home(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickSignIn()
        {
       
            driver.FindElement(By.XPath("//a[@class='login']")).Click();

           
        }

        public void clickTshirtsTab()
        {
            driver.FindElement(By.XPath("//li[3]/a[@title='T-shirts']")).Click();
        }
       
    }
}
