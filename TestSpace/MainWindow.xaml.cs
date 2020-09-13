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
using MQB.Commands;
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
            using (var Table = new MQBMain())
            {
                Table.Command.Connection = @"Server = Localhost\SQL2019; Database = FM; User Id = sa; Password = pass;";
                Table.TableName = "Person";
                Table.Update.Add(new MQBUpdate { ColumnName= "PersonName", ColumnValue = "Kekekeke"});
                Table.TableTypes.isConditioned = true;
                Table.Condition.Add(new MQBCondition { ConditionName = "UUID", ConditionValue = "87D09E3A-A0F0-452E-90B6-06F71859C5C3" });

                var a = Table.UpdateTables();

                Table.Command.SqlCommand = a;

                Table.Command.Execute();
            }
        }
    }
}
