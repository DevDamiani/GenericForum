using System;
using System.Collections.Generic;
using GenericForum.Model.Entity;

namespace GenericForum.Model.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        public IEnumerable<T> GetAll();
        public T GetByID(int id);
        public void Update(T data);
        public void Add(T data);
        public void Remove(T data);
        public int TotalOfRows();
        public IEnumerable<T> FilterWhere(Func<T, bool> condition);

    }
}
