using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Entity
{
    public class MQBJoin
    {
        public string TableName { get; set; }

        public string TableJoin { get; set; }

        public string TableNameIndex { get; set; }

        public string TableJoinIndex { get; set; }

        private bool isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (Disposing)
            {
                Dispose();
            }
            isDisposed = true;
        }
    }
}
