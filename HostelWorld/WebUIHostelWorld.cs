using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Interactions;

namespace HostelWorld
{
    class WebUIHostelWorld
    {
        [Test]
        public void WebUItestingUsingSelenium()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var cityentered = config["CityEntered"];
            var hotelworldweburl = config["HotelWorldWebUrl"];

            string City;
            City = cityentered;

            IWebDriver driver = new ChromeDriver(System.AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(hotelworldweburl);
            Actions action = new Actions(driver);

            IWebElement searchText = driver.FindElement(By.Id("home-search-keywords"));
            searchText.SendKeys(City);
            Thread.Sleep(2000);

            IWebElement searchOverlay = driver.FindElement(By.XPath("//li[@class='hover']"));
            action.MoveToElement(searchOverlay).Click().Build().Perform();
            Thread.Sleep(2000);

            driver.FindElement(By.CssSelector(".submit-search-form")).Click();
            IWebElement Location = driver.FindElement(By.CssSelector(".input-location"));
           
            string cityname = Location.GetAttribute("value").ToUpper();
            Console.WriteLine(cityname + " | " + City.ToUpper());
            Assert.IsTrue(cityname.Contains(City.ToUpper()), cityname + " Doesn't contains "+ cityentered);

            driver.Quit();
        }
    }
}
