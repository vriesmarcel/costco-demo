using Microsoft.Playwright;
using Tests.Playwright.PageObjects;
using static System.Net.WebRequestMethods;

namespace Tests.Playwright
{
    [TestClass]
    public class SimpleTests
    {
        private TestContext _context;

        [TestMethod]
        public async Task SimpleTest()
        {
            var BuyticketResult = HomePage.GetHomePage("https://globoticket.azurewebsites.net/", false).Result
                .SelectTicket("John Egbert").Result
                .BuyTicket().Result
                .Checkout(new CustomerNico()).Result
                .IsOrderPlaced();
            Assert.IsTrue(await BuyticketResult);
        }
    }
}