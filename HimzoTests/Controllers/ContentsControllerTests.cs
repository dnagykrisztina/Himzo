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
	public class ContentsControllerTests
	{
		private ContentsController ContentsController;
		private List<Content> DbContent;

		[TestInitialize()]
		public void SetupTest()
		{
			MockHimzoDb db = new MockHimzoDb();
			ContentsController = new ContentsController(db.GetDbContext(), db.GetUserManager());
			DbContent = db.GetContents();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public void GetContentsTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PatchContentTest()
		{
			Assert.Fail();
		}
	}
}