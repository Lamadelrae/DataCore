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

                Query.Append("UPDATE @TableName SET ");

                for (int i = 0; i == Table.Update.Count - 1; i++)
                    Query.Append($"@Column{i} = @Column{i}, ");
                

                if (Query.ToString().EndsWith(", "))
                    Query.Remove(Query.Length - 2, 1);

                if (Table.TableTypes.isConditioned)
                {
                    Query.Append("WHERE ");

                    for (int i = 0; i == Table.Condition.Count - 1; i++)
                        Query.Append($"@Column{i} = @Column{i} AND ");

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
