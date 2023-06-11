using Microsoft.Playwright;
using System.Xml.Linq;

namespace Tests.Playwright.PageObjects
{
    internal class HomePage
    {
        IPage page;
        IPlaywright playwright;
        IBrowser browser;
        public static async Task<HomePage> GetHomePage(string homepageurl, bool headless=true)
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = headless
            });

            var page = await browser.NewPageAsync();
            await page.GotoAsync(homepageurl);
            return new HomePage(playwright,browser, page);
        }

        protected HomePage(IPlaywright playwright,IBrowser browser,  IPage page ) {
           
            this.playwright = playwright;
            this.browser = browser;
            this.page = page;
        }
        public async Task<TicketDetailPage> SelectTicket(string concertName)
        {
            var element = page.GetByRole(AriaRole.Row)
                .Filter(new() { HasText = concertName });
            await element.GetByRole(AriaRole.Cell, new() { Name = "PURCHASE DETAILS" }).ClickAsync();

            return new TicketDetailPage(page);
        }
    }
}