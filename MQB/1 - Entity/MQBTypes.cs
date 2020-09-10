using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class MQBTypes
    {
        public enum MQBCrudTypes
        {
            Create,
            Select,
            Update,
            Delete,
        }

        public bool isJoin { get; set; }
        public bool isConditioned { get; set; }
        public bool isSeparteSelect { get; set; }
    }

}
