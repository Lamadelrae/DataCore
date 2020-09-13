using MQB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MQB.Create
{
    public static class CreateTables
    {
        public static string CreateTable(this MQBMain Table)
        {
            try
            {
                string BaseQuery = $"CREATE TABLE {Table.TableName} ( ";

                var Query = new StringBuilder();

                Query.Append(BaseQuery);

                foreach (var Column in Table.Column)
                {
                    int ColumnSize = Column.ColumnSize;

                    string ColumnString = $" {Column.ColumnName} {Column.ColumnType}({Column.ColumnSize}), ";

                    Query.Append(ColumnString);
                }

                if (Query.ToString().EndsWith(", "))
                    Query.Remove(Query.Length - 2, 2);

                string EndQuery = " )";

                Query.Append(EndQuery);

                return Query.ToString();
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

    }
}
