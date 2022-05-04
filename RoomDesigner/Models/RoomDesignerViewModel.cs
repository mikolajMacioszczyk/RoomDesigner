using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoomDesigner.Models
{
    public class RoomDesignerViewModel
    {
        public List<SelectListItem> AvailableWallColors { get; set; }
        public List<SelectListItem> AvailableTvSize { get; set; }
        public List<SelectListItem> AvailableDecorations { get; set; }
        public List<SelectListItem> AvailableCarpet { get; set; }
    }
}
