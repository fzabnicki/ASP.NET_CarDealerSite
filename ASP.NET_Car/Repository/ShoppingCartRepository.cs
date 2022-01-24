using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _context;
        private readonly ICarRepository _carContext;
        private readonly IUserRepository _userContext;
        public ShoppingCartRepository(DataContext context, ICarRepository carContext, IUserRepository userContext)
        {
            _context = context;
            _carContext = carContext;
            _userContext = userContext;
        }
        public Cars AddToBucket(int userID, int carID)
        {
            var user = _userContext.Find(userID);
            var car = _carContext.GetCar(carID);
            user.ShoppingCart.ShoppingList.Add(car);
            _context.SaveChanges();
            return car;
        }

        public void ClearBucket(int userID)
        {
            var user = _userContext.Find(userID);
            user.ShoppingCart.ShoppingList.Clear();
            _context.SaveChanges();
        }

        public void RemoveFromBucket(int userID, int carID)
        {
            var user = _userContext.Find(userID);
            var car = _carContext.GetCar(carID);
            user.ShoppingCart.ShoppingList.Remove(car);
            _context.SaveChanges();
        }
    }
}
