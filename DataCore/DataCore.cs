using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataCore
{
    public class DataCore
    {
        private SqlConnection Connection { get; set; } = new SqlConnection();

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

        public List<T> ExecuteQuery<T>(string sql, params SqlParameter[] sqlParams)
        {
            var list = new List<T>();

            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);

                if (sqlParams.Length > 0)
                    sqlCommand.Parameters.AddRange(sqlParams);

                connection.Open();

                var dataTable = GetDataTable(sqlCommand);

                connection.Close();

                foreach (var row in dataTable.Rows)
                {
                    T item = (T)Activator.CreateInstance(typeof(T), row);

                    list.Add(item);
                }

                return list;
            }
        }

        public List<T> ExecuteQuery<T>(string sql)
        {
            var list = new List<T>();

            using (var connection = Connection)
            {
                var sqlCommand = new SqlCommand(sql, connection);

                connection.Open();

                var dataTable = GetDataTable(sqlCommand);

                connection.Close();

                foreach (var row in dataTable.Rows)
                {
                    T item = (T)Activator.CreateInstance(typeof(T), row);

                    list.Add(item);
                }

                return list;
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
    }
}
