using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQB.Entity;

namespace MoRM.Update
{
    public static class UpdateTable
    {
        public static string UpdateTables(this MQBTable Table)
        {
            try
            {
                var Query = new StringBuilder();

                string BaseString = $"UPDATE {Table.TableName} SET ";
                Query.Append(BaseString);

                foreach (var Column in Table.Column)
                {
                    string SetString = $"{Column.ColumnName} = {Column.ColumnValue}, ";

                    Query.Append(SetString);
                }

                if(Table.TableTypes.isConditioned)
                {
                    string WhereString = "WHERE ";

                    Query.Append(WhereString);

                    foreach(var Condition in Table.Condition)
                    {
                        string ConditionString = $"{Condition.ConditionName} = ";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
