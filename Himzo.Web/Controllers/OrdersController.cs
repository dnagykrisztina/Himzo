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
        private readonly UserManager<User> _userManager;

        public OrdersController(HimzoDbContext context, UserManager<User> userManager = null)
        {
            _context = context;
            _userManager = userManager;
            
        }

        /*
         * Visszaadja a felhasználónak a saját rendeléseit, a körtagnak / adminnak a saját vagy az összes
         * rendelést az all getParam értéke alapján (ha true, akkor az összeset).
         * Körtag / admin képes szűrni az eredményeket:
         * - search : leírásban keresés
         * - name : rendelő nevében keresés
         * - email : rendelő emailjében keresés
         * A szűrési paraméterek kombinálhatók.
         */
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            string all = HttpContext.Request.Query["all"].ToString();
            string search = HttpContext.Request.Query["search"].ToString();
            string name = HttpContext.Request.Query["name"].ToString();
            string email = HttpContext.Request.Query["email"].ToString();
            //Current user and role for role based orderslist views 
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized("Error accessing orders because of incorrect authority level!");
            }

            if (await _userManager.IsInRoleAsync(user, "User"))
            {

                return await _context.Orders.Where(x => x.User.Id == user.Id)
                                            .OrderBy(x => x.OrderTime)
                                            .Select(x => new OrderDTO() {
                                                OrderId = x.OrderId,
                                                CommentUpdateTime = x.Comment.UpdateTime,
                                                CommentContent = x.Comment.Content,
                                                OrderState = x.OrderState,
                                                Amount = x.Amount,
                                                Type = x.Type
                                            }).ToListAsync<OrderDTO>();

            } else if (await _userManager.IsInRoleAsync(user, "Kortag") || await _userManager.IsInRoleAsync(user, "Admin"))
            {
                if (all != null && all.Equals("true"))
                {
                    return await _context.Orders.Where(x => x.OrderComment.Contains(search))
                                        .Where(x => x.User.Name.Contains(name))
                                        .Where(x => x.User.Email.Contains(email))
                                        .OrderBy(x => x.OrderState)
                                        .OrderBy(x => x.Deadline)
                                        .Select(x => new OrderDTO()
                                        {
                                            OrderId = x.OrderId,
                                            CommentUpdateTime = x.Comment.UpdateTime,
                                            CommentContent = x.Comment.Content,
                                            OrderState = x.OrderState,
                                            Amount = x.Amount,
                                            Type = x.Type
                                        })
                                        .ToListAsync<OrderDTO>();
                } else
                {
                    return await _context.Orders.Where(x => x.User.Id == user.Id)
                                                .OrderBy(x => x.OrderTime)
                                                .Select(x => new OrderDTO()
                                                {
                                                    OrderId = x.OrderId,
                                                    CommentUpdateTime = x.Comment.UpdateTime,
                                                    CommentContent = x.Comment.Content,
                                                    OrderState = x.OrderState,
                                                    Amount = x.Amount,
                                                    Type = x.Type
                                                })
                                                .ToListAsync<OrderDTO>();
                }
            }

            return new EmptyResult();

        }

        /*
         * Visszaadja a megadott id-val rendelkező ordert.
         * Egy felhasználónak csak a saját rendelését adja vissza.
         */
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (user == null)
            {
                return Unauthorized("Error accessing orders because of incorrect authority level!");
            }
            
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, "User"))
            {
                if (user.Id != order.User.Id)
                {
                    return Unauthorized("The requested order cannot be accessed by this user!");
                } else
                {
                    return order;
                }
            } else if (await _userManager.IsInRoleAsync(user, "Kortag") || await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return order;
            }
           
            return new EmptyResult();
        }

        /*
         * Updateli az adott ordert.
         * Egy felhasználó csak a saját ordereit tudja updatelni.
         * Körtag és admin képes más rendeléseket is updatelni (pl állapot miatt).
         */
        //PATCH: api/orders/5
        [Route("{orderId}")]
        [HttpPatch]
        public async Task<IActionResult> PatchOrder(int orderId, [FromBody] JsonPatchDocument<Order> patchModel)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user == null)
                {
                    return Unauthorized("Error accessing orders because of incorrect authority level!");
                }

                Order order = await _context.Orders.FindAsync(orderId);
                if (order == null) {

                    return NotFound();
                }

                if (await _userManager.IsInRoleAsync(user, "User")) {
                    if (user.Id != order.User.Id)
                    {
                        return Unauthorized("Error patching order. A user can only patch their own orders.");
                    } else
                    {
                        Order tempOrder = order;

                        patchModel.ApplyTo(tempOrder);

                        if (tempOrder.Comment != order.Comment)
                        {
                            return Unauthorized("Error patching order. A user cannot patch the comment on their order.");
                        }

                        patchModel.ApplyTo(order);

                        _context.Orders.Update(order);

                        await _context.SaveChangesAsync();

                        return new ObjectResult(order);
                    }
                } else if (await _userManager.IsInRoleAsync(user, "Kortag") || await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    
                    patchModel.ApplyTo(order);

                    _context.Orders.Update(order);

                    await _context.SaveChangesAsync();

                    return new ObjectResult(order);
                }
                
            }
            catch (Exception e)
            {
                
            }

            return BadRequest("Error updating order");
        }

        /*
         * Létrehoz egy új ordert.
         * Minden role jogosult erre.
         */
        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        /*
         * Töröl egy létező ordert id alapján.
         * Egy felhasználó csak a saját orderét képes törölni.
         * Körtag/admin képes megrendelést törölni (?)
         */
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized("Error deleting order because of incorrect authority level!");
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, "User"))
            {
                if (user.Id != order.User.Id)
                {
                    return Unauthorized("Error deleting order. A user can only delete their own orders.");
                } else
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    return order;
                }
            } else if (await _userManager.IsInRoleAsync(user, "Kortag") || await _userManager.IsInRoleAsync(user, "Admin"))
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return order;
            }

            return BadRequest("Error deleting order");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
