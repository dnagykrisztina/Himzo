using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himzo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using HimzoTests.Controllers;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace Himzo.Web.Controllers.Tests
{
	[TestClass()]
	public class ContentsControllerTests
	{
		private ContentsController ContentsController;
		private List<Content> DbContent;
		private MockHimzoDb db;

		[TestInitialize()]
		public void SetupTest()
		{
			db = new MockHimzoDb();
			ContentsController = new ContentsController(db.GetDbContext(), db.GetUserManager());
			ContentsController.ControllerContext = new ControllerContext();
			ContentsController.ControllerContext.HttpContext = new DefaultHttpContext();
			ContentsController.HttpContext.Request.QueryString = new QueryString("?path=profile");
			DbContent = db.GetContents();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public async Task GetContentsTest()
		{
			var ContentsResult = await ContentsController.GetContents();
			var Contents = ContentsResult.Value as List<ContentDTO>;

			Assert.IsNotNull(Contents);
			foreach (var Content in Contents)
			{
				int i = Contents.IndexOf(Content);
				Assert.AreEqual(Content.ContentId, DbContent[i].ContentId);
				Assert.AreEqual(Content.Title, DbContent[i].Title);
				Assert.AreEqual(Content.ContentString, DbContent[i].ContentString);
			}
		}

		[TestMethod()]
		public async Task PatchContentTest()
		{
			JsonPatchDocument<ContentDTO> jsonPatch = new JsonPatchDocument<ContentDTO>();
			jsonPatch.Add(c => c.Title, "New Title");
			jsonPatch.Add(c => c.ContentString, "New Content");
			var ContentResult = await ContentsController.PatchContent(1, jsonPatch);
			var ChangedContent = db.GetDbContext().Contents.Find(1);
			Assert.IsNotNull(ChangedContent);
			Assert.AreEqual(ChangedContent.ContentId, 1);
			Assert.AreEqual(ChangedContent.Title, "New Title");
			Assert.AreEqual(ChangedContent.ContentString, "New Content");
		}
	}
}