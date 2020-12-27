using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Context
{
    public sealed class DbConnection
    {
        private static DbConnection Instance = null;

        public static DbConnection GetInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new DbConnection();

                return Instance;
            }
        }

        DbConnection()
        {
            Connection = new SqlConnection(@"Server=Localhost\SQL2019;Database=FinanceManager;User Id=sa;Password=pass;");
        }

        public SqlConnection Connection { get; private set; }
    }
}
