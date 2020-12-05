using MQB.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Builder
{
    public class SelectBuilder<T> : SelectObject
    {
        private string TableName { get; set; } = typeof(T).Name;

        public SelectBuilder<T> Select(params string[] columns)
        {
            base.IsRaw = false;

            if (columns.Count() == 0)
                base.Select = "*";
            else
            {
                foreach (var column in columns)
                    base.Select += $"{column}, ";
            }

            if (base.Select.Trim().EndsWith(","))
                base.Select = base.Select.Remove(base.Select.Length - 2, 1).Trim();

            return this;
        }

        public SelectBuilder<T> RawSelect(string select)
        {
            base.IsRaw = true;
            base.Select = select;

            return this;
        }

        public SelectBuilder<T> Join(string join)
        {
            base.Join = join;

            return this;
        }

        public SelectBuilder<T> Where(string where, params SqlParameter[] sqlParameters)
        {
            foreach (var param in sqlParameters)
                SqlParameters.Add(param);

            base.Where = where;

            return this;
        }

        public SelectBuilder<T> Build()
        {
            string baseQuery = string.Empty;

            if (!IsRaw)
            {
                baseQuery += "SELECT ";

                if (string.IsNullOrEmpty(base.Select) != true)
                    baseQuery += $"{base.Select} ";

                baseQuery += $"FROM {TableName} ";
            }
            else
                baseQuery += base.Select;

            if (string.IsNullOrEmpty(base.Join) != true)
                baseQuery += $"{base.Join} ";
            if (string.IsNullOrEmpty(base.Where) != true)
            {
                baseQuery += $"WHERE {base.Where} ";
            }

            BaseQuery = baseQuery;

            return this;
        }

        public SqlCommand GetSqlCommand()
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.CommandText = base.BaseQuery;

            base.SqlParameters.ForEach(param =>
            {
                sqlCommand.Parameters.Add(param);
            });

            return sqlCommand;
        }
    }
}
