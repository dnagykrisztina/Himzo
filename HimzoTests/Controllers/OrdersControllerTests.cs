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
using Microsoft.AspNetCore.JsonPatch;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Himzo.Web.Controllers.Tests
{
	[TestClass()]
	public class OrdersControllerTests
	{
		private OrdersController OrdersController;
		private List<Order> DbContent;
		private MockHimzoDb db;

		[TestInitialize()]
		public void SetupTest() 
        {
			db = new MockHimzoDb();
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

			Assert.IsNotNull(Orders);
		    foreach(var Order in Orders) {
				int i = Orders.ToList().IndexOf(Order);
				Assert.AreEqual(Order.OrderId, DbContent[i].OrderId);
				Assert.AreEqual(Order.OrderState, DbContent[i].OrderState);
				Assert.AreEqual(Order.Type, DbContent[i].Type);
				Assert.AreEqual(Order.Amount, DbContent[i].Amount);
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
		public async Task PatchOrderTest()
		{
			JsonPatchDocument<OrderPatchDTOUnion> jsonPatch = new JsonPatchDocument<OrderPatchDTOUnion>();
			jsonPatch.Add(o => o.Amount, 2);
		    var OrderResult = await OrdersController.PatchOrder(1, jsonPatch);
			var ChangedOrderResult = OrderResult as ObjectResult;
			var ChangedOrder = ChangedOrderResult.Value as OrderDTO;
			Assert.IsNotNull(ChangedOrder);
			Assert.AreEqual(ChangedOrder.OrderId, 1);
			Assert.AreEqual(ChangedOrder.Amount, 2);
		}

		[TestMethod()]
		public async Task PostOrderTest()
		{
			OrderPatchDetailsDTO newOrder = new OrderPatchDetailsDTO() {
				Size = "50x50",
				Amount = 1,
				OrderTime = new DateTime(),
				Deadline = DateTime.Now.AddDays(1),
				OrderComment = "New order #1",
				Type = Order.ProductType.FOLT,
				Pattern = System.IO.File.ReadAllBytes("../../../TestPictures/folt.png"),
				Fonts = "Arial",
				PatternPlace = "mellkas"
			};
			var numOfOrders = DbContent.Count();
			var Response = await OrdersController.PostOrder(newOrder);
			var NewOrder = db.GetDbContext().Orders.Find(numOfOrders+1);
			Assert.IsNotNull(NewOrder);
			Assert.AreEqual(NewOrder.OrderId, numOfOrders+1);
			Assert.AreEqual(NewOrder.OrderState, Order.State.WAITING_FOR_ANSWER);
			Assert.AreEqual(NewOrder.Type, Order.ProductType.FOLT);
			Assert.AreEqual(NewOrder.Amount, 1);
			Assert.AreEqual(NewOrder.OrderComment, "New order #1");
		}

		[TestMethod()]
		public async Task DeleteOrderTest()
		{
			var OrderDeleteResult = await OrdersController.DeleteOrder(1);
			var DeletedOrder = OrderDeleteResult.Value as OrderDTO;
			Assert.IsNotNull(DeletedOrder);
			Assert.AreEqual(DeletedOrder.OrderId, 1);
			Assert.AreEqual(DeletedOrder.OrderState, Order.State.WAITING_FOR_ANSWER);
			Assert.IsFalse(db.GetDbContext().Orders.Any(e => e.OrderId == 1));
		}
	}
}