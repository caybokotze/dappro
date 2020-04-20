using System;
using Dapper;

namespace Dappro
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public virtual T Insert(T t)
        {
            ConventionalMapper<T> mapper = new ConventionalMapper<T>();
            string[] values = mapper.GetProperties();
            
        }

        public virtual T Update(T t)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Execute(string command)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository<T> where T : class
    {
        public T Insert(T t);
        public T Update(T t);
        public void Delete(T t);
        public T GetById(int id);
        public void Execute(string command);
    }
}