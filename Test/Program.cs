﻿using DataCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.Context;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DbContext();

            var incomes = context.Incomes.ExecuteQuery("SELECT * FROM Incomes");
        }
    }
}
