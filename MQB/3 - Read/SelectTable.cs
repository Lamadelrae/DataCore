using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQB.Entity;

namespace MQB.Read
{
    public static class SelectTables
    {
        public static string SelectTable(this MQBTable Table)
        {
            try
            {
                var Query = new StringBuilder();

                if (Table.TableTypes.isSeparteSelect)
                {
                    Query.Append($"SELECT ");
                    foreach (var ColumnObj in Table.Column)
                    {
                        string ColumnString = $"{ColumnObj.ColumnName} ";

                        Query.Append(ColumnString);
                    }

                    string TableString = $"FROM {Table.TableName} ";

                    Query.Append(TableString);
                }
                else
                {
                    string BaseString = $"SELECT * FROM {Table.TableName} ";

                    Query.Append(BaseString);
                }

                if (Table.TableTypes.isJoin)
                {
                    foreach (var JoinObj in Table.Join)
                    {
                        string JoinString = $"JOIN {JoinObj.TableJoin} ON {JoinObj.TableName}.{JoinObj.TableNameIndex} = {JoinObj.TableJoin}.{JoinObj.TableNameIndex} ";

                        Query.Append(JoinString);
                    }
                }

                if (Table.TableTypes.isConditioned)
                {
                    string BaseConditionString = "WHERE ";

                    Query.Append(BaseConditionString);

                    foreach (var Condition in Table.Condition)
                    {
                        string ConditionString = $"{Condition.ConditionName} = '{Condition.ConditionValue}' AND ";

                        Query.Append(ConditionString);
                    }

                    if (Query.ToString().EndsWith("AND "))
                        Query.Remove(Query.Length - 4, 3);
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
