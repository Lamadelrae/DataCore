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

            var Table = new MQBTable
            { 
                TableName = "Matthew",
                Update = new List<MQBUpdate>
                {
                    new MQBUpdate {ColumnName = "AAAAA", ColumnValue = "AAAAAA"}
                },
                Condition = new List<MQBCondition>
                {
                    new MQBCondition { ConditionName = "Column", ConditionValue = "Valueee"}
                },
                TableTypes = new MQBTypes 
                {
                    isJoin = false,
                    isSeparteSelect = false,
                    isConditioned = true
                }
            }.UpdateTables();

            var debug = Table;
        }
    }
}
