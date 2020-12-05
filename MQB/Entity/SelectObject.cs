using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class SelectObject
    {
        protected string Select { get; set; }

        protected bool IsRaw { get; set; }

        protected string Join { get; set; }

        protected string Where { get; set; }

        public string BaseQuery { get; set; }

        protected List<SqlParameter> SqlParameters { get; set; } = new List<SqlParameter>();
    }
}
