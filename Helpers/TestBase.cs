using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sparkassignment.Helpers
{
    class TestBase
    {
     protected   IWebDriver driver;
        ChromeOptions options;
        public void setUp(String browsername)
        {
            if (browsername == "Chrome")
            {
                options = new ChromeOptions();
                String driverpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                options.AddArguments("--disable-notifications");
                options.AddArgument("no-sandbox");
                options.AddArgument("--incognito");
                TimeSpan T1 = new TimeSpan(0, 0, 30);
                driver = new ChromeDriver(driverpath, options, T1);
            }
            else if (browsername == "Firefox")
            {
                String driverpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                String FFpath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Mozilla Firefox\firefox.exe";

                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverpath);

                service.FirefoxBinaryPath = FFpath;
                driver = new FirefoxDriver(service);
            }
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Window.Maximize();

        }

        public static IEnumerable<String> browsertorun()
        {
            String[] browsers = { "Chrome", "Firefox" };

            foreach (String b in browsers)
            {
                yield return b;

            }
        }

    }
}
