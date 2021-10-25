using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;


namespace NUnitTest
{
    public class Tests
    {
        private IWebDriver driver;
        public  IWebElement search => driver.FindElement(By.CssSelector("input[type=text]"));
        public IWebElement button => driver.FindElement(By.CssSelector("input[type=submit]"));
        public IWebElement result => driver.FindElement(By.Id("result-stats"));

        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Test started");

            search.SendKeys("IT Craft");
            
            Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Console.WriteLine("Test started");
            search.SendKeys("IT Craft");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(button));
            button.Click();
            Assert.Pass();
        }
        [Test]
        public void Test3()
        {
            Console.WriteLine("Test started");
            search.SendKeys("IT Craft");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(button));
            button.Click();

            Assert.IsTrue(result.Displayed);
        }

        [TearDown]

        public void Quit()
        {
           driver.Quit();
        }
    }
}