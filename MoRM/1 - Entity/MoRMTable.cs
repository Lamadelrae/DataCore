﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoRM.Entity
{
    public class MormTable
    {
        public string TableName { get; set; }

        public List<MoRMColumn> Column { get; set; }
    }
}
