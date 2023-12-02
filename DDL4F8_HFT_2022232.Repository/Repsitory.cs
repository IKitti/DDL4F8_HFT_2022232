using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDL4F8_HFT_2022232.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected PetsDbContext ctx;
        public Repository(PetsDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }
        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }
        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}

