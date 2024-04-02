using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GBC_Travel_Group_77.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IShoppingCart _shoppingCart;

        public CheckoutPageModel(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public void OnGet()
        {
        }
    }
}
