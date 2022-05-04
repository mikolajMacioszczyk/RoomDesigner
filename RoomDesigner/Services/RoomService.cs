using RoomDesigner.Enums;
using RoomDesigner.Interfaces;

namespace RoomDesigner.Services
{
    public class RoomService : IRoomService
    {
        public string GetRoomFileName(WallColor color, TvSize tvSize, DecorationType decoration, CarpetType carpet)
        {
            var colorName = Enum.GetName(typeof(WallColor), color);
            var tvSizeName = Enum.GetName(typeof(TvSize), tvSize);
            var decorationName = Enum.GetName(typeof(DecorationType), decoration);
            var carpetName = Enum.GetName(typeof(CarpetType), carpet);
            return Path.Combine(colorName, tvSizeName, decorationName, $"{colorName}_{tvSizeName}_{decorationName}_{carpetName}.jpg");
        }
    }
}
