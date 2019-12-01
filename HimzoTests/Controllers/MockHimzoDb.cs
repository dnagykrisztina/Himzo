﻿using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
					University = "BME",
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
					Path = "profile",
					ByteImage = System.IO.File.ReadAllBytes("../../../TestPictures/folt.png"),
					Type = Order.ProductType.FOLT,
					Active = true
				},
				new Image{
					ImageId = 2,
					Path = "profile",
					ByteImage = System.IO.File.ReadAllBytes("../../../TestPictures/minta.jpg"),
					Type = Order.ProductType.MINTA,
					Active = true
				},
				new Image{
					ImageId = 3,
					Path = "profile",
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
					Path = "profile",
					UpdateTime = new DateTime()
				},
				new Content
				{
					ContentId = 2,
					Title = "Főoldal",
					ContentString = null,
					Path = "profile",
					UpdateTime = new DateTime()
				},
				new Content
				{
					ContentId = 3,
					Title = "Rendeléseim",
					ContentString = null,
					Path = "profile",
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

		private HimzoDbContext MockHimzoDbContext;
		public Mock<UserManager<User>> MockUserManager;
		private Mock<SignInManager<User>> MockSignInManager;

		public MockHimzoDb()
		{
			DbContextOptionsBuilder options = new DbContextOptionsBuilder();
			var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "TestHimzoDb.db" };
			var connectionString = connectionStringBuilder.ToString();
			var connection = new SqliteConnection(connectionString);
			options.UseSqlite(connection);
			MockHimzoDbContext = new HimzoDbContext(options.Options);
			MockHimzoDbContext.Database.EnsureDeleted();
			MockHimzoDbContext.Database.EnsureCreated();
			foreach (User user in UserMockList) {
				MockHimzoDbContext.Users.Add(user);
			}
			foreach (Role role in RoleMockList)
			{
				MockHimzoDbContext.Roles.Add(role);
			}
			foreach (Comment comment in CommentMockList)
			{
				MockHimzoDbContext.Comments.Add(comment);
			}
			foreach (Image image in ImageMockList)
			{
				MockHimzoDbContext.Images.Add(image);
			}
			foreach (Content content in ContentMockList)
			{
				MockHimzoDbContext.Contents.Add(content);
			}
			foreach (Order order in OrderMockList)
			{
				MockHimzoDbContext.Orders.Add(order);
			}
			MockHimzoDbContext.SaveChanges();
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
			MockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(UserMockList[0]);
			MockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>() { "User" });

			// ================================================================
			// Setup SignInManager
			/*MockSignInManager = new Mock<SignInManager<User>>(MockUserManager.Object,
				 new Mock<IHttpContextAccessor>().Object,
				 new Mock<IUserClaimsPrincipalFactory<User>>().Object,
				 new Mock<IOptions<IdentityOptions>>().Object,
				 new Mock<ILogger<SignInManager<User>>>().Object,
				 new Mock<IAuthenticationSchemeProvider>().Object);
				 */
			// ================================================================
		}

		public HimzoDbContext GetDbContext() { return MockHimzoDbContext; }
		public UserManager<User> GetUserManager() { return this.MockUserManager.Object; }
		public SignInManager<User> GetSignInManager() { return this.MockSignInManager.Object; }

		public List<Comment> GetComments() { return CommentMockList; }
		public List<Content> GetContents() { return ContentMockList; }
		public List<Image> GetImages() { return ImageMockList; }
		public List<Order> GetOrders() { return OrderMockList; }
		public List<User> GetUsers() { return UserMockList; }

	}
}