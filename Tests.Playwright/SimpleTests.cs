using Microsoft.Playwright;
using Tests.Playwright.PageObjects;
using static System.Net.WebRequestMethods;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        public TestContext TestContext;
        public string StartPage = "https://globoticket.azurewebsites.net";
        [TestInitialize]
        public void Initialize()
        {
            var homepage = System.Environment.GetEnvironmentVariable("HomePage");
            if(!string.IsNullOrWhiteSpace(homepage))
                StartPage = homepage.Trim();
        }


        [TestMethod]
        public async Task SimpleTest()
        {
            var BuyticketResult = HomePage.GetHomePage(StartPage, false).Result
                .SelectTicket("John Egbert").Result
                .BuyTicket().Result
                .Checkout(new CustomerNico()).Result
                .IsOrderPlaced();
            Assert.IsTrue(await BuyticketResult);
        }
    }
}