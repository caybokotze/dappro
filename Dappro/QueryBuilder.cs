using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dappro
{
    public class QueryBuilder<TModel> : Query<TModel>
    {
        public QueryBuilder(string connectionString)
        {
            
        }

        public string GetInsertQuery(string[] props, string table)
        {
            string query = "";
            query = $"INSERT INTO {table} (";
            
            foreach(var item in props)
            {
                query += item;
            }
        }
    }

    public interface IMsSql
    {
    }
}