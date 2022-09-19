using Cars.Dtos;

namespace Cars.Repositories
{
    public class InMemoryCarRepository : ICarRepository
    {
        public Task<IReadOnlyList<CarSummary>> GetCarsAsync()
        {
            var cars = new List<CarSummary>()
            {
                new CarSummary(0, "BMW", "M2"),
                new CarSummary(1, "BMW", "M3"),
                new CarSummary(2, "Porsche", "911"),
            };

            return Task.FromResult(cars as IReadOnlyList<CarSummary>);
        }

        public Task<CarDetails?> GetCarAsync(int id)
        {
            CarDetails car = null;

            switch(id)
            {
                case 0:
                    car = new CarDetails
                    {
                        CarId = 2,
                        Make = "BMW",
                        Model = "M2",
                        Times = new List<CarTime>
                        {
                            new CarTime
                            {
                                Year = 2020,
                                Trim = "CS Coupe",
                                DriveType = "RWD",
                                Transmission = "7A",
                                ZeroToSixtyTime = 3.4m,
                                QuarterMileTime = 11.7m,
                                QuarterMileSpeed = 120.0m
                            },
                            new CarTime
                            {
                                Year = 2020,
                                Trim = "CS Coupe",
                                DriveType = "RWD",
                                Transmission = "6M",
                                ZeroToSixtyTime = 4.1m,
                                QuarterMileTime = 12.4m,
                                QuarterMileSpeed = 117.6m
                            },
                            new CarTime
                            {
                                Year = 2019,
                                Trim = "Competition Coupe",
                                DriveType = "RWD",
                                Transmission = "6M",
                                ZeroToSixtyTime = 3.9m,
                                QuarterMileTime = 12.4m,
                                QuarterMileSpeed = 114.0m
                            },
                        }
                    };
                    break;
                case 1:
                    car = new CarDetails
                    {
                        CarId = 2,
                        Make = "BMW",
                        Model = "M3",
                        Times = new List<CarTime>
                        {
                            new CarTime
                            {
                                Year = 2022,
                                Trim = "Competition xDrive Sedan",
                                DriveType = "AWD",
                                Transmission = "8A",
                                ZeroToSixtyTime = 3.0m,
                                QuarterMileTime = 11.1m,
                                QuarterMileSpeed = 124.7m
                            },
                            new CarTime
                            {
                                Year = 2022,
                                Trim = "Sedan",
                                DriveType = "RWD",
                                Transmission = "6M",
                                ZeroToSixtyTime = 3.4m,
                                QuarterMileTime = 11.6m,
                                QuarterMileSpeed = 121.0m
                            },
                            new CarTime
                            {
                                Year = 2021,
                                Trim = "Competition Sedan",
                                DriveType = "RWD",
                                Transmission = "8A",
                                ZeroToSixtyTime = 3.5m,
                                QuarterMileTime = 11.6m,
                                QuarterMileSpeed = 124.0m
                            },
                        }
                    };
                    break;
                case 2:
                    car = new CarDetails
                    {
                        CarId = 2,
                        Make = "Porsche",
                        Model = "911",
                        Times = new List<CarTime>
                        {
                            new CarTime
                            {
                                Year = 2022,
                                Trim = "Carrera 4 GTS Coupe",
                                DriveType = "AWD",
                                Transmission = "8A",
                                ZeroToSixtyTime = 2.8m,
                                QuarterMileTime = 10.9m,
                                QuarterMileSpeed = 126.7m
                            },
                            new CarTime
                            {
                                Year = 2022,
                                Trim = "GT3 Coupe",
                                DriveType = "RWD",
                                Transmission = "6M",
                                ZeroToSixtyTime = 3.3m,
                                QuarterMileTime = 12.5m,
                                QuarterMileSpeed = 124.0m
                            }
                        }
                    };
                    break;
                default:
                    break;
            }

            return Task.FromResult(car);
        }
    }
}
