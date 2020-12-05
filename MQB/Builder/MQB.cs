using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQB.Builder
{
    public class MQB<T>
    {
        public SelectBuilder<T> SelectBuilder { get; set; } = new SelectBuilder<T>();

        public InsertBuilder<T> InsertBuilder { get; set; } = new InsertBuilder<T>();
    }
}
