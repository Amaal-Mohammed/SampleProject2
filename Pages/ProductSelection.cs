using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Pages
{
    class ProductSelection
    {
        IWebDriver driver;
        public ProductSelection(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void selectProduct(String shirt)
        {
            try
            {
                TimeSpan span1 = new TimeSpan(0, 0, 0, 20, 500);
                WebDriverWait wait1 = new WebDriverWait(driver, span1);
                wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='product-name']")));

                ReadOnlyCollection<IWebElement> L1 = driver.FindElements(By.XPath("//a[@class='product-name']"));

                foreach (IWebElement e in L1)
                {
                    if (e.Text.Equals(shirt))
                    {
                        e.Click();
                    }
                }
            }
            catch (Exception e)
            {
                //ignore exception
            }
        }

        public void clickAddToCart()
        {

            driver.FindElement(By.XPath("//span[contains(text(),'Add to cart')]")).Click();

        }

        public void clickProceedToCheckout()
        {
            TimeSpan span2 = new TimeSpan(0, 0, 0, 20, 500);
            WebDriverWait wait2 = new WebDriverWait(driver, span2);
            wait2.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Proceed to checkout')]")));
            driver.FindElement(By.XPath("//span[contains(text(),'Proceed to checkout')]")).Click();


        }





    }
}
