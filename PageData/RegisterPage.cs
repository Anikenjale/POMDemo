using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace PageData
{
    public class Registerpage
    {
        IWebDriver driver;

        public Registerpage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Locating Elements
        IWebElement reg => driver.FindElement(By.XPath("//a[@href='/openmrs/registrationapp/registerPatient.page?appId=referenceapplication.registrationapp.registerPatient']"));
        IWebElement name => driver.FindElement(By.XPath("//input[@name='givenName']"));
        IWebElement middle_name => driver.FindElement(By.XPath("//input[@name='middleName']"));
        IWebElement surname => driver.FindElement(By.XPath("//input[@name='familyName']"));
        IWebElement nextbtn => driver.FindElement(By.XPath("//button[@id='next-button']"));
        IWebElement gender => driver.FindElement(By.XPath("//select[@name='gender']"));
        IWebElement day => driver.FindElement(By.XPath("//input[@name='birthdateDay']"));
        IWebElement month => driver.FindElement(By.XPath("//select[@name='birthdateMonth']"));
        IWebElement year => driver.FindElement(By.XPath("//input[@name='birthdateYear']"));
        IWebElement add1 => driver.FindElement(By.XPath("//input[@name='address1']"));
        IWebElement add2 => driver.FindElement(By.XPath("//input[@name='address2']"));
        IWebElement city => driver.FindElement(By.XPath("//input[@name='cityVillage']"));
        IWebElement state => driver.FindElement(By.XPath("//input[@name='stateProvince']"));
        IWebElement country => driver.FindElement(By.XPath("//input[@name='country']"));
        IWebElement postcode => driver.FindElement(By.XPath("//input[@name='postalCode']"));
        IWebElement phoneno => driver.FindElement(By.XPath("//input[@name='phoneNumber']"));
        IWebElement relationship => driver.FindElement(By.XPath("//select[@name='relationship_type']"));
        IWebElement relative_name => driver.FindElement(By.XPath("//body/div[@id='body-wrapper']/div[@id='content']/form[@id='registration']/section[@id='relationships-info']/div[1]/fieldset[1]/div[1]/div[1]/p[2]/input[1]"));
        IWebElement confirmbtn => driver.FindElement(By.XPath("//input[@type='submit']"));





        public object PageFactory { get; }

        public void SubmitResData(string N1, string N2, string N3, string G, string D, string M, string Y,
            string A1, string A2, string C, string S, string CO, string P, string PH, string R, string PR)
        {
            reg.Click();
            name.SendKeys(N1);
            middle_name.SendKeys(N2);
            surname.SendKeys(N3);
            Thread.Sleep(1000);
            nextbtn.Click();
            new SelectElement(gender).SelectByValue(G);
            Thread.Sleep(1000);
            nextbtn.Click();
            day.SendKeys(D);
            month.SendKeys(M);
            year.SendKeys(Y);
            Thread.Sleep(1000);
            nextbtn.Click();
            add1.SendKeys(A1);
            add2.SendKeys(A2);
            city.SendKeys(C);
            state.SendKeys(S);
            country.SendKeys(CO);
            postcode.SendKeys(P);
            Thread.Sleep(1000);
            nextbtn.Click();
            phoneno.SendKeys(PH);
            Thread.Sleep(1000);
            nextbtn.Click();
            relationship.SendKeys(R);
            relationship.SendKeys(Keys.Tab);
            relative_name.SendKeys(PR);
            Thread.Sleep(1000);
            nextbtn.Click();
            confirmbtn.Click();

        }
    }

}
