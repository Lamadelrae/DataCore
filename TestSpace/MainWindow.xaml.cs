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
using System.Data.SqlClient;
using MQB.Builder;

namespace TestSpace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class user
    {
        public string name { get; set; }

        public string password { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var query = new QueryBuilder<user>()
                .Select()
                .Build()
                .GetSqlCommand();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        protected void OnMouseDoubleClick(object sender, EventArgs args)
        {
            var row = sender as DataGridRow;
            if (row != null && row.IsSelected)
                MessageBox.Show("Click");

        }
    }
}
