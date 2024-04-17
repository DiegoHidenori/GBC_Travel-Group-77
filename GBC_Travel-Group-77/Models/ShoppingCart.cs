using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace GBC_Travel_Group_77.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;
        public string? ShoppingCartId { get; set; }

        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            try
            {
                ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
                AppDbContext context = services.GetService<AppDbContext>() ?? throw new Exception("Error initializing");
                string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
                session?.SetString("CartId", cartId);

                return new ShoppingCart(context) { ShoppingCartId = cartId };
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }
        }

        public void ClearCart()
        {
            try
            {
                ShoppingCartItems?.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Error clearing the cart: ", ex);
            }
        }

        public void AddToCart(int id, int number, string type)
        {
            try
            {
                var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.itemId == id && s.type == type && s.shoppingCartId == ShoppingCartId);

                if (shoppingCartItem == null)
                {
                    shoppingCartItem = new ShoppingCartItem
                    {
                        itemId = id,
                        type = type,
                        number = number,
                        shoppingCartId = ShoppingCartId
                    };
                    _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
                }
                else
                {
                    shoppingCartItem.number += number;
                }
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding item to cart: ", ex);
            }
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            try
            {
                return ShoppingCartItems ??= _appDbContext.ShoppingCartItems.Where(
                c => c.shoppingCartId == ShoppingCartId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the shopping cart items: ", ex);
            }
        }
    }
}
