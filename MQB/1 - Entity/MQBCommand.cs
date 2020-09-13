using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MQB.Entity
{
    public class MQBCommand
    {
        public string Connection { get; set; }

        public SqlCommand SqlCommand { get; set; }
    }
}
