using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DataCore
{
    public class DataCore<T> where T : class
    {
        private SqlConnection Connection { get; set; }

        public DataCore(SqlConnection connection)
        {
            Connection = connection;
        }

        public void ExecuteCommand(string sql)
        {
            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);
                connection.Open();

                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void ExecuteCommand(string sql, params SqlParameter[] sqlParams)
        {
            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);

                if (sqlParams.Length > 0)
                    sqlCommand.Parameters.AddRange(sqlParams);

                connection.Open();

                sqlCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<T> ExecuteQuery(string sql, params SqlParameter[] sqlParams)
        {
            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);

                if (sqlParams.Length > 0)
                    sqlCommand.Parameters.AddRange(sqlParams);

                connection.Open();

                var dataTable = GetDataTable(sqlCommand);

                connection.Close();

                return GetObjList(dataTable);
            }
        }

        public List<T> ExecuteQuery(string sql)
        {
            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);

                connection.Open();

                var dataTable = GetDataTable(sqlCommand);

                connection.Close();

                return GetObjList(dataTable);
            }
        }

        private DataTable GetDataTable(SqlCommand sqlCommand)
        {
            var dataTable = new DataTable();

            var dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataTable);

            dataAdapter.Dispose();

            return dataTable;
        }

        private List<T> GetObjList(DataTable table)
        {
            try
            {
                List<T> list = new List<T>();

                foreach (DataRow row in table.Rows)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T));

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            var propertyInfo = obj.GetType().GetProperty(prop.Name);

                            var typedValue = Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType);

                            propertyInfo.SetValue(obj, typedValue);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}