using Microsoft.AspNetCore.Mvc;
using RoomDesigner.Enums;
using RoomDesigner.Interfaces;

namespace RoomDesigner.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _fileService;
        private readonly IRoomService _roomService;

        public RoomController(IFileService fileService, IWebHostEnvironment webHostEnvironment, IRoomService roomService)
        {
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
            _roomService = roomService;
        }

        [HttpGet("")]
        public ActionResult GetPotwierdzeniePhoto(string wallColor, string tvSize, string decoration, string carpet)
        {
            var wallColorType = WallColor.Red;
            var tvSizeType = TvSize.Large;
            var decorationType = DecorationType.Teapot;
            var carpetType = CarpetType.White;

            var fileName = _roomService.GetRoomFileName(wallColorType, tvSizeType, decorationType, carpetType);

            var imageStream = _fileService.GetPhoto(fileName, _webHostEnvironment.ContentRootPath);

            if (imageStream is null)
            {
                return NotFound();
            }

            return File(imageStream, "image/jpeg");
        }
    }
}
