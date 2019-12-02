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
	public class ImagesControllerTests
	{
		private ImagesController ImagesController;
		private List<Image> DbContent;
		private MockHimzoDb db;

		[TestInitialize()]
		public void SetupTest()
		{
			db = new MockHimzoDb();
			ImagesController = new ImagesController(db.GetDbContext(), db.GetUserManager());
			ImagesController.ControllerContext = new ControllerContext();
			ImagesController.ControllerContext.HttpContext = new DefaultHttpContext();
			ImagesController.HttpContext.Request.QueryString = new QueryString("?path=profile");
			DbContent = db.GetImages();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public async Task GetImagesTest()
		{
			var ImagesResult = await ImagesController.GetImages();
			var Images = ImagesResult.Value as List<ImageDTO>;

			Assert.IsNotNull(Images);
			foreach (var Image in Images)
			{
				int i = Images.IndexOf(Image);
				Assert.AreEqual(Image.ImageId, DbContent[i].ImageId);
				Assert.AreEqual(Image.ByteImage, Convert.ToBase64String(DbContent[i].ByteImage));
			}
		}

		[TestMethod()]
		public async Task GetImageTest()
		{
			var ImageResult = await ImagesController.GetImage(1);
			var Image = ImageResult.Value as ImageDTO;
			Assert.IsNotNull(Image);
			Assert.AreEqual(Image.ImageId, 1);
			Assert.AreEqual(Image.ByteImage, Convert.ToBase64String(DbContent[0].ByteImage));
		}

		[TestMethod()]
		public async Task PutImageTest()
		{
			JsonPatchDocument<ImagePatchDTO> jsonPatch = new JsonPatchDocument<ImagePatchDTO>();
			jsonPatch.Add(i => i.Path, "profile");
			jsonPatch.Add(i => i.Type, Order.ProductType.MINTA);
			var ImageResult = await ImagesController.PutImage(1, jsonPatch);
			var NewImageResult = ImageResult as ObjectResult;
			var NewImage = NewImageResult.Value as ImageDTO;
			Assert.IsNotNull(NewImage);
			Assert.AreEqual(NewImage.ImageId, 1);
			Assert.AreEqual(NewImage.ByteImage, Convert.ToBase64String(DbContent[0].ByteImage));
		}

		[TestMethod()]
		public async Task PostImageTest()
		{
			ImagePatchDTO newImage = new ImagePatchDTO()
			{
				Path = "profile",
				ByteImage = Convert.ToBase64String(DbContent[0].ByteImage),
				Type = Order.ProductType.FOLT,
				Active = true
			};
			var ImageResult = await ImagesController.PostImage(newImage);
			var NewImage = db.GetDbContext().Images.Find(DbContent.Count + 1);
			Assert.IsNotNull(NewImage);
			Assert.AreEqual(NewImage.ImageId, DbContent.Count + 1);
			Assert.AreEqual(NewImage.Path, "profile");
			Assert.AreEqual(NewImage.Type, Order.ProductType.FOLT);
			Assert.AreEqual(NewImage.Active, true);
		}

		[TestMethod()]
		public async Task DeleteImageTest()
		{
			var ImageDeleteResult = await ImagesController.DeleteImage(1);
			var DeletedImage = ImageDeleteResult.Value as ImageDTO;
			Image oldImage = db.GetDbContext().Images.Find(1);
			Assert.IsNotNull(DeletedImage);
			Assert.AreEqual(DeletedImage.ImageId, 1);
			Assert.AreEqual(DeletedImage.ByteImage, Convert.ToBase64String(DbContent[0].ByteImage));
		}
	}
}