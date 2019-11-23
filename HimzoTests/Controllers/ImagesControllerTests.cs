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
	public class ImagesControllerTests
	{
		private ImagesController ImagesController;
		private List<Image> DbContent;

		[TestInitialize()]
		public void SetupTest()
		{
			MockHimzoDb db = new MockHimzoDb();
			ImagesController = new ImagesController(db.GetDbContext(), db.GetUserManager());
			DbContent = db.GetImages();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public void GetImagesTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void GetImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PutImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PostImageTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteImageTest()
		{
			Assert.Fail();
		}
	}
}