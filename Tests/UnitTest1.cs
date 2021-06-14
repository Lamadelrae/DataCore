using DataCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Linq;
using Tests.Models;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void SelectMethod()
        {
            DataCore<Income> db = new DataCore<Income>(new SqlConnection(@"Server=Localhost\SQL2019;Database=FinanceManager;User Id=sa;Password=pass123;"));
            Income obj = db.ExecuteQuery("SELECT * FROM Incomes WHERE Id = @Id", new { Id = 1 }).FirstOrDefault();

            Assert.IsTrue(obj != null);
        }

        [TestMethod]
        public void CommandMethod()
        {
            DataCore<Income> db = new DataCore<Income>(new SqlConnection(@"Server=Localhost\SQL2019;Database=FinanceManager;User Id=sa;Password=pass123;"));

            db.ExecuteCommand("UPDATE Incomes SET Description = @Desc WHERE Id = @Id", new { Desc = "Test", Id = 1 });

            Income obj = db.ExecuteQuery("SELECT * FROM Incomes WHERE Id = @Id", new { Id = 1 }).FirstOrDefault();

            Assert.IsTrue(obj.Description == "Test");
        }
    }
}
