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
using AutoMapper.Mappers;

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

            if (await _userManager.IsInRoleAsync(user, Role.User))
            {

                return await _context.Orders.Where(x => x.User.Id == user.Id)
                                            .OrderBy(x => x.OrderTime)
                                            .Select(x => new OrderDTO() {
                                                OrderId = x.OrderId,
                                                CommentUpdateTime = x.Comment.UpdateTime,
                                                CommentContent = x.Comment.Content,
                                                OrderState = x.OrderState,
                                                Size = x.Size,
                                                Amount = x.Amount,
                                                Type = x.Type,
                                                Deadline = x.Deadline,
                                                Fonts = x.Fonts,
                                                OrderComment = x.OrderComment,
                                                OrderTime = x.OrderTime,
                                                Pattern = x.Pattern,
                                                PatternPlace = x.PatternPlace,
                                                UserName = x.User.Name,
                                                UserEmail = x.User.Email
                                            }).ToListAsync<OrderDTO>();

            } else if (await _userManager.IsInRoleAsync(user, Role.Kortag) || await _userManager.IsInRoleAsync(user, Role.Admin))
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
                                            Size = x.Size,
                                            Amount = x.Amount,
                                            Type = x.Type,
                                            Deadline = x.Deadline,
                                            Fonts = x.Fonts,
                                            OrderComment = x.OrderComment,
                                            OrderTime = x.OrderTime,
                                            Pattern = x.Pattern,
                                            PatternPlace = x.PatternPlace,
                                            UserName = x.User.Name,
                                            UserEmail = x.User.Email
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
                                                    Size = x.Size,
                                                    Amount = x.Amount,
                                                    Type = x.Type,
                                                    Deadline = x.Deadline,
                                                    Fonts = x.Fonts,
                                                    OrderComment = x.OrderComment,
                                                    OrderTime = x.OrderTime,
                                                    Pattern = x.Pattern,
                                                    PatternPlace = x.PatternPlace,
                                                    UserName = x.User.Name,
                                                    UserEmail = x.User.Email
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
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (user == null)
            {
                return Unauthorized("Error accessing orders because of incorrect authority level!");
            }
            
            var order = await _context.Orders.Include(x => x.User)
                                             .Include(x => x.Comment)
                                             .Where(x => x.OrderId == id).FirstOrDefaultAsync<Order>();
            if (order == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, Role.User))
            {
                if (user.Id != order.User.Id)
                {
                    return Unauthorized("The requested order cannot be accessed by this user!");
                } else
                {
                    return ConvertToOrderDetailsDTO(order);
                                                
                }
            } else if (await _userManager.IsInRoleAsync(user, Role.Kortag) || await _userManager.IsInRoleAsync(user, Role.Admin))
            {
                return ConvertToOrderDetailsDTO(order);
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
        public async Task<IActionResult> PatchOrder(int orderId, [FromBody] JsonPatchDocument<OrderPatchDTOUnion> patchModel)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                if (user == null)
                {
                    return Unauthorized("Error accessing orders because of incorrect authority level!");
                }

                var order = await _context.Orders.Include(x => x.User)
                                             .Include(x => x.Comment)
                                             .Where(x => x.OrderId == orderId).FirstOrDefaultAsync<Order>();
                var tempOrder = ConvertToOrderPatchUnionDTO(order);

                if (order == null) {

                    return NotFound();
                }

                if (await _userManager.IsInRoleAsync(user, Role.User)) {
                    if (user.Id != order.User.Id)
                    {
                        return Unauthorized("Error patching order. A user can only patch their own orders.");
                    } else
                    {
                        
                        patchModel.ApplyTo(tempOrder);

                        var orderPatchDTO = ConvertToPatchDetailsDTO(tempOrder);
                        order = await MapPatchDetailsToOrderAsync(orderPatchDTO, order);

                        _context.Orders.Update(order);
                        await _context.SaveChangesAsync();
                        return new ObjectResult(ConvertToOrderDetailsDTO(order));
                    }
                } else if (await _userManager.IsInRoleAsync(user, Role.Kortag) || await _userManager.IsInRoleAsync(user, Role.Admin))
                {
                    patchModel.ApplyTo(tempOrder);
                    if (user.Id != order.User.Id)
                    {

                        var orderPatchDTO = ConvertToPatchDTO(tempOrder);
                        order = await MapPatchToOrderAsync(orderPatchDTO, order);

                    } else
                    {
                        var orderPatchDetailsDTO = ConvertToPatchDetailsDTO(tempOrder);
                        var orderPatchDTO = ConvertToPatchDTO(tempOrder);
                        order = await MapPatchDetailsToOrderAsync(orderPatchDetailsDTO, order);
                        order = await MapPatchToOrderAsync(orderPatchDTO, order);
                    }

                    _context.Orders.Update(order);
                    await _context.SaveChangesAsync();
                    return new ObjectResult(ConvertToOrderDetailsDTO(order));
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
        public async Task<ActionResult<Order>> PostOrder(OrderPatchDetailsDTO orderDTO)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized("Error accessing orders because of incorrect authority level!");
            }
            
            Order order = new Order();
            orderDTO.OrderTime = DateTime.Now;
            if (!IsValidPOST(orderDTO))
            {
                return BadRequest("Error processing new order due to unprocessable input!");
            }
            order = await MapPatchDetailsToOrderAsync(orderDTO, order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, ConvertToOrderDetailsDTO(order));
        }

        /*
         * Töröl egy létező ordert id alapján.
         * Egy felhasználó csak a saját orderét képes törölni.
         * Körtag/admin képes megrendelést törölni (?)
         */
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> DeleteOrder(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized("Error deleting order because of incorrect authority level!");
            }

            var order = await _context.Orders.Include(x => x.Comment)
                                             .Where(x => x.OrderId == id).FirstOrDefaultAsync<Order>();
            var userOfOrder = await _context.Orders.Where(x => x.OrderId == id).Select(x => x.User).FirstOrDefaultAsync<User>();
            
            if (order == null)
            {
                return NotFound();
            }

            if (await _userManager.IsInRoleAsync(user, Role.User))
            {
                if (user.Id != userOfOrder.Id)
                {
                    return Unauthorized("Error deleting order. A user can only delete their own orders.");
                } else
                {
                    _context.Orders.Remove(order);
                    await _context.SaveChangesAsync();
                    return ConvertToOrderDetailsDTO(order);
                }
            } else if (await _userManager.IsInRoleAsync(user, Role.Kortag) || await _userManager.IsInRoleAsync(user, Role.Admin))
            {
                
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return ConvertToOrderDetailsDTO(order);
            }

            return BadRequest("Error deleting order");
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private OrderDTO ConvertToOrderDetailsDTO (Order order)
        {
            return new OrderDTO()
            {
                OrderId = order.OrderId,
                CommentUpdateTime = order.Comment != null ? order.Comment.UpdateTime : DateTime.MinValue,
                CommentContent = order.Comment != null ? order.Comment.Content : "-",
                OrderState = order.OrderState,
                Size = order.Size,
                Amount = order.Amount,
                Deadline = order.Deadline,
                Pattern = order.Pattern,
                OrderComment = order.OrderComment,
                OrderTime = order.OrderTime,
                Fonts = order.Fonts,
                Type = order.Type,
                PatternPlace = order.PatternPlace,
                UserName = order.User.Name,
                UserEmail = order.User.Email
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private OrderPatchDetailsDTO ConvertToPatchDetailsDTO(OrderPatchDTOUnion order)
        {
            return new OrderPatchDetailsDTO()
            {
                Size = order.Size,
                Amount = order.Amount,
                Deadline = order.Deadline,
                Pattern = order.Pattern,
                OrderComment = order.OrderComment,
                OrderTime = order.OrderTime,
                Fonts = order.Fonts,
                Type = order.Type,
                PatternPlace = order.PatternPlace
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private OrderPatchDTO ConvertToPatchDTO(OrderPatchDTOUnion order)
        {
            return new OrderPatchDTO()
            {
                CommentUpdateTime = order.CommentUpdateTime != null ? order.CommentUpdateTime : DateTime.MinValue,
                CommentContent = order.CommentContent != null ? order.CommentContent : "-",
                OrderState = order.OrderState,
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<Order> MapPatchDetailsToOrderAsync(OrderPatchDetailsDTO orderDTO, Order order)
        {
            order.Size = orderDTO.Size;
            order.Amount = orderDTO.Amount;
            order.Deadline = orderDTO.Deadline <= DateTime.Now ? DateTime.Now : orderDTO.Deadline;
            order.Pattern = orderDTO.Pattern;
            order.OrderComment = orderDTO.OrderComment;
            order.OrderTime = orderDTO.OrderTime <= DateTime.Now ? DateTime.Now : orderDTO.OrderTime;
            order.Fonts = orderDTO.Fonts;
            order.Type = orderDTO.Type;
            order.PatternPlace = orderDTO.PatternPlace;
            order.User = await _userManager.GetUserAsync(HttpContext.User);
            return order;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private async Task<Order> MapPatchToOrderAsync(OrderPatchDTO orderDTO, Order order)
        {
            if (order.Comment != null)
            {
                
                if (!order.Comment.Content.Equals(orderDTO.CommentContent))
                {
                    order.Comment.UpdateTime = DateTime.Now;
                    order.Comment.Content = orderDTO.CommentContent;
                    order.Comment.User = await _userManager.GetUserAsync(HttpContext.User);
                }
                
            } else
            {
                if (orderDTO.CommentContent != "-")
                {
                    order.Comment = new Comment();
                    order.Comment.UpdateTime = DateTime.Now;
                    order.Comment.Content = orderDTO.CommentContent;
                    order.Comment.User = await _userManager.GetUserAsync(HttpContext.User);
                }
                
            }
            
            order.OrderState = orderDTO.OrderState;

            return order;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        private Boolean IsValidPOST(OrderPatchDetailsDTO orderDTO)
        {
            if ((orderDTO.Amount < 0 || orderDTO.Amount > 5000) ||
                orderDTO.Deadline < DateTime.Now || orderDTO.Deadline == null ||
                orderDTO.Fonts == null ||
                orderDTO.Pattern == null ||
                orderDTO.PatternPlace == null || orderDTO.PatternPlace == "" ||
                orderDTO.Size == null || orderDTO.Size == "" ||
                (orderDTO.Type != Order.ProductType.FOLT && orderDTO.Type != Order.ProductType.MINTA &&
                orderDTO.Type != Order.ProductType.PULCSI)) 
            {
                return false;
            }
            
            return true;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private OrderPatchDTOUnion ConvertToOrderPatchUnionDTO(Order order)
        {
            return new OrderPatchDTOUnion
            {
                Amount = order.Amount,
                CommentUpdateTime = order.Comment != null ? order.Comment.UpdateTime : DateTime.MinValue,
                CommentContent = order.Comment != null ? order.Comment.Content : "-",
                Deadline = order.Deadline,
                Fonts = order.Fonts,
                OrderComment = order.OrderComment,
                OrderState = order.OrderState,
                OrderTime = order.OrderTime,
                Pattern = order.Pattern,
                PatternPlace = order.PatternPlace,
                Size = order.Size,
                Type = order.Type
            };
        }
    }
}
