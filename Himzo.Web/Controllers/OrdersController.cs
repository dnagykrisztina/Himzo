using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Identity;

namespace Himzo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly HimzoDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(HimzoDbContext context, UserManager<IdentityUser> userManager = null)
        {
            _context = context;
            _userManager = userManager;
            
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            //Current user and role for role based orderslist views 
            //var user = await _userManager.GetUserAsync(HttpContext.User);

            //string rolename =  _userManager.GetRolesAsync(user).Result.FirstOrDefault();

            string search = HttpContext.Request.Query["search"].ToString();
            string name = HttpContext.Request.Query["name"].ToString();
            string email = HttpContext.Request.Query["email"].ToString();

            return await _context.Orders.Where(x => x.OrderComment.Contains(search))
                                        .Where(x => x.User.Name.Contains(name))
                                        .Where(x => x.User.Email.Contains(email)).ToListAsync<Order>();

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        //PATCH: api/orders/5
        [Route("{orderId}")]
        [HttpPatch]
        public async Task<IActionResult> PatchOrder(int orderId, [FromBody] JsonPatchDocument<Order> patchModel)
        {
            try
            {
                Order order = await _context.Orders.FindAsync(orderId);
                if (order == null) {

                    return NotFound();
                }

                patchModel.ApplyTo(order);

                _context.Orders.Update(order);

                await _context.SaveChangesAsync();

                return new ObjectResult(order);


            }
            catch (Exception e)
            {
                
            }

            return BadRequest("Error updating customer");
        }

        // POST: api/Orders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
