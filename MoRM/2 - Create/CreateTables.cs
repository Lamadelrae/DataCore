using MoRM._1___Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoRM
{
    public class CreateTables
    {
        public string CreateTable(string TableName, List<ColumnEntity> ColumnObj)
        {
            string BaseQuery = $"CREATE TABLE @{Regex.Replace(TableName, @"[^0-9a-zA-Z:,]+", "")}( ";
            
            var Query = new StringBuilder();

            Query.Append(BaseQuery);

            foreach(var Column in ColumnObj)
            {
                string ColumnQuery = $"@{Regex.Replace(Column.ColumnName, @"[^0-9a-zA-Z:,]+", "")} @{Regex.Replace(Column.ColumnType, @"[^0-9a-zA-Z:,]+", "")}(@{Column.ColumnSize})";
                Query.Append(ColumnQuery);
            }

            return Query.ToString();
        }
    }
}
