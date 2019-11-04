﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace Himzo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly HimzoDbContext _context;
        private readonly UserManager<User> _userManager;

        private const string PATCH_AUTHORITY_LEVEL = "Admin";
        private const string POST_AUTHORITY_LEVEL = "Admin";
        private const string DELETE_AUTHORITY_LEVEL = "Admin";

        public ImagesController(HimzoDbContext context, UserManager<User> userManager = null)
        {
            _context = context;
            _userManager = userManager;
        }

        /* 
         * Majd ha lesz plusz oszlop a táblába, akkor visszaadja rendesen azokat a image-ket, amik egy pagere/csoportba tartoznak
         * Egyébként, ha nincs megadva, hogy melyik oldal képei kellenek, akkor üres lista vissza.
        */
        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetImages()
        {
            string path = HttpContext.Request.Query["path"].ToString();
      
            if (path != "")
            {
                return await _context.Images.Where(x => x.ImageId.ToString().Equals(path) && x.Active)
                    .Select(x => new ImageDTO() { 
                        ImageId = x.ImageId,
                        ByteImage = x.ByteImage
                    }).ToListAsync<ImageDTO>();
            }

            return new EmptyResult();
        }

        /*
         * Id alapján visszaadja a keresett képet.
         * Ha nem létezik megadott Id-jű kép, akkor http notfound-ot ad vissza.
         */
        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageDTO>> GetImage(int id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null || !image.Active)
            {
                return NotFound();
            }

            return ConvertToImageDTO(image);
        }


        /*
         * Id alapján lehetővé teszi a képek propetyjeinek a cseréjét.
         * Admin jogosultság szükséges ehhez a művelethez.
         */
        // PATCH: api/Images/5
        [Route("{id}")]
        [HttpPatch]
        public async Task<IActionResult> PutImage(int id, [FromBody] JsonPatchDocument<ImagePatchDTO> patchModel)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null || await _userManager.IsInRoleAsync(user, PATCH_AUTHORITY_LEVEL) == false)
            {
                return Unauthorized("Error updating image because of incorrect authority level.");
            }

            try
            {
                Image image = await _context.Images.Where(x => x.ImageId == id).FirstOrDefaultAsync();
                if (image == null)
                {
                    return NotFound();
                }

                ImagePatchDTO imageDTO = ConvertToImagePatchDTO(image);
                patchModel.ApplyTo(imageDTO);
                image = MapToImage(imageDTO, image);

                _context.Images.Update(image);
                await _context.SaveChangesAsync();
                return new ObjectResult(image);

            }
            catch (Exception e)
            {

            }

            return BadRequest("Error updating image");
        }

        // POST: api/Images
        /*
         * Új képet tölt fel.
         * Ehhez a művelethez admin jogosultság szükséges.
         */
        [HttpPost]
        public async Task<ActionResult<ImagePatchDTO>> PostImage(ImagePatchDTO imageDTO)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null || await _userManager.IsInRoleAsync(user, POST_AUTHORITY_LEVEL) == false)
            {
                return Unauthorized("Error posting image because of incorrect authority level.");
            }

            Image image = new Image();
            image = MapToImage(imageDTO, image);

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new { id = image.ImageId }, image);
        }

        // DELETE: api/Images/5
        /*
         * Id alapján képet töröl.
         * Ehhez a művelethez admin jogosultság szükséges.
         */
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImageDTO>> DeleteImage(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null || await _userManager.IsInRoleAsync(user, DELETE_AUTHORITY_LEVEL) == false)
            {
                return Unauthorized("Error updating image because of incorrect authority level.");
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return ConvertToImageDTO(image);
        }

        /*
         * Igazzal tér vissza, ha létezik a megadott id-jú kép.
         */
        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private ImageDTO ConvertToImageDTO(Image image)
        {
            return new ImageDTO()
            {
                ImageId = image.ImageId,
                ByteImage = image.ByteImage
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private ImagePatchDTO ConvertToImagePatchDTO(Image image)
        {
            return new ImagePatchDTO()
            {
                Active = image.Active,
                ByteImage = image.ByteImage,
                Path = image.Path
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private Image MapToImage(ImagePatchDTO imageDTO, Image image)
        {
            image.Active = imageDTO.Active;
            image.ByteImage = imageDTO.ByteImage;
            image.Path = imageDTO.Path;
            return image;
        }

    }
}
