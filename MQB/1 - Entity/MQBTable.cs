using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class MQBTable : IDisposable
    {
        public string TableName { get; set; }

        public MQBTypes TableTypes = new MQBTypes();

        public List<MQBUpdate> Update = new List<MQBUpdate>();

        public List<MQBCondition> Condition = new List<MQBCondition>();

        public List<MQBJoin> Join = new List<MQBJoin>();

        public List<MQBColumn> Column = new List<MQBColumn>();

        private bool isDisposed = false;
        public MQBTable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (disposing)
            {
                Dispose();
            }

            isDisposed = true;
        }
    }
}
