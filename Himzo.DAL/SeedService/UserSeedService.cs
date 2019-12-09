using Himzo.Dal.Entities;
using Himzo.Dal.SeedInterfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

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

        public byte[] GetPicture(string picturePath)
        {
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream(picturePath);
            MemoryStream ms = new MemoryStream();
            myStream.CopyTo(ms);
            return ms.ToArray();
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

            byte[] FoltImage = GetPicture("Himzo.Dal.Pictures.folt.png");
            byte[] MintaImage = GetPicture("Himzo.Dal.Pictures.minta.jpg");
            byte[] PulcsiImage = GetPicture("Himzo.Dal.Pictures.pulcsi.png");

            var orderCount = _context.Orders.Count();
            if (orderCount == 0)
            {

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
                Comment CommentExample4 = new Comment
                {
                    User = KorUser,
                    Content = "Minta comment #4",
                    UpdateTime = new DateTime(2019, 1, 1, 12, 00, 00)
                };
                Comment CommentExample5 = new Comment
                {
                    User = KorUser,
                    Content = "Minta comment #5",
                    UpdateTime = new DateTime(2019, 1, 1, 12, 00, 00)
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
                    Comment = CommentExample4, // Comment
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
                    Comment = CommentExample5, // Comment
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
                    User = AdminUser, // User object
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
                _context.Comments.Add(CommentExample4);
                _context.Comments.Add(CommentExample5);
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

                Content content21 = new Content()
                {
                    Title = "Hímző",
                    ContentString = null,
                    Path = "header",
                    UpdateTime = new DateTime()
                };

                Content content22 = new Content()
                {
                    Title = "Keress minket",
                    ContentString = null,
                    Path = "footer",
                    UpdateTime = new DateTime()
                };

                Content content23 = new Content()
                {
                    Title = "Pulcsi és Foltmékör",
                    ContentString = null,
                    Path = "title",
                    UpdateTime = new DateTime()
                };

                Content content24 = new Content()
                {
                    Title = "Rendelj foltot",
                    ContentString = null,
                    Path = "welcome",
                    UpdateTime = new DateTime()
                };

                Content content25 = new Content()
                {
                    Title = "Ismerj meg minket",
                    ContentString = null,
                    Path = "aboutus",
                    UpdateTime = new DateTime()
                };

                Content content26 = new Content()
                {
                    Title = "Regisztrálj",
                    ContentString = null,
                    Path = "registration",
                    UpdateTime = new DateTime()
                };

                Content content27 = new Content()
                {
                    Title = "Bejelentkezés",
                    ContentString = null,
                    Path = "signin",
                    UpdateTime = new DateTime()
                };

                Content content28 = new Content()
                {
                    Title = "Folt mérete",
                    ContentString = null,
                    Path = "patchform",
                    UpdateTime = new DateTime()
                };

                Content content29 = new Content()
                {
                    Title = "Minta mérete",
                    ContentString = null,
                    Path = "patternform",
                    UpdateTime = new DateTime()
                };

                Content content30 = new Content()
                {
                    Title = "Rendelések állapota",
                    ContentString = null,
                    Path = "userorder",
                    UpdateTime = new DateTime()
                };

                Content content31 = new Content()
                {
                    Title = "Rendelések",
                    ContentString = null,
                    Path = "header_member",
                    UpdateTime = new DateTime()
                };

                Content content32 = new Content()
                {
                    Title = "Minden rendelés",
                    ContentString = null,
                    Path = "allorder",
                    UpdateTime = new DateTime()
                };

                Content content33 = new Content()
                {
                    Title = "Tagok",
                    ContentString = null,
                    Path = "members",
                    UpdateTime = new DateTime()
                };

                Content content34 = new Content()
                {
                    Title = "Jogok",
                    ContentString = null,
                    Path = "header_admin",
                    UpdateTime = new DateTime()
                };

                Content content35 = new Content()
                {
                    Title = "Admincím",
                    ContentString = null,
                    Path = "title_admin",
                    UpdateTime = new DateTime()
                };

                Content content36 = new Content()
                {
                    Title = "Szerkesztés",
                    ContentString = null,
                    Path = "welcome_admin",
                    UpdateTime = new DateTime()
                };

                Content content37 = new Content()
                {
                    Title = "Szerkesztés",
                    ContentString = null,
                    Path = "aboutus_admin",
                    UpdateTime = new DateTime()
                };

                Content content38 = new Content()
                {
                    Title = "Profilom",
                    ContentString = null,
                    Path = "profile",
                    UpdateTime = new DateTime()
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
                _context.Contents.Add(content21);
                _context.Contents.Add(content22);
                _context.Contents.Add(content23);
                _context.Contents.Add(content24);
                _context.Contents.Add(content25);
                _context.Contents.Add(content26);
                _context.Contents.Add(content27);
                _context.Contents.Add(content28);
                _context.Contents.Add(content29);
                _context.Contents.Add(content30);
                _context.Contents.Add(content31);
                _context.Contents.Add(content32);
                _context.Contents.Add(content33);
                _context.Contents.Add(content34);
                _context.Contents.Add(content35);
                _context.Contents.Add(content36);
                _context.Contents.Add(content37);
                _context.Contents.Add(content38);
                _context.SaveChanges();

            }

            var imageCount = _context.Images.Count();
            if (imageCount == 0)
            {
                Image image1 = new Image()
                {
                    Path = "welcome",
                    ByteImage = PulcsiImage,
                    Type = Order.ProductType.PULCSI,
                    Active = true
                };

                Image image2 = new Image()
                {
                    Path = "aboutus",
                    ByteImage = PulcsiImage,
                    Type = Order.ProductType.PULCSI,
                    Active = true
                };

                Image image3 = new Image()
                {
                    Path = "welcome",
                    ByteImage = FoltImage,
                    Type = Order.ProductType.FOLT,
                    Active = true
                };

                Image image4 = new Image()
                {
                    Path = "aboutus",
                    ByteImage = FoltImage,
                    Type = Order.ProductType.FOLT,
                    Active = true
                };

                _context.Images.Add(image1);
                _context.Images.Add(image2);
                _context.Images.Add(image3);
                _context.Images.Add(image4);
                _context.SaveChanges();
            }
        }
    }
}
