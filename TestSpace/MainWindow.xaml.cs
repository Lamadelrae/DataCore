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
                Table.TableName = "EXC110";
                Table.TableTypes.isConditioned = true;
                Table.Update.Add(new MQBUpdate { ColumnName = "C110_CTR", ColumnValue = "9000"});
                Table.Condition.Add(new MQBCondition { ConditionName = "C110_NUMCONTROLE", ConditionValue = "902882"});

               string Query =  Table.UpdateTables();
            }
        }
    }
}
