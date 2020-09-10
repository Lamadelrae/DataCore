using MoRM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoRM.Create
{
    public static class CreateTables
    {
        public static string CreateTable(this MormTable Table)
        {
            try
            {
                string TableNamePurified = Regex.Replace(Table.TableName, @"[^0-9a-zA-Z:,]+", "");

                string BaseQuery = $"CREATE TABLE @{TableNamePurified} ( ";

                var Query = new StringBuilder();

                Query.Append(BaseQuery);

                foreach (var Column in Table.Column)
                {
                    string ColumnName = Regex.Replace(Column.ColumnName, @"[^0-9a-zA-Z:,]+", "");
                    string ColumnType = Regex.Replace(Column.ColumnType, @"[^0-9a-zA-Z:,]+", "");
                    int ColumnSize = Column.ColumnSize;

                    string ColumnString = $" @{ColumnName} {ColumnType}({ColumnSize}), ";

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
