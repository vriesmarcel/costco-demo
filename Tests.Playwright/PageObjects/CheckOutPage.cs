using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    public class CheckOutPage
    {
        private IPage page;

        public CheckOutPage(IPage playwright)
        {
            page = playwright;
        }

        public async Task<bool> IsOrderPlaced()
        {
            return await page.GetByRole(AriaRole.Heading, new() { Name = "Thank you for your order!" }).IsVisibleAsync();
        }
    }
}