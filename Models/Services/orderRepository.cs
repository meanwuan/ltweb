using THweb.data;
using THweb.Models.Services;
using THweb.Models.Interfaces;

namespace THweb.Models.Services
{
    public class orderRepository : IorderRespository
    {
        private CoffeShopDbcontext dbcontext;
        private ShoppingCartRepository shoppingCartRepository;
        public orderRepository(CoffeShopDbcontext dbcontext, ShoppingCartRepository shoppingCartRepository)
        {
            this.dbcontext = dbcontext;
            this.shoppingCartRepository = shoppingCartRepository;
        }
        public void placeOrder(order order)
        {
            var shoppingCartItems = shoppingCartRepository.GetAllShoppingCartItems();
            order.orderdetails = new List<Orderdetail>();
            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new Orderdetail
                {
                    quantity = item.Quantity,
                    productId = item.Product.ID,
                    price = item.Product.Price,
                };
                order.orderdetails.Add(orderDetail);
            }
            order.createdAt = DateTime.Now;
            order.total = shoppingCartRepository.GetShoppingCartTotal();
            dbcontext.orders.Add(order);
            dbcontext.SaveChanges();
        }
    }
}
