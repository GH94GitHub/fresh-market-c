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
            AddProducts(dbContext);
            AddUsers(dbContext);
        }

        private static void AddProducts(ApplicationDbContext db)
        {
            var product = db.products.FirstOrDefault();
            if (product is not null)
                return;

            db.AddRange(new Product[] 
                {
                    //todo: Find like Images of "market"
                    new Product(){
                        Name = "Orange",
                        Description = "Orange juicy fruit.",
                        ImgUrl = "#",
                        Price = .25
                    },
                    new Product(){
                        Name = "Strawberry",
                        Description = "Red fruit that has seeds on the skin.",
                        ImgUrl = "#",
                        Price = 0.29
                    },
                    new Product(){
                        Name = "Cantaloupe",
                        Description = "Cut it up and eat it!!",
                        ImgUrl = "#",
                        Price = 1.25
                    },
                    new Product(){
                        Name = "Avocado",
                        Description = "Green 'fruit' that has a huge seed in the middle.",
                        ImgUrl = "#",
                        Price = 0.25
                    },
                    new Product(){
                        Name = "Green Leaf Lettuce",
                        Description = "Make a salad",
                        ImgUrl = "#",
                        Price = .75
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
                new User() {
                    Username = "hotrod50000",
                    Password = "password",
                    FirstName = "Tony",
                    LastName = "Henderson",
                    Age = 28
                },
                new User() {
                    FirstName = "Kayla",
                    LastName = "Henderson",
                    Username = "kdawn",
                    Password = "password",
                    Age = 26
                },
                new User() {
                    FirstName = "Samuel",
                    LastName = "Henderson",
                    Username = "SammyBoy",
                    Password = "password",
                    Age = 1
                },
                new User() {
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
