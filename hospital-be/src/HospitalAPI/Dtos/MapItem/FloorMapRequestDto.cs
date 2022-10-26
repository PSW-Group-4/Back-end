using HospitalLibrary.BuildingManagment.Model;

namespace HospitalAPI.Dtos.MapItem
{
    public class FloorMapRequestDto : MapItemRequestDto
    {
        public Floor Floor { get; set; }
    }
}
