using Himzo.Dal.Entities;
using Himzo.Dal.SeedInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Himzo.Dal.SeedService
{
    public class UserSeedService : IUserSeedService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly HimzoDbContext _context;
        public UserSeedService(RoleManager<Role> roleManager,
                               UserManager<User> userManager,
                               HimzoDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task SeedUserAsync()
        {
            if (!await _roleManager.RoleExistsAsync(Role.Admin))
                await _roleManager.CreateAsync(new Role { Name = Role.Admin });
            if (!await _roleManager.RoleExistsAsync(Role.Kortag))
                await _roleManager.CreateAsync(new Role { Name = Role.Kortag });
            if (!await _roleManager.RoleExistsAsync(Role.User))
                await _roleManager.CreateAsync(new Role { Name = Role.User });

            User AdminUser = null;
            User KorUser = null;
            User TestUser = null;
            if ((await _userManager.GetUsersInRoleAsync(Role.Admin)).Count == 0)
            {
                AdminUser = new User
                {
                    Email = "admin@himzo.hu",
                    Name = "Adminisztrátor",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(AdminUser, "$Administrator123");
                var addToRoleResult = await _userManager.AddToRoleAsync(AdminUser, Role.Admin);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Admin user cannot be created!");
            }

            if ((await _userManager.GetUsersInRoleAsync(Role.Kortag)).Count == 0)
            {
                KorUser = new User
                {
                    Email = "kortag@himzo.hu",
                    Name = "Kortag",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "kortag@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(KorUser, "#Kortag123");
                var addToRoleResult = await _userManager.AddToRoleAsync(KorUser, Role.Kortag);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Kortag user cannot be created!");
            }

            if ((await _userManager.GetUsersInRoleAsync(Role.User)).Count == 0)
            {
                TestUser = new User
                {
                    Email = "testuser@himzo.hu",
                    Name = "TestUser",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "testuser@himzo.hu",
                    Comments = new List<Comment>(),
                    Orders = new List<Order>()
                };
                var createResult = await _userManager.CreateAsync(TestUser, "$TestUser123");
                var addToRoleResult = await _userManager.AddToRoleAsync(TestUser, Role.User);
                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                    throw new ApplicationException($"Test user cannot be created!");
            }

            var orderCount = _context.Orders.Count();
            if (orderCount == 0)
            {
                byte[] FoltImage = System.IO.File.ReadAllBytes("../Himzo.DAL/Pictures/folt.png");
                byte[] MintaImage = System.IO.File.ReadAllBytes("../Himzo.DAL/Pictures/minta.jpg");
                byte[] PulcsiImage = System.IO.File.ReadAllBytes("../Himzo.DAL/Pictures/pulcsi.png");

                Comment Comment_1 = new Comment
                {
                    UpdateTime = new DateTime(2019, 10, 1, 11, 20, 11),
                    User = KorUser,
                    Content = "A képen szereplő minta túl nagy a megadott mérethez képest!"
                };

                Comment Comment_2 = new Comment
                {
                    UpdateTime = new DateTime(2019, 10, 2, 12, 10, 11),
                    User = KorUser,
                    Content = "Elkészült a pulcsi lehet érte jönni."
                };

                Comment Comment_3 = new Comment
                {
                    UpdateTime = new DateTime(2019, 10, 2, 10, 25, 11),
                    User = KorUser,
                    Content = "1 héten belül meglesz"
                };

                Order Order1 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.WAITING_FOR_ANSWER, // OrderState enum
                    Type = Order.ProductType.FOLT, // Type enum
                    Amount = 10, // Integer
                    Size = "20x30mm", // String
                    Fonts = "Arial", // String
                    PatternPlace = "-", // String
                    OrderTime = new DateTime(2019, 9, 25, 10, 20, 00), // DateTime
                    Deadline = new DateTime(2019, 10, 25, 12, 00, 00), // DateTime
                    OrderComment = "Amilyen gyorsan csak lehet!", // String
                    Comment = null, // Comment
                    Pattern = FoltImage, // Image (byte[])
                };

                Order Order2 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.IN_PROGRESS, // OrderState enum
                    Type = Order.ProductType.FOLT, // Type enum
                    Amount = 100, // Integer
                    Size = "50x50mm", // String
                    Fonts = "London", // String
                    PatternPlace = "-", // String
                    OrderTime = new DateTime(2019, 9, 30, 14, 12, 00), // DateTime
                    Deadline = new DateTime(2019, 10, 30, 12, 00, 00), // DateTime
                    OrderComment = "Legyenek szépek :)", // String
                    Comment = Comment_3, // Comment
                    Pattern = FoltImage, // Image (byte[])
                };

                Order Order3 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.DENIED, // OrderState enum
                    Type = Order.ProductType.MINTA, // Type enum
                    Amount = 1, // Integer
                    Size = "20x30mm", // String
                    Fonts = "Lato", // String
                    PatternPlace = "Váll felett", // String
                    OrderTime = new DateTime(2019, 10, 1, 10, 00, 00), // DateTime
                    Deadline = new DateTime(2019, 10, 10, 12, 00, 00), // DateTime
                    OrderComment = "Legyen látható helyen", // String
                    Comment = Comment_1, // Comment
                    Pattern = MintaImage, // Image (byte[])
                };

                Order Order4 = new Order
                {
                    User = KorUser, // User object
                    OrderState = Order.State.WAITING_FOR_ANSWER, // OrderState enum
                    Type = Order.ProductType.FOLT, // Type enum
                    Amount = 10, // Integer
                    Size = "20x30mm", // String
                    Fonts = "Webdings", // String
                    PatternPlace = "-", // String
                    OrderTime = new DateTime(2019, 9, 25, 10, 20, 00), // DateTime
                    Deadline = new DateTime(2019, 10, 25, 12, 00, 00), // DateTime
                    OrderComment = "Nem érek rá így megcsinálná nekem valaki?", // String
                    Comment = null, // Comment
                    Pattern = FoltImage, // Image (byte[])
                };

                Order Order5 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.DONE, // OrderState enum
                    Type = Order.ProductType.PULCSI, // Type enum
                    Amount = 2, // Integer
                    Size = "20x30mm", // String
                    Fonts = "Nordlight", // String
                    PatternPlace = "Hátra", // String
                    OrderTime = new DateTime(2019, 8, 10, 12, 00, 00), // DateTime
                    Deadline = new DateTime(2019, 9, 10, 12, 00, 00), // DateTime
                    OrderComment = "Kéne még pár pulcsi a golyáknak!", // String
                    Comment = Comment_2, // Comment
                    Pattern = PulcsiImage, // Image (byte[])
                };

                Comment CommentExample1 = new Comment
                {
                    User = KorUser,
                    Content = "Minta comment #1",
                    UpdateTime = new DateTime(2019, 1, 1, 12, 00, 00)
                };
                Comment CommentExample2 = new Comment
                {
                    User = KorUser,
                    Content = "Minta comment #2",
                    UpdateTime = new DateTime(2019, 1, 1, 12, 00, 00)
                };
                Comment CommentExample3 = new Comment
                {
                    User = KorUser,
                    Content = "Minta comment #3",
                    UpdateTime = new DateTime(2019, 1, 1, 12, 00, 00)
                };

                Order Order6 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.WAITING_FOR_ANSWER, // OrderState enum
                    Type = Order.ProductType.FOLT, // Type enum
                    Amount = 1, // Integer
                    Size = "10x10mm", // String
                    Fonts = "Minta font", // String
                    PatternPlace = "-", // String
                    OrderTime = new DateTime(2019, 1, 1, 12, 00, 00), // DateTime
                    Deadline = new DateTime(2019, 12, 31, 12, 00, 00), // DateTime
                    OrderComment = "Minta megrendelés (Folt)", // String
                    Comment = CommentExample1, // Comment
                    Pattern = FoltImage, // Image (byte[])
                };

                Order Order7 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.WAITING_FOR_ANSWER, // OrderState enum
                    Type = Order.ProductType.MINTA, // Type enum
                    Amount = 1, // Integer
                    Size = "10x10mm", // String
                    Fonts = "Minta font", // String
                    PatternPlace = "Minta pozició", // String
                    OrderTime = new DateTime(2019, 1, 1, 12, 00, 00), // DateTime
                    Deadline = new DateTime(2019, 12, 31, 12, 00, 00), // DateTime
                    OrderComment = "Minta megrendelés (Minta)", // String
                    Comment = CommentExample2, // Comment
                    Pattern = MintaImage, // Image (byte[])
                };

                Order Order8 = new Order
                {
                    User = TestUser, // User object
                    OrderState = Order.State.WAITING_FOR_ANSWER, // OrderState enum
                    Type = Order.ProductType.PULCSI, // Type enum
                    Amount = 1, // Integer
                    Size = "10x10mm", // String
                    Fonts = "Minta font", // String
                    PatternPlace = "Szívhez", // String
                    OrderTime = new DateTime(2019, 1, 1, 12, 00, 00), // DateTime
                    Deadline = new DateTime(2019, 12, 31, 12, 00, 00), // DateTime
                    OrderComment = "Minta megrendelés (Pulcsi)", // String
                    Comment = CommentExample3, // Comment
                    Pattern = PulcsiImage, // Image (byte[])
                };

                _context.Comments.Add(Comment_1);
                _context.Comments.Add(Comment_2);
                _context.Comments.Add(Comment_3);
                _context.Comments.Add(CommentExample1);
                _context.Comments.Add(CommentExample2);
                _context.Comments.Add(CommentExample3);
                _context.Orders.Add(Order1);
                _context.Orders.Add(Order2);
                _context.Orders.Add(Order3);
                _context.Orders.Add(Order4);
                _context.Orders.Add(Order5);
                _context.Orders.Add(Order6);
                _context.Orders.Add(Order7);
                _context.Orders.Add(Order8);
                _context.SaveChanges();
            }

            var contentCount = _context.Contents.Count();
            if (contentCount == 0)
            {
                Content content1 = new Content()
                {
                    Title = "Foltok",
                    ContentString = "Így tudsz rendelni",
                    Path = "welcome",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content2 = new Content()
                {
                    Title = "Hímzett minták",
                    ContentString = "Hozott anyagokra stb",
                    Path = "welcome",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content3 = new Content()
                {
                    Title = "VIKes pulcsik",
                    ContentString = "Többféle színben",
                    Path = "welcome",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content4 = new Content()
                {
                    Title = "Pulcsi és FoltMéKör",
                    ContentString = "Mi vagyunk, ls ezt csináljuk",
                    Path = "title",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content5 = new Content()
                {
                    Title = "Tudj meg többet",
                    ContentString = null,
                    Path = "title",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content6 = new Content()
                {
                    Title = "Hímző",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content7 = new Content()
                {
                    Title = "Rendelés",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content8 = new Content()
                {
                    Title = "Rendeléseim",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content9 = new Content()
                {
                    Title = "Rólunk",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content10 = new Content()
                {
                    Title = "Profilom",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content11 = new Content()
                {
                    Title = "Kilépés",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content12 = new Content()
                {
                    Title = "Bejelentkezés",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content13 = new Content()
                {
                    Title = "Amivel foglalkozunk",
                    ContentString = "balblablabla",
                    Path = "aboutus",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content14 = new Content()
                {
                    Title = "A kör története",
                    ContentString = "így alakultunk",
                    Path = "aboutus",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content15 = new Content()
                {
                    Title = "Csatlakozási lehetőség",
                    ContentString = "Így csatlakozhatsz",
                    Path = "aboutus",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content16 = new Content()
                {
                    Title = "Tagok",
                    ContentString = "valami szép leírás",
                    Path = "aboutus",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content17 = new Content()
                {
                    Title = "Vissza a tetejére",
                    ContentString = null,
                    Path = "footer",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content18 = new Content()
                {
                    Title = "©Pulcsi és FoltMéKör",
                    ContentString = null,
                    Path = "footer",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content19 = new Content()
                {
                    Title = "himzo@sch.bme.hu",
                    ContentString = null,
                    Path = "footer",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                Content content20 = new Content()
                {
                    Title = "Megrendelések",
                    ContentString = null,
                    Path = "welcome",
                    UpdateTime = new DateTime(2019, 11, 06, 0, 00, 00)
                };

                _context.Contents.Add(content1);
                _context.Contents.Add(content2);
                _context.Contents.Add(content3);
                _context.Contents.Add(content4);
                _context.Contents.Add(content5);
                _context.Contents.Add(content6);
                _context.Contents.Add(content7);
                _context.Contents.Add(content8);
                _context.Contents.Add(content9);
                _context.Contents.Add(content10);
                _context.Contents.Add(content11);
                _context.Contents.Add(content12);
                _context.Contents.Add(content13);
                _context.Contents.Add(content14);
                _context.Contents.Add(content15);
                _context.Contents.Add(content16);
                _context.Contents.Add(content17);
                _context.Contents.Add(content18);
                _context.Contents.Add(content19);
                _context.Contents.Add(content20);

                _context.SaveChanges();

            }
        }
    }
}
