﻿using Microsoft.AspNetCore.Mvc;
using RepairService.Models;
using RepairService.Repositiries.Interfaces;
using RepairService.Services.Interfaces;

namespace RepairService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController :ControllerBase
    {
        private IRepairService RepairService;
        private IBaseRepository<Document> Documents;

        public MainController(IRepairService repairService, IBaseRepository<Document> document)
        {
            RepairService = repairService;
            Documents = document;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Documents.GetAll());
        }

        [HttpPost]
        public JsonResult Post()
        {
            RepairService.Work();
            return new JsonResult("Work was successfully done");
        }

        [HttpPut]
        public JsonResult Put(Document doc)
        {
            bool success = true;
            var document = Documents.Get(doc.Id);
            try
            {
                if (document != null)
                    document = Documents.Update(doc);
                else
                    success = false;
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {document.Id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            bool success = true;
            var document = Documents.Get(id);

            try
            {
                if (document != null)
                    Documents.Delete(document.Id);
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
