using RoomDesigner.Enums;

namespace RoomDesigner.Interfaces
{
    public interface IRoomService
    {
        string GetRoomFileName(WallColor color, TvSize tvSize, DecorationType decoration, CarpetType carpet);
    }
}
