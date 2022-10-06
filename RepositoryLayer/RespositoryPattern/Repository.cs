using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.RespositoryPattern
{  
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {  
   
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;
       

        public Repository(ApplicationDbContext applicationDbContext)
        {  
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }  
   

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {  
            if (entity == null)
            {  
                throw new ArgumentNullException("entity");
            }  
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public T Get(int Id)
        {  
            return entities.SingleOrDefault(c => c.Id == Id);
        }  
  
        public IEnumerable<T> GetAll()
        {  
            return entities.AsEnumerable();
        }  
  
        public void Insert(T entity)
        {  
            if (entity == null)
            {  
                throw new ArgumentNullException("entity");
            }  
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }
    }  
}


