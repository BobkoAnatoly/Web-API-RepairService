using RepairService.Models;
using RepairService.Repositiries.Interfaces;
using RepairService.Services.Interfaces;

namespace RepairService.Services.Implimentations
{
    public class RepairService : IRepairService
    {
        private IBaseRepository<Document> Documents;
        private IBaseRepository<Car> Cars;
        private IBaseRepository<Worker> Workers;

        public RepairService(IBaseRepository<Document> documents,
            IBaseRepository<Car> cars,
            IBaseRepository<Worker> workers)
        {
            Documents = documents;
            Cars = cars;
            Workers = workers;
        }
        public void Work()
        {
            var rand = new Random();
            var carId = Guid.NewGuid();
            var workerId = Guid.NewGuid();

            Cars.Create(new Car
            {
                Id = carId,
                Name = String.Format($"Car{rand.Next()}"),
                Number = String.Format($"{rand.Next()}")
            });

            Workers.Create(new Worker
            {
                Id = workerId,
                Name = String.Format($"Worker{rand.Next()}"),
                Position = String.Format($"Position{rand.Next()}"),
                Phone = String.Format($"8916{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}{rand.Next()}")
            });

            var car = Cars.Get(carId);
            var worker = Workers.Get(workerId);

            Documents.Create(new Document
            {
                CarId = car.Id,
                WorkerId = worker.Id,
                Car = car,
                Worker = worker
            });
        }
    }
}
