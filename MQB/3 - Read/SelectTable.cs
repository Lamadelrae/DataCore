using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MQB.Entity;


namespace MQB.Read
{
    public static class SelectTables
    {
        public static SqlCommand SelectTable(this Entity.MQB Table)
        {
            try
            {
                var Query = new StringBuilder();

                if (Table.TableTypes.isSeparteSelect)
                {
                    Query.Append($"SELECT ");

                    foreach (var Column in Table.Column)
                    {
                        Query.Append($"{Column.ColumnName} ");
                    }

                    Query.Append($"FROM {Table.TableName} ");
                }
                else
                    Query.Append($"SELECT * FROM {Table.TableName} ");

                if (Table.TableTypes.isJoin)
                {
                    foreach (var Join in Table.Join)
                        Query.Append($"JOIN {Join.TableJoin} ON {Join.TableJoin}.{Join.TableJoinIndex} = {Join.TableName}.{Join.TableNameIndex}");
                }

                if (Table.TableTypes.isConditioned)
                {
                    Query.Append("WHERE ");

                    int i = 0;
                    foreach (var Condition in Table.Condition)
                    {
                        i += 1;
                        Query.Append($"{Condition.ConditionName} = @ConditionValue{i} AND ");
                    }

                    if (Query.ToString().EndsWith("AND "))
                        Query.Remove(Query.Length - 4, 3);
                }

                //Parameters
                var SqlCommand = new SqlCommand(Query.ToString());

                if (Table.TableTypes.isConditioned)
                {
                    int i = 0;
                    foreach (var Value in Table.Condition)
                    {
                        i += 1;
                        SqlCommand.Parameters.AddWithValue($"@ConditionValue{i}", Value.ConditionValue);
                    }
                }

                return SqlCommand;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<object[]> Result(this MQBCommand Connection)
        {
            try
            {
                using (var con = new SqlConnection(Connection.Connection))
                {
                    Connection.SqlCommand.Connection = con;

                    con.Open();
                    var reader = Connection.SqlCommand.ExecuteReader();

                    var ListData = new List<object[]>();

                    while (reader.Read())
                    {
                        var myObject = new object[reader.FieldCount];
                        reader.GetValues(myObject);
                        ListData.Add(myObject);
                    }

                    return ListData;
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
