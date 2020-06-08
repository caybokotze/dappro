using System;
using System.Collections.Generic;

namespace Dappro
{
    public class GenericDataAccess<TModel> where TModel : class
    {
        private readonly IConfiguration _configuration;

        private readonly string _table;

        //--
        private readonly Type _type = typeof(TModel);

        private Dictionary<string, object> _properties = new Dictionary<string, object>();
        private SupportedDbs _supportedDbs;

        public GenericDataAccess(IConfiguration configuration, string table, SupportedDbs dbms)
        {
            _configuration = configuration;
            _table = table;
            _supportedDbs = dbms;
        }

        public List<TModel> GetAll
        {
            get
            {
                using (var connection =
                    new MySqlConnection(Helper.GetConnectionString(_configuration)))
                {
                    return connection.Query<TModel>($"SELECT * FROM {_table}").ToList();
                }
            }
        }

        public List<string> GetTypeProperties()
        {
            var propertyInfo = new List<string>();
            foreach (var item in _type.GetProperties()) propertyInfo.Add(item.Name);

            return propertyInfo;
        }

        public string GetSqlArguments()
        {
            var statement = "";
            foreach (var item in GetTypeProperties()) statement += item + ",";

            return statement.TrimEnd(',');
        }

        public string GetAnnotatedSqlArguments()
        {
            var statement = "";
            foreach (var item in GetTypeProperties()) statement += "@" + item + ",";

            return statement.TrimEnd(',');
        }

        public virtual int Insert(TModel model)
        {
            // using (IDbConnection connection =
            //     new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(_configuration)))
            // {
            //     List<TModel> list = new List<TModel>();
            //     list.Add(model);
            //
            //     return connection.Execute(
            //         $"INSERT INTO {_table} ({GetSqlArguments()}) " +
            //         $"VALUES ({GetAnnotatedSqlArguments()})", list);
            // }
            // just trying to get stuff to compile with MySql.Data only
            throw new NotImplementedException();
        }

        public virtual int InsertRange(IEnumerable<TModel> models)
        {
            // using (IDbConnection connection =
            //     new System.Data.SqlClient.SqlConnection(Helper.GetConnectionString(_configuration)))
            // {
            //     return connection.Execute($"INSERT INTO {_table} ({GetSqlArguments()}) " +
            //                               $"VALUES ({GetAnnotatedSqlArguments()})", models);
            // }
            throw new NotImplementedException();
        }
    }
}