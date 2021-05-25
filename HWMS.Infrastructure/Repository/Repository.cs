using System;
using System.Linq;
using System.Threading.Tasks;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HWMS.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _Context;
        protected readonly DbSet<TEntity> _DbSet;
        public Repository(DbContext context)
        {
            this._Context = context;
            this._DbSet = this._Context.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            this._DbSet.Add(obj);
        }

        public void Dispose()
        {
            this._Context.Dispose();
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
            return this._Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return this._Context.SaveChangesAsync();
        }

        public void Update(TEntity obj)
        {
            this._DbSet.Update(obj);
        }
    }
}