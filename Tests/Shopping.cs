using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Firefox;
using Sparkassignment.Testdata;
using NUnit.Framework.Interfaces;
using Sparkassignment.Helpers;

namespace Sparkassignment.Pages
{

    [TestFixture]
    [Parallelizable]
    class Shopping: Helpers.TestBase
    {
        ExtentHtmlReporter r1;
        AventStack.ExtentReports.ExtentReports extent;
        ExtentTest test;
 
        [OneTimeSetUp]
        public void setReports()
        {
            String driverpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            r1 = new ExtentHtmlReporter(driverpath + "\\" + "testresults.html");
            extent = new ExtentReports();
            extent.AttachReporter(r1);
            extent.AddSystemInfo("Opering System", "Windows 10");
            ReadData.setData(driverpath);
        }
        
        [Test, Order(1)]
        [Parallelizable]
        [TestCaseSource(typeof(TestBase),"browsertorun")]
        public void shoppingMethod(String browser)
        {
            setUp(browser);
            driver.Url = Constants.URL;
            test = extent.CreateTest("shoppingMethod");
            //Create Objects from classes Home and Sign In and Pass the driver to it
            Home h1 = new Home(driver);
            SignIn s1 = new SignIn(driver);
            h1.clickSignIn();
            test.Log(Status.Info, "Click Sign in");
            s1.createAccount();
            s1.clickCreateAccount();
            Register r1 = new Register(driver);
            r1.insertCustomerName(ReadData.Customerfirstname, ReadData.Customerlastname);
            r1.insertPassword(ReadData.Password);
            r1.insertBirthday();
            r1.insertName(ReadData.FirstName, ReadData.LastName);
            r1.insertCompany(ReadData.Company);
            r1.insertAddress(ReadData.Address, ReadData.City, ReadData.State);
            r1.insertPostal(ReadData.Postal);
            r1.insertPhoneAndMobile(ReadData.Phone, ReadData.Mobile);
            r1.clickRegister();
            test.Log(Status.Info, "Register New User");
            h1.clickTshirtsTab();
            ProductSelection pselect = new ProductSelection(driver);
            pselect.selectProduct(ReadData.Shirt);
            pselect.clickAddToCart();
            test.Log(Status.Info, "Select a Product and add to Cart");
            pselect.clickProceedToCheckout();
            Payout pay = new Payout(driver);
            pay.clickProceed();
            pay.checkAggreementAndProceed();
            pay.selectPaymentMethodAndConfirm();
            test.Log(Status.Info, "Order Product");     
            String msg = pay.getConfirmationMsg();
            Verifications.VerifyShopping.Verifytxt(msg);
        }
        [TearDown]
        public void DerivedTearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                   ? ""
                   : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        }
        [OneTimeTearDown]
        public void endTest()
        {
            extent.Flush();
        }
    }
}
