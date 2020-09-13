using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQB.Entity;

namespace MQB.Update
{
    public static class UpdateTable
    {
        public static SqlCommand UpdateTables(this MQBMain Table)
        {
            try
            {
                var Query = new StringBuilder();

                Query.Append($"UPDATE {Table.TableName} SET ");

                int UpdateCount = 0;
                foreach (var Update in Table.Update)
                {
                    UpdateCount += 1;
                    Query.Append($"{Update.ColumnName} = @ColumnValue{UpdateCount}, ");
                }

                if (Query.ToString().EndsWith(", "))
                    Query.Remove(Query.Length - 2, 1);

                if (Table.TableTypes.isConditioned)
                {
                    Query.Append("WHERE ");

                    int CondtionCount = 0;
                    foreach (var Condition in Table.Condition)
                    {
                        CondtionCount += 1;
                        Query.Append($"{Condition.ConditionName} = @ConditionValue{CondtionCount} AND ");
                    }

                    if (Query.ToString().EndsWith("AND "))
                        Query.Remove(Query.Length - 4, 4);
                }

                //Parameters
                var SqlCommand = new SqlCommand(Query.ToString());

                int UpdateParameterCount = 0;
                foreach (var Update in Table.Update)
                {
                    UpdateParameterCount += 1;

                    SqlCommand.Parameters.AddWithValue($"@ColumnValue{UpdateParameterCount}", Update.ColumnValue);
                }

                if (Table.TableTypes.isConditioned)
                {
                    int ConditionParameterCount = 0;
                    foreach (var Condition in Table.Condition)
                    {
                        ConditionParameterCount += 1;

                        SqlCommand.Parameters.AddWithValue($"@ConditionValue{ConditionParameterCount}", Condition.ConditionValue);
                    }
                }

                return SqlCommand;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
