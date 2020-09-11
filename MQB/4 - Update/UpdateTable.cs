using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQB.Entity;

namespace MQB.Update
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

                foreach (var Update in Table.Update)
                {
                    string SetString = $"{Update.ColumnName} = '{Update.ColumnValue}', ";

                    Query.Append(SetString);
                }

                if (Query.ToString().EndsWith(", "))
                    Query.Remove(Query.Length - 2, 1);

                if (Table.TableTypes.isConditioned)
                {
                    string WhereString = "WHERE ";

                    Query.Append(WhereString);

                    foreach (var Condition in Table.Condition)
                    {
                        string ConditionString = $"{Condition.ConditionName} = '{Condition.ConditionValue}' AND ";

                        Query.Append(ConditionString);
                    }

                    if (Query.ToString().EndsWith("AND "))
                        Query.Remove(Query.Length - 4, 4);
                }

                return Query.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
