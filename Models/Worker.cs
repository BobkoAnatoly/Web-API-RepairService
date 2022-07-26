using RepairService.Models.Base;

namespace RepairService.Models
{
    public class Worker:BaseModel
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
    }
}
