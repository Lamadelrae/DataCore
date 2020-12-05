using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class QueryObject
    {

        protected string Select { get; set; }

        protected string Join { get; set; }

        protected string Where { get; set; }

        protected string BaseQuery { get; set; }

        protected List<SqlParameter> SqlParameters { get; set; } = new List<SqlParameter>();
    }
}
