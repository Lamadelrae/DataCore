using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MQB.Create;
using MQB.Read;
using MQB.Entity;
using MQB.Update;
using System.Data.SqlClient;

namespace TestSpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var Table = new MQBTable())
            {
                Table.TableName = "Person";
                Table.TableTypes.isSeparteSelect = true;
                Table.TableTypes.isConditioned = true;
                Table.Column.Add(new MQBColumn { ColumnName = "UUID" });
                Table.Condition.Add(new MQBCondition { ConditionName = "PersonName", ConditionValue = "Matthew"});

                var sql = Table.SelectTable();

                using (var con = new SqlConnection(@"Server=Localhost\SQL2019;Database=FM;User Id=sa;Password=pass;"))
                {
                    sql.Connection = con;
                    con.Open();
                    var reader = sql.ExecuteReader();

                    string test = string.Empty;
                    while (reader.Read())
                    {
                        test = reader[0].ToString();
                    }
                }
            }
        }
    }
}
