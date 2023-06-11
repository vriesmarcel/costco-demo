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

            var exitCode = Microsoft.Playwright.Program.Main(new[] { "install" });
            if (exitCode != 0)
            {
                Console.WriteLine("Failed to install browsers");
                Environment.Exit(exitCode);
            }
        }


        [TestMethod]
        public async Task SimpleTest()
        {
            var BuyticketResult = HomePage.GetHomePage(StartPage, true).Result
                .SelectTicket("John Egbert").Result
                .BuyTicket().Result
                .Checkout(new CustomerNico()).Result
                .IsOrderPlaced();
            Assert.IsTrue(await BuyticketResult);
        }
    }
}