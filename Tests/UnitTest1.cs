using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using PageData;

namespace Tests
{
    public class Tests
    {
        IWebDriver driver;
        ExtentV3HtmlReporter htmlReporter;
        ExtentReports reports;
        ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {

            var filename = this.GetType().ToString() + ".html";
            htmlReporter = new ExtentV3HtmlReporter(@"C:\Users\AniruddhK\Desktop\.NetSeleniumFinal\Snaps\" + filename);

            reports = new ExtentReports();
            reports.AttachReporter(htmlReporter);

            new DriverManager().SetUpDriver(new ChromeConfig());

            Debug.WriteLine("OneTimeSetup Called");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            reports.Flush();
            Debug.WriteLine("OneTimeTearDown Called");
        }

        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();

            test = reports.CreateTest(TestContext.CurrentContext.Test.Name);

            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.openmrs.org/openmrs/";

            test.Log(Status.Info, "Test Started");
        }




        [TearDown]
        public void TearDown()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshot = Snap.CaptureScreen(driver, "errorScreenshot");
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot" + test.AddScreenCaptureFromPath(screenshot));

            }

            driver.Close();
            test.Log(Status.Info, "Test Completed");
            Console.WriteLine("TearDown Called");

        }


        [TestCaseSource(typeof(TestSource), "ReadLoginData")]
        [Order(1)]
        public void SamplePageTest(string username, string password)
        {
            LoginPage page = new LoginPage(driver);
            page.SubmitLoginData(username, password);
            test.Pass("Login Complete");
            var url = driver.Url;
            Assert.IsTrue(url.Contains("https://demo.openmrs.org/openmrs/referenceapplication/home.page"));
            test.Pass("Login Verified");
            Thread.Sleep(2000);

        }
        [TestCaseSource(typeof(TestSource), "ReadLoginData")]
        [Order(2)]
        public void Logoutpage(string username, string password)
        {
            LoginPage page = new LoginPage(driver);
            page.SubmitLoginData(username, password);
            test.Pass("Login Success");
            LogoutPage page1 = new PageData.LogoutPage(driver);
            page1.SubmitLogoutData(username, password);
            test.Pass("LogOut Success");
            Thread.Sleep(2000);
        }

        [TestCaseSource(typeof(TestSource), "ReadErrorLoginData")]
        [Order(3)]
        public void ErrorTest(string username, string password, string message)
        {
            ErrorPage page2 = new ErrorPage(driver);
            page2.ErrorData(username, password, message);
            Assert.IsTrue(page2.VerifyUrl(message));
            test.Pass("Login invalid");
            Snap.CaptureScreen(driver, "Test");
            Thread.Sleep(2000);

        }


        [TestCaseSource(typeof(TestSource), "ExcelResData")]
        [Category("ExternalDataTest")]
        [Order(4)]
        public void RegisterData(string username, string password, string N1, string N2, string N3, string G, string D, string M, string Y,
            string A1, string A2, string C, string S, string CO, string P, string PH, string R, string PR)
        {
            LoginPage page = new LoginPage(driver);
            page.SubmitLoginData(username, password);
            Thread.Sleep(2000);
            Registerpage page3 = new Registerpage(driver);
            page3.SubmitResData(N1, N2, N3, G, D, M, Y, A1, A2, C, S, CO, P, PH, R, PR);

        }

        [TestCaseSource(typeof(TestSource), "ReadName")]
        [Order(5)]
        public void SearchPatient(String username, String password, string Name)
        {
            LoginPage page = new LoginPage(driver);
            page.SubmitLoginData(username, password);
            Thread.Sleep(2000);
            SearchName page2 = new SearchName(driver);
            page2.SubmitName(Name);
            Thread.Sleep(3000);
        }
        [TestCaseSource(typeof(TestSource), "ReadId")]
        [Order(6)]
        public void SearchPatient1(String username, String password, string Id)
        {
            LoginPage page = new LoginPage(driver);
            page.SubmitLoginData(username, password);
            Thread.Sleep(2000);
            SearchId page2 = new SearchId(driver);
            page2.SubmitId(Id);
            Thread.Sleep(2000);
        }
    }
}