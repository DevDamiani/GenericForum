

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GenericForum.Model.Entity;
using GenericForum.Model.Interfaces.Repositories;

namespace GenericForum.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected ForumGenericContext DbContext { get; }
        protected DbSet<T> DbSet { get; }

        public BaseRepository(ForumGenericContext forumGenericContext)
        {
            DbContext = forumGenericContext;
            DbSet = forumGenericContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual T GetByID(int id)
        {
            return DbSet.FirstOrDefault(t => t.ID == id);
        }

        public virtual void Update(T data)
        {
            DbSet.Update(data);
            DbContext.SaveChanges();
        }

        public virtual void Add(T data)
        {
            DbSet.Add(data);
            DbContext.SaveChanges();
        }

        public virtual void Remove(T data)
        {
            DbSet.Remove(data);
            DbContext.SaveChanges();
        }

        public virtual int TotalOfRows()
        {
            return DbSet.Count();
        }

        public virtual IEnumerable<T> FilterWhere(Func<T, bool> condition)
        {

            return DbSet.Where(condition);

             
        }

    }
}
