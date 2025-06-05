using THweb.data;
using THweb.Models.Interfaces;
using THweb.data;
using Microsoft.EntityFrameworkCore;

namespace THweb.Models.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private CoffeShopDbcontext dbcontext;
        public ShoppingCartRepository(CoffeShopDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public string? ShoppingCartId { get; set; }
        public static ShoppingCartRepository GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            CoffeShopDbcontext context = services.GetService<CoffeShopDbcontext>() ?? throw new Exception("Error initializing coffeeshopdbcontext");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            session?.SetString("CartId", cartId);
            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };
        }
        public void AddToCart(Product product)
        {
            var shoppingcartItem = dbcontext.ShoppingCartItems.FirstOrDefault(c => c.Product.ID == product.ID && c.ShoppingCartId == ShoppingCartId);
            if (shoppingcartItem == null)
            {
                shoppingcartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1,
                };
                dbcontext.ShoppingCartItems.Add(shoppingcartItem);
            }
            else
            { 
                shoppingcartItem.Quantity++; 
            }
            dbcontext.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = dbcontext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).ToList();
            dbcontext.ShoppingCartItems.RemoveRange(cartItems);
            dbcontext.SaveChanges();
        }

        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return ShoppingCartItems ??= dbcontext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(p=> p.Product).ToList();

        }

        public decimal GetShoppingCartTotal()
        {
            var total = dbcontext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Product.Price * c.Quantity).Sum();
            return total;
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem = dbcontext.ShoppingCartItems.FirstOrDefault(s =>s.Product.ID == product.ID && s.ShoppingCartId == ShoppingCartId);
            var quantity = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    quantity = shoppingCartItem.Quantity;
                }
                else
                {
                    dbcontext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            dbcontext.SaveChanges();
            return quantity;
        }
        
    }
}
