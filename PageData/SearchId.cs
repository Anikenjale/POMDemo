using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageData
{

    public class SearchId
    {
        IWebDriver driver;

        public SearchId(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement search => driver.FindElement(By.XPath("/html/body/div/div[3]/div[3]/div/a[1]"));
        IWebElement id => driver.FindElement(By.XPath("/html/body/div/div[3]/div[1]/div/form/input"));


        public void SubmitId(String Id)
        {
            search.Click();
            id.SendKeys(Id);

        }
    }

}
