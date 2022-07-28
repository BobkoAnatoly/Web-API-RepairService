using Microsoft.EntityFrameworkCore;
using RepairService.Database;
using RepairService.Models.Base;
using RepairService.Repositiries.Interfaces;

namespace RepairService.Repositiries.Implimentations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        private ApplicationContext Context { get; set; }
        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }
        public TDbModel Create(TDbModel model)
        {
            if (model != null)
            {
                //Set() возвращает DbSet сущности
                Context.Set<TDbModel>().Add(model);
                Context.SaveChanges();
                return model;
            }
            throw new Exception();
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<TDbModel>()
                .FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
                Context.Set<TDbModel>().Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public TDbModel Get(Guid id)
        {
            var toGet = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            return toGet;
        }

        public List<TDbModel> GetAll()
        {
            return Context.Set<TDbModel>()
                .AsNoTracking()
                .ToList();
        }

        public TDbModel Update(TDbModel model)
        {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null)
            {
                toUpdate = model;
                Context.Update(toUpdate);
                Context.SaveChanges();
                return toUpdate;
            }
            throw new Exception();
        }
    }
}
