using FreshMarket.Models;

namespace FreshMarket.Data
{
    public static class DataSeeder
    {

        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            if (dbContext == null) return;
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            //AddProducts(dbContext); todo
            AddUsers(dbContext);
        }

        private static void AddProducts(ApplicationDbContext db)
        {
            var product = db.products.FirstOrDefault();
            if (product is not null)
                return;

            db.AddRange(new Product[] 
                {
                    //todo: Find like Images of "market" products and implement their info
                    new(){
                        Name = "",
                        Description = "",
                        ImgUrl = "",
                        Price = 0.50
                    },
                    new(){
                        Name = "",
                        Description = "",
                        ImgUrl = "",
                        Price = 0.50
                    },
                    new(){
                        Name = "",
                        Description = "",
                        ImgUrl = "",
                        Price = 0.50
                    },
                    new(){
                        Name = "",
                        Description = "",
                        ImgUrl = "",
                        Price = 0.50
                    },
                    new(){
                        Name = "",
                        Description = "",
                        ImgUrl = "",
                        Price = 0.50
                    },
            });

            db.SaveChanges();
        }

        private static void AddUsers(ApplicationDbContext db)
        {
            var user = db.users.FirstOrDefault();
            if (user is not null)
                return;

            db.AddRange(new User[]
            {
                new() {
                    Username = "hotrod50000",
                    Password = "password",
                    FirstName = "Tony",
                    LastName = "Henderson",
                    Age = 28
                },
                new() {
                    FirstName = "Kayla",
                    LastName = "Henderson",
                    Username = "kdawn",
                    Password = "password",
                    Age = 26
                },
                new() {
                    FirstName = "Samuel",
                    LastName = "Henderson",
                    Username = "SammyBoy",
                    Password = "password",
                    Age = 1
                },
                new() {
                    FirstName = "Avery",
                    LastName = "Henderson",
                    Username = "AHend",
                    Password = "password",
                    Age = 2
                },
            });

            db.SaveChanges();
        }
    }
}
