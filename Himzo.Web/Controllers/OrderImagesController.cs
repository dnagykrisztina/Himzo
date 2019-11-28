using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Identity;

namespace Himzo.Web.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderImagesController : ControllerBase
    {
        private readonly HimzoDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrderImagesController(HimzoDbContext context, UserManager<User> userManager = null)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/OrderImages
        [Route("Orders/{id}/image")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderImage(int id)
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
                }
                else
                {
                    var image = order.Pattern;
                    return File(image, "image/jpeg");
                }
            }
            else if (await _userManager.IsInRoleAsync(user, Role.Kortag) || await _userManager.IsInRoleAsync(user, Role.Admin))
            {
                var image = order.Pattern;
                return File(image, "image/jpeg");
            }

            return new EmptyResult();

        }

    }
}
