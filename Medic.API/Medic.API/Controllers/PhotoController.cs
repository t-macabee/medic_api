using Mapster;
using MapsterMapper;
using Medic.API.Data;
using Medic.API.DTOs;
using Medic.API.Entities;
using Medic.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medic.API.Controllers
{
    public class PhotoController(IPhotoService photoService, IUserService userService, IMapper mapper, DataContext context) : BaseController
    {
        private IPhotoService photoService = photoService;
        private IUserService userService = userService;
        private IMapper mapper = mapper;
        private DataContext context = context;


        [HttpPost("add-photo/{id}")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(int id, IFormFile file)
        {
            var user = await context.Users.Include(u => u.Photos).SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await photoService.AddPhoto(file);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            var photo = new Photos
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                IsMain = !user.Photos.Any(p => p.IsMain)
            };

            user.Photos.Add(photo);

            if (await context.SaveChangesAsync() > 0)
            {
                var photoDto = photo.Adapt<PhotoDto>(); 
                return CreatedAtRoute("GetUser", new { id = user.Id }, photoDto);
            }

            return BadRequest("Problem adding photo");
        }

        [HttpPut("set-main/{userId}/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int userId, int photoId)
        {
            var user = await userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
            {
                return NotFound("Photo not found");
            }

            if (photo.IsMain)
            {
                return BadRequest("This is already the main photo");
            }

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);

            if (currentMain != null)
            {
                currentMain.IsMain = false;
            }

            photo.IsMain = true;

            user.PhotoUrl = photo.Url;

            if (await context.SaveChangesAsync() > 0)
            {
                return NoContent();
            }

            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{userId}/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int userId, int photoId)
        {
            var user = await userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
            {
                return NotFound("Photo not found");
            }

            if (photo.IsMain)
            {
                return BadRequest("You cannot delete the main photo");
            }

            if (photo.PublicId != null)
            {
                var result = await photoService.DeletePhoto(photo.PublicId);
                if(result.Error != null)
                {
                    return BadRequest(result.Error.Message);
                }
            }

            user.Photos.Remove(photo);

            if (await context.SaveChangesAsync() > 0)
            {
                return Ok();
            }

            return BadRequest("Problem deleting photo");
        }

    }
}
