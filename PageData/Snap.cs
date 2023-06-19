using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageData
{
    public class Snap
    {
        public static string CaptureScreen(IWebDriver driver, String filename)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;

            Screenshot ss = screenshot.GetScreenshot();

            string path = filename + DateTime.Now.ToString("yyyy-mm-hh_mm_ss");
            string filepath = @"C:\Users\AniruddhK\Desktop\.NetSeleniumFinal\Snaps\" + path + ".png";

            ss.SaveAsFile(filepath);

            return filepath;
        }
    }
}
