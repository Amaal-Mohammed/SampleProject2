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
    class Register
    {
        IWebDriver driver;
        public Register(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void insertCustomerName(String cfname,String clname)
        {
            TimeSpan span1 = new TimeSpan(0, 0, 0, 20, 500);
            WebDriverWait wait1 = new WebDriverWait(driver, span1);
            wait1.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='customer_firstname']")));

            driver.FindElement(By.XPath("//input[@id='customer_firstname']")).SendKeys(cfname);
            driver.FindElement(By.Id("customer_lastname")).SendKeys(clname);
        }

      
        public void insertPassword(String pwd)
        {
            driver.FindElement(By.Id("passwd")).SendKeys(pwd);
        }

        public void insertBirthday()
        {
            SelectElement sday = new SelectElement(driver.FindElement(By.Id("days")));
            sday.SelectByValue("15");
            SelectElement smonths = new SelectElement(driver.FindElement(By.Id("months")));
            smonths.SelectByValue("11");

            SelectElement syear = new SelectElement(driver.FindElement(By.Id("years")));
            syear.SelectByValue("1988");

        }

        public void insertName(String fname ,String lname)
        {
            driver.FindElement(By.Id("firstname")).SendKeys(fname);
            driver.FindElement(By.Id("lastname")).SendKeys(lname);
        }

        public void insertCompany(String comp)
        {
            driver.FindElement(By.Id("company")).SendKeys(comp);
        }
       
        public void insertAddress(String address, String city, String state)
        {
            driver.FindElement(By.XPath("//input[@id='address1']")).SendKeys(address);
            driver.FindElement(By.Id("city")).SendKeys(city);
            SelectElement sstate = new SelectElement(driver.FindElement(By.Id("id_state")));
            sstate.SelectByValue(state);

        }
        public void insertPostal(String postal)
        {
            driver.FindElement(By.XPath("//input[@id='postcode']")).SendKeys(postal);

        }
        public void insertPhoneAndMobile(String phone,String mobile)
        {
            driver.FindElement(By.Id("phone")).SendKeys(phone);
            driver.FindElement(By.Id("phone_mobile")).SendKeys(mobile);
        }

        public void clickRegister()
        {
            driver.FindElement(By.Id("submitAccount")).Click();
        }
        


    }
}
