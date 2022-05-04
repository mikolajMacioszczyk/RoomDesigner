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

        [HttpGet("{wallColor}/{tvSize}/{decoration}/{carpet}")]
        public ActionResult GetPotwierdzeniePhoto(string wallColor, string tvSize, string decoration, string carpet)
        {
            var isValid = ParseRoomSpecs(wallColor, tvSize, decoration, carpet, out WallColor wallColorType, 
                out TvSize tvSizeType, out DecorationType decorationType, out CarpetType carpetType);
            if (!isValid)
            {
                return BadRequest($"Unsupprted room specification: {wallColor}, {tvSize}, {decoration}, {carpet}");
            }

            var fileName = _roomService.GetRoomFileName(wallColorType, tvSizeType, decorationType, carpetType);

            var imageStream = _fileService.GetPhoto(fileName, _webHostEnvironment.ContentRootPath);

            if (imageStream is null)
            {
                return NotFound();
            }

            return File(imageStream, "image/jpeg");
        }

        private bool ParseRoomSpecs(string wallColor, string tvSize, string decoration, string carpet,
            out WallColor wallColorType, out TvSize tvSizeType, out DecorationType decorationType, out CarpetType carpetType)
        {
            try
            {
                wallColorType = (WallColor)Enum.Parse(typeof(WallColor), wallColor.ToLower());
                tvSizeType = (TvSize)Enum.Parse(typeof(TvSize), tvSize.ToLower());
                decorationType = (DecorationType)Enum.Parse(typeof(DecorationType), decoration.ToLower());
                carpetType = (CarpetType)Enum.Parse(typeof(CarpetType), carpet.ToLower());
                return true;
            }
            catch (ArgumentException)
            {
                wallColorType = WallColor.red;
                tvSizeType = TvSize.medium;
                decorationType = DecorationType.teapot;
                carpetType = CarpetType.white;
                return false;
            }
        }
    }
}
