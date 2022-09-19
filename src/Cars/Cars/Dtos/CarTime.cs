namespace Cars.Dtos
{
    public class CarTime
    {
        public int Year { get; set; }
        public string Trim { get; set; }
        public string DriveType { get; set; }
        public string Transmission { get; set; }
        public decimal ZeroToSixtyTime { get; set; }
        public decimal QuarterMileTime { get; set; }
        public decimal QuarterMileSpeed { get; set; }
    }
}
