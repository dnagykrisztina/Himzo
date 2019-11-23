using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static HimzoTests.Controllers.TestClasses;

namespace HimzoTests.Controllers
{
	class MockHimzoDb
	{

		private static List<User> UserMockList = new List<User>
			{
				new User{
					Id = 1,
					Email = "test@email.com",
					UserName = "test@email.com",
					Name = "Test User",
					Comments = new List<Comment>(),
					Orders = new List<Order>()
				},
				new User{
					Id = 2,
					Email = "kortag@email.com",
					UserName = "kortag@email.com",
					Name = "Test Kortag",
					Comments = new List<Comment>(),
					Orders = new List<Order>()
				},
				new User{
					Id = 3,
					Email = "admin@email.com",
					UserName = "admin@email.com",
					Name = "Test Admin",
					Comments = new List<Comment>(),
					Orders = new List<Order>()
				},
			};

		private static List<Role> RoleMockList = new List<Role>
		{
			new Role
			{
				Name = "User"
			},
			new Role
			{
				Name = "Kortag"
			},
			new Role
			{
				Name = "Admin"
			}
		};

		private static List<Comment> CommentMockList = new List<Comment>
			{
				new Comment{
					CommentId = 1,
					User = UserMockList[1],
					Content = "Test Content #1",
					UpdateTime = new DateTime()
				},
				new Comment{
					CommentId = 2,
					User = UserMockList[1],
					Content = "Test Content #2",
					UpdateTime = new DateTime()
				},
				new Comment{
					CommentId = 3,
					User = UserMockList[1],
					Content = "Test Content #3",
					UpdateTime = new DateTime()
				},
			};

		private static List<Image> ImageMockList = new List<Image>
			{
				new Image{
					ImageId = 1,
					Path = "/folt",
					ByteImage = System.IO.File.ReadAllBytes("../../../TestPictures/folt.png"),
					Type = Order.ProductType.FOLT,
					Active = true
				},
				new Image{
					ImageId = 2,
					Path = "/minta",
					ByteImage = System.IO.File.ReadAllBytes("../../../TestPictures/minta.jpg"),
					Type = Order.ProductType.MINTA,
					Active = true
				},
				new Image{
					ImageId = 3,
					Path = "/pulcsi",
					ByteImage = System.IO.File.ReadAllBytes("../../../TestPictures/pulcsi.png"),
					Type = Order.ProductType.PULCSI,
					Active = true
				},
			};

		private static List<Content> ContentMockList = new List<Content>
			{
				new Content
				{
					ContentId = 1,
					Title = "Rendelés",
					ContentString = null,
					Path = "header",
					UpdateTime = new DateTime()
				},
				new Content
				{
					ContentId = 2,
					Title = "Főoldal",
					ContentString = null,
					Path = "body",
					UpdateTime = new DateTime()
				},
				new Content
				{
					ContentId = 3,
					Title = "Rendeléseim",
					ContentString = null,
					Path = "body",
					UpdateTime = new DateTime()
				},
			};

		private static List<Order> OrderMockList = new List<Order>
			{
				new Order
				{
					OrderId = 1,
					User = UserMockList[0],
                    OrderState = Order.State.WAITING_FOR_ANSWER,
                    Type = Order.ProductType.FOLT,
                    Amount = 1,
                    Size = "XxYmm",
                    Fonts = null,
                    PatternPlace = null,
                    OrderTime = new DateTime(),
                    Deadline = new DateTime(),
                    OrderComment = "Test Order Comment #1",
                    Comment = null,
                    Pattern = ImageMockList[0].ByteImage,
                },
				new Order
				{
			        OrderId = 2,
					User = UserMockList[0],
                    OrderState = Order.State.IN_PROGRESS,
                    Type = Order.ProductType.MINTA,
                    Amount = 1,
                    Size = "XxYmm",
                    Fonts = "TestFont1,TestFont2",
                    PatternPlace = "TestPlace",
                    OrderTime = new DateTime(),
                    Deadline = new DateTime(),
                    OrderComment = "Test Order Comment #2",
                    Comment = CommentMockList[0],
                    Pattern = ImageMockList[2].ByteImage,
                },
				new Order
				{
		            OrderId = 3,
					User = UserMockList[0],
                    OrderState = Order.State.DONE,
                    Type = Order.ProductType.PULCSI,
                    Amount = 1,
                    Size = "XxYmm",
                    Fonts = null,
                    PatternPlace = null,
                    OrderTime = new DateTime(),
                    Deadline = new DateTime(),
                    OrderComment = "Test Order Comment #3",
                    Comment = CommentMockList[1],
                    Pattern = ImageMockList[2].ByteImage,
                },
				new Order
				{
					OrderId = 4,
					User = UserMockList[0],
					OrderState = Order.State.DENIED,
					Type = Order.ProductType.MINTA,
					Amount = 1,
					Size = "XxYmm",
					Fonts = null,
					PatternPlace = null,
					OrderTime = new DateTime(),
					Deadline = new DateTime(),
					OrderComment = "Test Order Comment #4",
					Comment = CommentMockList[2],
					Pattern = ImageMockList[1].ByteImage,
				},
			};

		private Mock<HimzoDbContext> MockHimzoDbContext;
		private Mock<UserManager<User>> MockUserManager;
		private Mock<SignInManager<User>> MockSignInManager;

		public static Mock<DbSet<T>> GetDbSet<T>(IQueryable<T> TestData) where T : class
		{
			var MockSet = new Mock<DbSet<T>>();
			MockSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(new TestAsyncQueryProvider<T>(TestData.Provider));
			MockSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(TestData.Expression);
			MockSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(TestData.ElementType);
			MockSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(TestData.GetEnumerator());
			return MockSet;
		}

		public MockHimzoDb()
		{
			MockHimzoDbContext = new Mock<HimzoDbContext>();
			// Setup HimzoDbContext methods
			// ================================================================
			MockHimzoDbContext.Object.Comments = GetDbSet<Comment>(CommentMockList.AsQueryable()).Object;
			MockHimzoDbContext.Object.Contents = GetDbSet<Content>(ContentMockList.AsQueryable()).Object;
			MockHimzoDbContext.Object.Orders = GetDbSet<Order>(OrderMockList.AsQueryable()).Object;
			MockHimzoDbContext.Object.Images = GetDbSet<Image>(ImageMockList.AsQueryable()).Object;
			MockHimzoDbContext.Object.Roles = GetDbSet<Role>(RoleMockList.AsQueryable()).Object;
			// ================================================================
			// Setup UserManager

			var store = new Mock<IUserStore<User>>();
			MockUserManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);
			MockUserManager.Object.UserValidators.Add(new UserValidator<User>());
			MockUserManager.Object.PasswordValidators.Add(new PasswordValidator<User>());

			MockUserManager.Setup(x => x.IsInRoleAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);

			MockUserManager.Setup(x => x.DeleteAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
			MockUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<User, string>((x, y) => UserMockList.Add(x));
			MockUserManager.Setup(x => x.UpdateAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);
			MockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(UserMockList[0]);

			// ================================================================
			// Setup SignInManager
			MockSignInManager = new Mock<SignInManager<User>>();
			// ================================================================
		}

		public HimzoDbContext GetDbContext() { return MockHimzoDbContext.Object; }
		public UserManager<User> GetUserManager() { return this.MockUserManager.Object; }
		public SignInManager<User> GetSignInManager() { return this.MockSignInManager.Object; }

		public List<Comment> GetComments() { return CommentMockList; }
		public List<Content> GetContents() { return ContentMockList; }
		public List<Image> GetImages() { return ImageMockList; }
		public List<Order> GetOrders() { return OrderMockList; }
		public List<User> GetUsers() { return UserMockList; }

	}
}
