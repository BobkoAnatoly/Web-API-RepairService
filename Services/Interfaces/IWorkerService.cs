using RepairService.Models;

namespace RepairService.Services.Interfaces

{
    public interface IWorkerService
    {
        public void Create(Worker worker);
        public void Update(Worker worker);
        public void Delete(int workerId);
        public ICollection<Worker> GetAll();
    }
}
