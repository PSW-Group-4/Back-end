using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalAPI.Dtos.MapItem
{
    public class RoomMapRequestDto : MapItemRequestDto
    {
        public Room Room { get; set; }
    }
}
