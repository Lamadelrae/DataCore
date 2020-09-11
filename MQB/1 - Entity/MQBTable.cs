using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class MQBTable
    {
        public string TableName { get; set; }
        public MQBTypes TableTypes { get; set; }
        public List<MQBUpdate> Update { get; set; }
        public List<MQBCondition> Condition { get; set; }
        public List<MQBJoin> Join { get; set; }
        public List<MQBColumn> Column { get; set; }
    }
}
