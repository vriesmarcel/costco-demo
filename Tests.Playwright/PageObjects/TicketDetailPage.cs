using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    internal class TicketDetailPage
    {
        IPage page;
        internal TicketDetailPage(IPage page)
        {
            this.page = page;
        }

        public async Task<ShopingBasket> BuyTicket()
        {
            var element = page.GetByRole(AriaRole.Button, new() { Name = "PLACE ORDER" });
            await element.ClickAsync();

            element = page.GetByRole(AriaRole.Link, new() { Name = "CHECKOUT" });
            await element.ClickAsync();
            return new ShopingBasket(page);
        }
    }
}