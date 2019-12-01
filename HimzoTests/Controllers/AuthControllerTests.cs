using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himzo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using HimzoTests.Controllers;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static Himzo.Web.Controllers.AuthController;
using Moq;
using Microsoft.Extensions.Logging;

namespace Himzo.Web.Controllers.Tests
{
	[TestClass()]
	public class AuthControllerTests
	{
		private AuthController AuthController;
		private List<User> DbContent;
		private MockHimzoDb db;

		[TestInitialize()]
		public void SetupTest()
		{
			db = new MockHimzoDb();
			var mockLogger = new Mock<ILogger<AuthController>>();
			AuthController = new AuthController(db.GetDbContext(), null, db.GetUserManager(), null, mockLogger.Object);
			AuthController.ControllerContext = new ControllerContext();
			AuthController.ControllerContext.HttpContext = new DefaultHttpContext();
			DbContent = db.GetUsers();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}
		
		[TestMethod()]
		public async Task GetTest()
		{
			var UserRequestResult = await AuthController.Get("test@himzo.hu");
			var CurrentUser = UserRequestResult.Value as UserResult;
			Assert.IsNotNull(CurrentUser);
			Assert.AreEqual(CurrentUser.Email, DbContent[0].Email);
			Assert.AreEqual(CurrentUser.University, DbContent[0].University);
			Assert.AreEqual(CurrentUser.UserName, DbContent[0].UserName);
			Assert.IsTrue(CurrentUser.Roles.Contains("User"));
		}

		[TestMethod()]
		public async Task GetUserTest()
		{
			var UserRequestResult = await AuthController.GetUser();
			var CurrentUser = UserRequestResult.Value as UserResult;
			Assert.IsNotNull(CurrentUser);
			Assert.AreEqual(CurrentUser.Email, DbContent[0].Email);
			Assert.AreEqual(CurrentUser.University, DbContent[0].University);
			Assert.AreEqual(CurrentUser.UserName, DbContent[0].UserName);
			Assert.IsTrue(CurrentUser.Roles.Contains("User"));
		}

		[TestMethod()]
		public async Task DeleteTest()
		{
			db.MockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>() { "User" });
			var UserRequestResult = await AuthController.Delete("test@email.com");
			var DeleteResult = UserRequestResult.Value as DeleteResult;
			Assert.AreEqual(DeleteResult.Message, "Permission denied!");
			Assert.AreEqual(DeleteResult.Success, false);
			db.MockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>() { "Kortag" });
			UserRequestResult = await AuthController.Delete("test@email.com");
			DeleteResult = UserRequestResult.Value as DeleteResult;
			Assert.AreEqual(DeleteResult.Message, "Permission denied!");
			Assert.AreEqual(DeleteResult.Success, false);
			db.MockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<User>())).ReturnsAsync(new List<string>() { "Admin" });
			UserRequestResult = await AuthController.Delete("test@email.com");
			DeleteResult = UserRequestResult.Value as DeleteResult;
			Assert.AreEqual(DeleteResult.Message, "User test@email.com has been deleted!");
			Assert.AreEqual(DeleteResult.Success, true);
		}
	}
}