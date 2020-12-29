using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCore;

namespace Test.Context
{
    public class DbContext : DbConnection
    {
        public DataCore<Incomes> Incomes { get; set; } = new DataCore<Incomes>(new DbConnection().Connection);
    }
}
