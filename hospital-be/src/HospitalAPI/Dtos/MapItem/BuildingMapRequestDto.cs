using HospitalLibrary.BuildingManagment.Model;

namespace HospitalAPI.Dtos.MapItem
{
    public class BuildingMapRequestDto : MapItemRequestDto
    {
        public Building Building { get; set; }
    }
}
