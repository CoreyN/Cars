using Cars.Dtos;
using Dapper;
using System.Data.SqlClient;

namespace Cars.Repositories
{
    public class SqlCarRepository : ICarRepository
    {
        const string ConnectionString = "Data Source=.; Initial Catalog=Cars; Integrated Security=false; User=sa; Password=ChangeM3!;";

        public async Task<IReadOnlyList<CarSummary>> GetCarsAsync()
        {
            using var con = new SqlConnection(ConnectionString);
            con.Open();

            var results =  await con.QueryAsync<CarSummary>(@"SELECT Id, Make, Model FROM Car;");

            return results.ToList();
        }

        public async Task<CarDetails?> GetCarAsync(int id)
        {
            using var con = new SqlConnection(ConnectionString);
            con.Open();

            var sql = @"
                SELECT Id, Make, Model
                FROM Car
                WHERE Id = @id;

                SELECT [Year], [Trim], DriveType, Transmission, ZeroToSixtyTime, QuarterMileTime, QuarterMileSpeed
                FROM CarTime
                WHERE CarId = @id
                ORDER BY [Year] DESC, [TRIM], DriveType, Transmission;
            ";

            var results = await con.QueryMultipleAsync(sql, new { id });

            var car = (await results.ReadAsync<dynamic>()).SingleOrDefault();
            var times = await results.ReadAsync<CarTime>();

            if (car is null)
                return null;

            return new CarDetails
            {
                CarId = (int)car.Id,
                Make = (string)car.Make,
                Model = (string)car.Model,
                Times = times.ToList()
            };
        }
    }
}
