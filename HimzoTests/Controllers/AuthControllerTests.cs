using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himzo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using HimzoTests.Controllers;
using Himzo.Dal.Entities;

namespace Himzo.Web.Controllers.Tests
{
	[TestClass()]
	public class AuthControllerTests
	{
		private AuthController AuthController;
		private List<User> DbContent;

		[TestInitialize()]
		public void SetupTest()
		{
			MockHimzoDb db = new MockHimzoDb();
			AuthController = new AuthController(db.GetDbContext(), db.GetSignInManager(), db.GetUserManager(), null, null);
			DbContent = db.GetUsers();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public void OnPostLoginTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void OnPostLogoutTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void OnPutSignUpTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetUserTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}
	}
}