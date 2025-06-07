using Microsoft.EntityFrameworkCore;
using THweb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace THweb.data
{
    public class CoffeShopDbcontext: IdentityDbContext
    {
       public CoffeShopDbcontext(DbContextOptions<CoffeShopDbcontext> options): base(options)
       {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ID = 1,
                Name = "America",
                Price = 25,
                Detail = "Name product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            },
            new Product
            {
                ID = 2,
                Name = "Vietnam",
                Price = 20,
                Detail = "Vietnamese product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            },
            new Product
            {
               ID = 3,
                Name = "United Kingdom",
                Price = 15,
                Detail = "UK product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            },
            new Product
            {
                ID = 4,
                Name = "India",
                Price = 15,
                Detail = "India product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            },
            new Product
            {
                ID = 5,
                Name = "Russian",
                Price = 25,
                Detail = "Russian product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            },  
            new Product
            {
                ID = 6,
                Name = "France",
                Price = 35,
                Detail = "France product",
                ImageUrl =
            "https://insanelygoodrecipes.com/wp-content/uploads/2020/07/Cup-Of-Creamy-Coffee-1024x536.webp"
            }
            );
        }
    }
}
