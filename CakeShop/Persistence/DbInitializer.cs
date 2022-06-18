using ShoeShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace ShoeShop.Persistence
{
    public static class DbInitializer
    {
        public static void SeedDatabase(
            ShoeShopDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            System.Console.WriteLine("Seeding... - Start");

            var categories = new List<Category>
            {
                new Category { Name = "Vanilla Shoes"},
                new Category { Name = "Chocolate Shoes" },
                new Category { Name = "Fruit Shoes"}
            };

            var shoes = new List<Shoe>
            {
                new Shoe
                {
                    Name ="Strawberry Shoe",
                    Price = 48.00M,
                    ShortDescription ="Yammy Sweet & Testy",
                    //////////////Adding size//////////////
                    Size = 42,
                    LongDescription ="Icing carrot shoe jelly-o cheeseshoe. tootsie roll oat shoe pie chocolate bar cookie dragée brownie. Lollipop cotton candy shoe bear claw oat shoe.dragée gummies.",
                    Category = categories[0],
                    ImageUrl ="/img/vanilla-shoe2.jpg",
                    IsShoeOfTheWeek = true,
                },
                new Shoe
                {
                    Name ="Dark Chocolate Shoe",
                    Price =45.50M,
                    ShortDescription ="Yammy! Dark Chocolate Flavour",
                    Size = 41,
                    LongDescription ="Icing carrot shoe jelly-o cheeseshoe. tootsie roll oat shoe pie chocolate bar cookie dragée brownie. Lollipop cotton candy shoe bear claw oat shoe.dragée gummies.",
                    Category = categories[1],
                    ImageUrl ="/img/chocolate-shoe4.jpg",
                    IsShoeOfTheWeek = true,
                },
                new Shoe
                {
                    Name ="Special Chocolate Shoe",
                    Price = 40.50M,
                    ShortDescription ="Taste Our Special Chocolates",
                    Size = 43,
                    LongDescription ="Icing carrot shoe jelly-o cheeseshoe. tootsie roll oat shoe pie chocolate bar cookie dragée brownie. Lollipop cotton candy shoe bear claw oat shoe.dragée gummies.",
                    Category = categories[1],
                    ImageUrl ="/img/chocolate-shoe3.jpg",
                    IsShoeOfTheWeek = false,
                },
                new Shoe
                {
                    Name ="Red Velvet Shoe",
                    Price=35.00M,
                    ShortDescription ="Our Special Shoe",
                    Size = 39,
                    LongDescription ="Icing carrot shoe jelly-o cheeseshoe. tootsie roll oat shoe pie chocolate bar cookie dragée brownie. Lollipop cotton candy shoe bear claw oat shoe.dragée gummies.",
                    Category = categories[0],
                    ImageUrl ="/img/vanilla-shoe4.jpg",
                    IsShoeOfTheWeek = true,
                },
                new Shoe
                {
                    Name ="Mixed Fruit Shoe",
                    Price = 30.50M,
                    ShortDescription ="Fruity & Testy",
                    Size = 40,
                    LongDescription ="Icing carrot shoe jelly-o cheeseshoe. tootsie roll oat shoe pie chocolate bar cookie dragée brownie. Lollipop cotton candy shoe bear claw oat shoe.caramels.",
                    Category = categories[2],
                    ImageUrl ="/img/fruit-shoe.jpg",
                    IsShoeOfTheWeek =true,
                }

            };

            if (!context.Categories.Any() && !context.Shoes.Any())
            {
                context.Categories.AddRange(categories);
                context.Shoes.AddRange(shoes);
                context.SaveChanges();
            }


            IdentityUser usr = null;
            string userEmail = configuration["Admin:Email"] ?? "admin@admin.com";
            string userName = configuration["Admin:Username"] ?? "admin";
            string password = configuration["Admin:Password"] ?? "Passw@rd!123";

            if (!context.Users.Any())
            {
                usr = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userName
                };
                userManager.CreateAsync(usr, password);
            }

            if (!context.UserRoles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));

            }
            if (usr == null)
            {
                usr = userManager.FindByEmailAsync(userEmail).Result;
            }
            if (!userManager.IsInRoleAsync(usr, "Admin").Result)
            {
                userManager.AddToRoleAsync(usr, "Admin");
            }

            context.SaveChanges();

            System.Console.WriteLine("Seeding... - End");
        }

    }
}