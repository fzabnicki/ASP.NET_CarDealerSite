using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ASP.NET_Car.Models;
using Moq;
using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Controllers;
using ASP.NET_Car.API_Logic;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCars_ShouldReturnAllCarsInDb()
        {
            //arrange
            List<Cars> testList = GetAllCars();
            var repo = new Mock<ICarRepository>();
            repo.Setup(repo => repo.GetCars()).Returns(GetAllCars());
            var controller = new CarController(repo.Object);

            //act
            var result = controller.Index();

            //assert
            Assert.IsInstanceOfType(result,System.Type.GetType("ViewResult"));
            
        }

        private List<Cars> GetAllCars()
        {
            var testProducts = new List<Cars>();
            testProducts.Add(new Cars { ID = 5, Brand = "Audi", Model="Rs3", Price = 175000.00m, ProductionDate = new System.DateTime(2014,11,10) });
            testProducts.Add(new Cars { ID = 6, Brand = "Mercedes", Model="CLS 45", Price = 147500.00m, ProductionDate = new System.DateTime(2017,08,08) });
            testProducts.Add(new Cars { ID = 7, Brand = "Toyota", Model= "Yaris", Price = 47800.00m, ProductionDate = new System.DateTime(2020,02,01) });
            testProducts.Add(new Cars { ID = 7, Brand = "Audi", Model= "A2", Price = 74000.00m, ProductionDate = new System.DateTime(2018,02,02) });
            return testProducts;
        }
    }
}
