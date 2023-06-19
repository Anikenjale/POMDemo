using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageData
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //login Elements
        IWebElement Username => driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div/form/fieldset/p[1]/input"));
        IWebElement Password => driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div/form/fieldset/p[2]/input"));
        IWebElement Session => driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div/form/fieldset/ul/li[1]"));
        IWebElement Login => driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div/form/fieldset/p[6]/input"));

        public void SubmitLoginData(String username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
            Session.Click();
            Login.Click();

        }
}
}
