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
    public class ContentsController : ControllerBase
    {
        private readonly HimzoDbContext _context;
        private readonly UserManager<User> _userManager;

        private const string PATCH_AUTHORITY_LEVEL = "Admin";
        private const string POST_AUTHORITY_LEVEL = "Admin";
        private const string DELETE_AUTHORITY_LEVEL = "Admin";

        public ContentsController(HimzoDbContext context, UserManager<User> userManager = null)
        {
            _context = context;
            _userManager = userManager;
        }

        /*
         * Visszaadja az adott oldalon található contenteket.
         * Hiányzó oldal getParam esetén üres listát ad vissza.
         */
        // GET: api/Contents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> GetContents()
        {
            string path = HttpContext.Request.Query["path"].ToString();

            if (path != "")
            {
                return await _context.Contents.Where(x => x.Path == (path)).ToListAsync<Content>();
            }

            return new EmptyResult();
        }

        /*
         *  Content id alapján frissíti az oldalon található contentet.
         *  Ehhez a művelethez admin jogosultság szükséges.
         */
        // Patch: api/Contents/5
        [Route("{id}")]
        [HttpPatch]
        public async Task<IActionResult> PatchContent(int id, [FromBody] JsonPatchDocument<Content> patchModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null || await _userManager.IsInRoleAsync(user, PATCH_AUTHORITY_LEVEL) == false)
            {
                return Unauthorized("Error updating content because of incorrect authority level.");
            }

            try
            {
                Content content = await _context.Contents.Where(x => x.ContentId == id).FirstOrDefaultAsync();
                if (content == null)
                {
                    return NotFound();
                }

                patchModel.ApplyTo(content);

                _context.Contents.Update(content);

                await _context.SaveChangesAsync();

                return new ObjectResult(content);

            }
            catch (Exception e)
            {

            }

            return BadRequest("Error updating content");
        }

        // POST: api/Contents
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /*
        [HttpPost]
        public async Task<ActionResult<Content>> PostContent(Content content)
        {
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContent", new { id = content.ContentId }, content);
        }
        */

        // DELETE: api/Contents/5
        /*
        [HttpDelete("{id}")]
        public async Task<ActionResult<Content>> DeleteContent(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();

            return content;
        }
        */

        private bool ContentExists(string path)
        {
            return _context.Contents.Any(e => e.Path == path);
        }
    }
}
