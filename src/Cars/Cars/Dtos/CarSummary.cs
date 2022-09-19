namespace Cars.Dtos
{
    public class CarSummary
    {
        public int Id { get; }
        public string Make { get; }
        public string Model { get; }

        public CarSummary(
            int id, string make, string model)
        {
            Id = id;
            Make = make;
            Model = model;
        }
    }
}
