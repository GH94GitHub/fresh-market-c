using System.Globalization;
using FreshMarket.Models;
using Microsoft.IdentityModel.Tokens;

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
            AddAllergies(dbContext);
            AddTiers(dbContext);

            AddDishes(dbContext);
            AddUsers(dbContext);
        }

        private static void AddAllergies(ApplicationDbContext db)
        {
            var allergy = db.allergies.FirstOrDefault();
            if (allergy != null)
                return;

            db.allergies.Add(new Allergy()
            {
                Name = "Citrus"
            });

            db.allergies.Add(new Allergy()
            {
                Name = "Fruit"
            });
            
            
            db.allergies.Add(new Allergy()
            {
                Name = "Avocado"
            });

            db.SaveChanges();
        }

        private static void AddDishes(ApplicationDbContext db)
        {
            var dish = db.dishes.FirstOrDefault();
            if (dish is not null)
                return;

            db.AddRange(new Dish[] 
                {
                    new Dish(){
                        Name = "Orange",
                        Description = "Orange juicy fruit.",
                        ImgUrl = "#",
                        CalorieAmount = 100,
                        Allergies =
                        {
                            db.allergies.First(allergy => allergy.Name.ToLower() == "citrus")
                        }
                    },
                    new Dish(){
                        Name = "Strawberry",
                        Description = "Red fruit that has seeds on the skin.",
                        ImgUrl = "#",
                        CalorieAmount = 200,
                        Allergies =
                        {
                            db.allergies.First(allergy => allergy.Name.ToLower() == "fruit")
                        }
                    },
                    new Dish(){
                        Name = "Cantaloupe",
                        Description = "Cut it up and eat it!!",
                        ImgUrl = "#",
                        CalorieAmount = 300,
                        Allergies =
                        {
                            db.allergies.First(allergy => allergy.Name.ToLower() == "fruit")
                        }
                    },
                    new Dish(){
                        Name = "Avocado",
                        Description = "Green 'fruit' that has a huge seed in the middle.",
                        ImgUrl = "#",
                        CalorieAmount = 400,
                        Allergies =
                        {
                            db.allergies.First(allergy => allergy.Name.ToLower() == "avocado")
                        }
                    },
                    new Dish(){
                        Name = "Green Leaf Lettuce",
                        Description = "Make a salad",
                        ImgUrl = "#",
                        CalorieAmount = 500
                    },
                    new Dish(){
                        Name = "Banana",
                        Description = "Fruit monkeys love!!",
                        ImgUrl = "#",
                        CalorieAmount = 90
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
                    Email = "th_rams94@hotmail.com",
                    Password = "password",
                    FirstName = "Tony",
                    LastName = "Henderson",
                    Address = "123 Jaime Dr",
                    Allergies = new List<Allergy>()
                    {
                        db.allergies.FirstOrDefault(allergy => allergy.Name == "Peanut") ?? new Allergy()
                        {
                            Name = "Peanut"
                        }
                    },
                    DishPreferences = new List<Dish>()
                    {
                        db.dishes.First(dish => dish.Name.ToLower() == "cantaloupe"),
                        db.dishes.First(dish => dish.Name.ToLower() == "avocado"),
                        db.dishes.First(dish => dish.Name.ToLower() == "strawberry"),
                    },
                    Payment = new Payment()
                    {
                        CardNumber = "123456789",
                        CvcNumber = "123",
                        ExpirationDate = new DateTime(2023, 6, 9).ToUniversalTime(),
                        NameOnCard = "Tony Henderson",
                        Nickname = "My Credit Card",
                        ZipCode = "65656"
                    },
                    PhoneNumber = "4020229898"
                },
                new User() {
                    Email = "kayladawn@gmail.com",
                    FirstName = "Kayla",
                    LastName = "Henderson",
                    Password = "password",
                    Address = "1234 Jerry Ln",
                    Subscription = new Subscription()
                    {
                        ExpirationDate = DateTime.Now.AddYears(1).ToUniversalTime(),
                        Tier = db.tiers.First(tier => tier.Level == TierLevel.THREE)
                    },
                    Allergies = new List<Allergy>()
                    {
                        db.allergies.FirstOrDefault(allergy => allergy.Name.ToLower() == "Shellfish") ?? new Allergy()
                        {
                            Name = "Shellfish"
                        }
                    },
                    DishPreferences =
                    {
                        db.dishes.First(dish => dish.Name == "Orange"),
                        db.dishes.First(dish => dish.Name == "Green Leaf Lettuce")
                    },
                    Payment = new Payment()
                    {
                        CardNumber = "987654321",
                        CvcNumber = "987",
                        ExpirationDate = new DateTime(2024, 10, 5).ToUniversalTime(),
                        NameOnCard = "Kayla Henderson",
                        Nickname = "My CC",
                        ZipCode = "68909"
                    },
                    PhoneNumber = "4089390001"
                },
                new User() {
                    Email = "SHenderson@gmail.com",
                    FirstName = "Samuel",
                    LastName = "Henderson",
                    Password = "password",
                    Address = "2222 Jefferson St",
                    Allergies =
                    {
                        db.allergies.FirstOrDefault(allergy => allergy.Name.ToLower() == "chocolate") ?? new Allergy()
                        {
                            Name = "Chocolate"
                        }
                    },
                    DishPreferences =
                    {
                        db.dishes.First(dish => dish.Name == "Banana"),
                        db.dishes.First(dish => dish.Name == "Avocado"),
                        db.dishes.First(dish => dish.Name == "Orange"),
                    },
                    Payment = null,
                    PhoneNumber = "3081111919"
                },
                new User() {
                    Email = "Avery@gmail.com",
                    FirstName = "Avery",
                    LastName = "Henderson",
                    Password = "password",
                    Address = "1111 Jackson Blvd",
                    Allergies =
                    {
                        db.allergies.FirstOrDefault(allergy => allergy.Name == "Egg") ?? new Allergy()
                        {
                            Name = "Egg"
                        }
                    },
                    DishPreferences =
                    {
                        db.dishes.First(dish => dish.Name == "Banana"),
                        db.dishes.First(dish => dish.Name == "Avocado"),
                        db.dishes.First(dish => dish.Name == "Strawberry")
                    },
                    Payment = null,
                    PhoneNumber = "3083331111"
                },
            });

            db.SaveChanges();
        }

        private static void AddTiers(ApplicationDbContext db)
        {
            var tier = db.tiers.FirstOrDefault();

            if (tier != null)
                return;

            db.tiers.Add(new Tier()
            {
                Level = TierLevel.ONE,
                Price = 10.00,
                DishCount = DishCount.TWO
            });

            db.tiers.Add(new Tier()
            {
                Level = TierLevel.TWO,
                Price = 20.00,
                DishCount = DishCount.THREE
            });

            db.tiers.Add(new Tier()
            {
                Level = TierLevel.THREE,
                Price = 30.00,
                DishCount = DishCount.FOUR
            });

            db.SaveChanges();
        }
    }
}
