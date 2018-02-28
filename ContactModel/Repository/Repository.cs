using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactModel.POCOClasses;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace ContactModel.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        DatabaseContext context;
        DbSet<T> entities;

        public Repository(DatabaseContext dbContext)
        {
            context = dbContext;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if(entity == null)
            {
                throw new System.ArgumentNullException("Entity is required for insert operation to perform");
            }

            entities.Add(entity);
            this.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException("Entity is required for update operation to perform");
            }
            this.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new System.ArgumentNullException("Entity is required for delete operation to perform");
            }
            entities.Remove(entity);
            this.SaveChanges();
        }

        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }
    }
}
