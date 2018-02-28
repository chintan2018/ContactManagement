using System.Collections.Generic;
using ContactModel.POCOClasses;

namespace ContactModel.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entityType);
        void Update(T entityType);
        void Delete(T entityType);
        int SaveChanges();
    }
}
