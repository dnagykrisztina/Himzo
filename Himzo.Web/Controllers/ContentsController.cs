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

namespace Himzo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly HimzoDbContext _context;

        public ContentsController(HimzoDbContext context)
        {
            _context = context;
        }

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

        // Patch: api/Contents/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Route("{path}")]
        [HttpPatch]
        public async Task<IActionResult> PatchContent(string path, [FromBody] JsonPatchDocument<Content> patchModel)
        {
            try
            {
                Content content = await _context.Contents.Where(x => x.Path == path).FirstOrDefaultAsync();
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
