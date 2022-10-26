namespace HospitalAPI.Dtos.MapItem
{
    public abstract class MapItemRequestDto
    {

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }
    }
}
