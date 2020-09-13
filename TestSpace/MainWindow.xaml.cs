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
            using (var Table = new MQB.Entity.MQB())
            {
                Table.Command.Connection = @"Server = Localhost\SQL2019; Database = FM; User Id = sa; Password = pass;";
                Table.TableName = "Person";
                Table.Command.SqlCommand = Table.SelectTable();
                var result = Table.Command.Result();
            }
        }
    }
}
