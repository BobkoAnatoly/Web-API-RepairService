using RepairService.Models.Base;

namespace RepairService.Models
{
    public class Car :BaseModel
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
