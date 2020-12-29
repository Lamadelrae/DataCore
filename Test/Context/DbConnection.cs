using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Context
{
    public class DbConnection
    {
        public SqlConnection Connection { get; private set; } = new SqlConnection(@"Server=Localhost\SQL2019;Database=FinanceManager;User Id=sa;Password=pass;");
    }
}
