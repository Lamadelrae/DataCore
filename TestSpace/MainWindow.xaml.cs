﻿using System;
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
using MoRM.Create;
using MoRM.Read;
using MoRM.Entity;

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

            var Table = new MormTable
            { 
                TableName = "Matthew",
                Column = new List<MoRMColumn>
                {
                    new MoRMColumn { ColumnName = "HelloWorld"},
                    new MoRMColumn { ColumnName = "HelloWorld"},
                    new MoRMColumn { ColumnName = "HelloWorld" }
                },
                TableJoin = new List<MoRMJoin>
                { 
                    new MoRMJoin { TableName = "Matthew", TableJoin = "Carol", TableNameIndex = "IdMatthew", TableJoinIndex = "IdCarol"}
                },
                TableTypes = new MoRMTypes 
                {
                    isJoin = false,
                    isSeparteSelect = false
                }
            }.SelectTable();

            var debug = Table;
        }
    }
}
