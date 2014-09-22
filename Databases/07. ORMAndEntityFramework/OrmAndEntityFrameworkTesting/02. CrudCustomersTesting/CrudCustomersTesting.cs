using GenerateNorthwindDBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrmAndEntityFrameworkTesting._02._CrudCustomersTesting
{
    [TestClass]
    public class CrudCustomersTesting
    {
        private NorthwindEntities dbContext = new NorthwindEntities();

        [TestMethod]
        public void ClassInitializationTest()
        {

        }
    }
}
