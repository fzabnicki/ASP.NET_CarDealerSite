using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarDealerTests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        private List<Cars> GetTestProducts()
        {
            var testProducts = new List<Cars>();
            testProducts.Add(new Cars { Id = 1, Name = "Demo1", Price = 1 });
            testProducts.Add(new Cars { Id = 2, Name = "Demo2", Price = 3.75M });
            testProducts.Add(new Cars { Id = 3, Name = "Demo3", Price = 16.99M });
            testProducts.Add(new Cars { Id = 4, Name = "Demo4", Price = 11.00M });

            return testProducts;
        }
    }
}
