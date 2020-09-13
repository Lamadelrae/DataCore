using MQB.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Commands
{
    public static class MQBCommands
    {
        public static List<object[]> Result(this MQBCommand Command)
        {
            try
            {
                using (var con = new SqlConnection(Command.Connection))
                {
                    var ListData = new List<object[]>();

                    Command.SqlCommand.Connection = con;

                    con.Open();

                    var reader = Command.SqlCommand.ExecuteReader();


                    while (reader.Read())
                    {
                        var myObject = new object[reader.FieldCount];
                        reader.GetValues(myObject);
                        ListData.Add(myObject);
                    }

                    con.Close();

                    return ListData;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Execute(this MQBCommand Command)
        {
            try
            {
                using (var con = new SqlConnection(Command.Connection))
                {
                    Command.SqlCommand.Connection = con;

                    con.Open();

                    Command.SqlCommand.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
