using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace DataCore
{
    public static class SqlParam
    {
        public static SqlParameter CreateParam(string param, object value)
        {
            return new SqlParameter($"@{param}", value);
        }
    }
}
