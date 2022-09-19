namespace Cars.Dtos
{
    public class CarDetails
    {
        public int CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public List<CarTime> Times { get; set; }
    }
}
