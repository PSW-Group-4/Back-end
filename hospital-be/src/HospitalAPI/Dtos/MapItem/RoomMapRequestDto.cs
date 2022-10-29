using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalAPI.Dtos.MapItem
{
    public class RoomMapRequestDto : MapItemRequestDto
    {
        public RoomMapRequestDto RoomDto { get; set; }
    }
}
