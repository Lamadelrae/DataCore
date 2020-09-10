using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoRM.Entity;

namespace MoRM.Read
{
    public static class SelectTables
    {
        public static string SelectTable(this MormTable Table)
        {
            try
            {
                var Query = new StringBuilder();

                var Base = new StringBuilder();

                if (Table.TableTypes.isSeparteSelect)
                {
                    Base.Append($"SELECT ");
                    foreach (var ColumnObj in Table.Column)
                    {
                        string ColumnString = $"@{ColumnObj.ColumnName} ";

                        Base.Append(ColumnString);
                    }

                    string TableString = $"FROM @{Table.TableName} ";

                    Base.Append(TableString);
                }
                else
                {
                    string BaseString = $"SELECT * FROM {Table.TableName} ";

                    Base.Append(BaseString);
                }

                if (Table.TableTypes.isJoin)
                {
                    foreach (var JoinObj in Table.Join)
                    {
                        string JoinString = $"JOIN {JoinObj.TableJoin} ON {JoinObj.TableName}.{JoinObj.TableNameIndex} = {JoinObj.TableJoin}.{JoinObj.TableNameIndex} ";

                        Base.Append(JoinString);
                    }
                }

                if (Table.TableTypes.isConditioned)
                {
                    string BaseConditionString = "WHERE ";

                    Base.Append(BaseConditionString);

                    foreach (var Condition in Table.Condition)
                    {
                        string ConditionString = $"{Condition.ConditionName} = '{Condition.ConditionValue}' AND ";

                        Base.Append(ConditionString);
                    }

                    if (Base.ToString().EndsWith("AND "))
                        Base.Remove(Base.Length - 4, 3);
                }

                return Base.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
