using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

                    for (int i = 0; i <= Table.Column.Count; i++)
                        Query.Append($"@Column{i}");

                    Query.Append("FROM @TableName ");
                }
                else
                    Query.Append("SELECT * FROM @TableName ");


                if (Table.TableTypes.isJoin)
                {
                    for (int i = 0; i <= Table.Join.Count; i++)
                        Query.Append($"JOIN @TableJoin{i} ON @TableName{i}.@TableNameIndex{i} = @TableJoin{i}.@TableJoinIndex{i}");
                }

                if (Table.TableTypes.isConditioned)
                {
                    Query.Append("WHERE ");

                    for (int i = 0; i <= Table.Condition.Count; i++)
                        Query.Append($"@ConditionName{i} = @ConditionValue{i} AND ");

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
