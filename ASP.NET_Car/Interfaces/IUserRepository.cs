using ASP.NET_Car.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Interfaces
{
    public interface IUserRepository
    {
        User Find(int id);
        User Delete(int id);
        User Add(User user);
        User Update(User user);
        User Login(User user);
        User Logout(User user);
    }
}
