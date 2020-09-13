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

        public MQBTypes TableTypes { get; set; }

        public List<MQBUpdate> Update { get; set; }

        public List<MQBCondition> Condition { get; set; }

        public List<MQBJoin> Join { get; set; }

        public List<MQBColumn> Column { get; set; }

        public MQBCommand Command { get; set; }

        private bool isDisposed = false;

        public MQB()
        {
            Dispose(false);

            TableTypes = new MQBTypes();

            Update = new List<MQBUpdate>();

            Condition = new List<MQBCondition>();

            Join = new List<MQBJoin>();

            Column = new List<MQBColumn>();

            Command = new MQBCommand();
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
