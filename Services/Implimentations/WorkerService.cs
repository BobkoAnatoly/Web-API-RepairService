using RepairService.Models;
using RepairService.Services.Interfaces;
using RepairService.Repositiries.Interfaces;

namespace RepairService.Services.Implimentations
{
    public class WorkerService : IWorkerService
    {
        private IBaseRepository<Worker> Workers;
        public WorkerService(IBaseRepository<Worker> workers)
        {
            Workers = workers;
        }

        public void Create(Worker worker)
        {
            Workers.Create(worker);
        }

        public void Delete(Guid id)
        {
            Workers.Delete(id);
        }

        public ICollection<Worker> GetAll()
        {
            return Workers.GetAll();
        }

        public void Update(Worker worker)
        {
            Workers.Update(worker);
        }
    }
}
