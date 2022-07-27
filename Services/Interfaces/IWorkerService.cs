using RepairService.Models;

namespace RepairService.Services.Interfaces

{
    public interface IWorkerService
    {
        public void Create(Worker worker);
        public void Update(Worker worker);
        public void Delete(Guid workerId);
        public ICollection<Worker> GetAll();
    }
}
