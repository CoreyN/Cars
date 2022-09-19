using Cars.Dtos;

namespace Cars.Repositories
{
    public interface ICarRepository
    {
        public Task<IReadOnlyList<CarSummary>> GetCarsAsync();
        public Task<CarDetails?> GetCarAsync(int id);
    }
}
