using Microsoft.VisualStudio.TestTools.UnitTesting;
using Himzo.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Himzo.Dal;
using Microsoft.AspNetCore.Identity;
using Himzo.Dal.Entities;
using System.Threading;
using HimzoTests.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace Himzo.Web.Controllers.Tests
{
	[TestClass()]
	public class OrdersControllerTests
	{
		private OrdersController OrdersController;
		private List<Order> DbContent;

		[TestInitialize()]
		public void SetupTest() 
        {
			MockHimzoDb db = new MockHimzoDb();
			OrdersController = new OrdersController(db.GetDbContext(), db.GetUserManager());
			OrdersController.ControllerContext = new ControllerContext();
			OrdersController.ControllerContext.HttpContext = new DefaultHttpContext();
			DbContent = db.GetOrders();
		}

		[TestCleanup()]
		public void CleanUpTest()
		{
		}

		[TestMethod()]
		public async Task GetOrdersTest()
		{
			var OrdersResult = await OrdersController.GetOrders();
			var Orders = OrdersResult.Value as List<OrderDTO>;

		    foreach(var Order in Orders) {
				int i = Orders.ToList().IndexOf(Order);
				Assert.AreEqual(Order.OrderId, DbContent[i].OrderId);
				Assert.AreEqual(Order.OrderState, DbContent[i].OrderState);
				Assert.AreEqual(Order.Type, DbContent[i].Type);
				Assert.AreEqual(Order.Amount, DbContent[i].Amount);
				Assert.AreEqual(Order.CommentContent, DbContent[i].Comment.Content);
				Assert.AreEqual(Order.CommentUpdateTime, DbContent[i].Comment.UpdateTime);
			}
	    }

		[TestMethod()]
		public async Task GetOrderTest()
		{
			var OrderResult = await OrdersController.GetOrder(1);
			var Order = OrderResult.Value as OrderDTO;
			Assert.IsNotNull(Order);
			Assert.AreEqual(Order.OrderId, 1);
			Assert.AreEqual(Order.OrderState, DbContent[0].OrderState);
			Assert.AreEqual(Order.Pattern, DbContent[0].Pattern);
		}

		[TestMethod()]
		public void PatchOrderTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void PostOrderTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteOrderTest()
		{
			Assert.Fail();
		}
	}
}