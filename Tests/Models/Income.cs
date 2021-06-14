using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models
{
    public class Income
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public string Status { get; set; }
    }
}
