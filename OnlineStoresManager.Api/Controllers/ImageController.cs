using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnlineStoresManager.Abstractions;
using OnlineStoresManager.API.Core.images;

namespace OnlineStoresManager.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;
        public ImageController(ImageService uploadImageService)
        {
            _imageService = uploadImageService;
        }

        [HttpPost("api/image/upload")]
        public async Task<IActionResult> UploadImage([FromBody] Image image)
        {
            var imagePath = await _imageService.SaveImage(image);

            return Ok(imagePath);
        }

        [HttpPost("api/image/delete")]
        public IActionResult Delete([FromBody] ImageMetadata imageMetadata)
        {
            _imageService.DeleteImage(imageMetadata);
            return Ok();
        }
    }
}
