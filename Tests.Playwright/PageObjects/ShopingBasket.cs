using Microsoft.Playwright;

namespace Tests.Playwright.PageObjects
{
    internal class ShopingBasket
    {
        private IPage page;

        public ShopingBasket(IPage playwright)
        {
            page = playwright;
        }

        public async Task<CheckOutPage> Checkout(CustomerNico customer)
        {
            await page.Locator("id=Name").FillAsync(customer.name);
            await page.Locator("id=Address").FillAsync(customer.street);
            await page.Locator("id=Town").FillAsync(customer.town);
            await page.Locator("id=PostalCode").FillAsync(customer.postalcode);
            await page.Locator("id=CreditCardDate").FillAsync(customer.expdate);
            await page.Locator("id=Email").FillAsync(customer.email);
            await page.Locator("id=CreditCard").FillAsync(customer.cc);

            var button = page.GetByRole(AriaRole.Button, new() { Name = "SUBMIT ORDER" });
            await button.ClickAsync();
            return new CheckOutPage(page);
        }
    }
}