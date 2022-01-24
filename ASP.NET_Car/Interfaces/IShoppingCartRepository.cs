using ASP.NET_Car.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Interfaces
{
    interface IShoppingCartRepository
    {
        Cars AddToBucket(int userID, int carID);
        void RemoveFromBucket(int userID, int carID);
        void ClearBucket(int userID);
    }
}
