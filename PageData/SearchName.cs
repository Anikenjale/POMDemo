using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageData
{
    public class SearchName
    {
        IWebDriver driver;

        public SearchName(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement search => driver.FindElement(By.XPath("/html/body/div/div[3]/div[3]/div/a[1]"));
        IWebElement name => driver.FindElement(By.XPath("/html/body/div/div[3]/div[1]/div/form/input"));


        public void SubmitName(String Name)
        {
            search.Click();
            name.SendKeys(Name);

        }
    }
}
