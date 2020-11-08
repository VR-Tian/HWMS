using System;
using System.Linq;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly OrderContext _OrderContext;
        protected readonly DbSet<TEntity> _DbSet;
        public Repository(OrderContext OrderContext)
        {
            this._OrderContext = OrderContext;
            this._DbSet = this._OrderContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            this._DbSet.Add(obj);
        }

        public void Dispose()
        {
            this._OrderContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this._DbSet;
        }

        public TEntity GetById(Guid id)
        {
            return this._DbSet.Find(id);
        }

        public void Remove(Guid id)
        {
            this._DbSet.Remove(GetById(id));
        }

        public int SaveChanges()
        {
            return this._OrderContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            this._DbSet.Update(obj);
        }
    }
}