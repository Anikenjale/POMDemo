using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageData
{
    public class LogoutPage
    {
        IWebDriver driver;

        public LogoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //login Elements
        IWebElement Logout => driver.FindElement(By.XPath("/html/body/header/nav/div[2]/ul/li[3]/a"));

        public void SubmitLogoutData(String username, string password)
        {
            Logout.Click();

        }
    }
}
