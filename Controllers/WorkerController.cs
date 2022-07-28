using Microsoft.AspNetCore.Mvc;
using RepairService.Models;
using RepairService.Repositiries.Implimentations;
using RepairService.Repositiries.Interfaces;
using RepairService.Services.Interfaces;

namespace RepairService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private IWorkerService WorkerService;
        private IBaseRepository<Worker> Workers;

        public WorkerController(IWorkerService workerService,
            IBaseRepository<Worker> workers)
        {
            WorkerService = workerService;
            Workers = workers;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Workers.GetAll());
        }

        [HttpPost]
        public JsonResult Post(Worker worker) 
        {
            WorkerService.Create(worker);
            return new JsonResult("Creating was successfully done");
        }

        [HttpPut]
        public JsonResult Put(Worker workerVm)
        {
            bool success = true;
            var worker = Workers.Get(workerVm.Id);
            try
            {
                if (worker != null)
                    worker = Workers.Update(workerVm);
                else
                    success = false;
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {worker.Id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete]
        public JsonResult Delete(Guid id) 
        {
            bool success = true;
            var worker = Workers.Get(id);
            try
            {
                if (worker != null)
                    Workers.Delete(worker.Id);
                else
                    success = false;
            }
            catch (Exception)
            {
                success = false;
            }
            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}
