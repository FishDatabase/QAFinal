using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTest;

[TestClass]
public class UnitTest1
{
    private static IWebDriver driver;
    private StringBuilder verificationErrors;
    private static string baseURL;
    private bool acceptNextAlert = true;

    [ClassInitialize]
    public static void InitializeClass(TestContext testContext)
    {
        driver = new ChromeDriver();
        baseURL = "https://www.google.com/";
    }

    [ClassCleanup]
    public static void CleanupClass()
    {
        try
        {
            //driver.Quit();// quit does not close the window
            driver.Close();
            driver.Dispose();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
    }

    [TestInitialize]
    public void InitializeTest()
    {
        verificationErrors = new StringBuilder();
    }

    [TestCleanup]
    public void CleanupTest()
    {
        Assert.AreEqual("", verificationErrors.ToString());
    }

    [TestMethod]
    public void SuccessfulLoginTest()
    {
        driver.Navigate().GoToUrl("https://letsusedata.com/index.html");
        driver.FindElement(By.Id("txtUser")).Click();
        driver.FindElement(By.Id("txtUser")).Clear();
        driver.FindElement(By.Id("txtUser")).SendKeys("test1");
        driver.FindElement(By.Id("txtPassword")).Click();
        driver.FindElement(By.Id("txtPassword")).Clear();
        driver.FindElement(By.Id("txtPassword")).SendKeys("Test123456");
        driver.FindElement(By.Id("javascriptLogin")).Click();
    }
    
    [TestMethod]
    public void UnsuccessfulLoginTest()
    {
        driver.Navigate().GoToUrl("https://letsusedata.com/index.html");
        driver.FindElement(By.Id("txtUser")).Click();
        driver.FindElement(By.Id("txtUser")).Clear();
        driver.FindElement(By.Id("txtUser")).SendKeys("test1");
        driver.FindElement(By.Id("txtPassword")).Click();
        driver.FindElement(By.Id("txtPassword")).Clear();
        driver.FindElement(By.Id("txtPassword")).SendKeys("test1234");
        driver.FindElement(By.Id("javascriptLogin")).Click();
    }

    private bool IsElementPresent(By by)
    {
        try
        {
            driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            string alertText = alert.Text;
            if (acceptNextAlert)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

            return alertText;
        }
        finally
        {
            acceptNextAlert = true;
        }
    }
}