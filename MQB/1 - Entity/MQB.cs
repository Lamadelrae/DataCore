using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class MQB : IDisposable
    {
        public string TableName { get; set; }

        public MQBTypes TableTypes = new MQBTypes();

        public List<MQBUpdate> Update = new List<MQBUpdate>();

        public List<MQBCondition> Condition = new List<MQBCondition>();

        public List<MQBJoin> Join = new List<MQBJoin>();

        public List<MQBColumn> Column = new List<MQBColumn>();

        public MQBCommand Command = new MQBCommand();

        private bool isDisposed = false;

        public MQB()
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
