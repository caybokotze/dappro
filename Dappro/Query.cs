using System.Collections.Generic;
using System.Data;

namespace Dappro
{
    public abstract class Query<TModel> where TModel : IDbType, new()
    {
        public Query()
        {
            
        }
        public virtual List<TModel> GetAll()
        {
            return new List<TModel>();
        }

        public virtual TModel GetById(int id)
        {
            return new TModel();
        }

        public virtual TModel Update(TModel model)
        {
            return new TModel();
        }

        public virtual int Delete(TModel model)
        {
            return 0;
        }
    }

    public interface IDbType
    {
        public Databases DbType { get; set; }
    }
}