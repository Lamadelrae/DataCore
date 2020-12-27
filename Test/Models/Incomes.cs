using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Incomes
    {
        public Incomes(DataRow row = null)
        {
            Id = (int)row["Id"];
            User_Id = (int)row["User_Id"];
            Description = (string)row["Description"];
            Value = (decimal)row["Value"];
        }

        public Incomes() { }

        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }
}
