using ASP.NET_Car.Interfaces;
using ASP.NET_Car.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Repository
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        public UserRepository(DataContext context) 
        {
            _context = context;
        }
        public User Add(User user)
        {
            user.ShoppingCart = new ShoppingCart();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public User Find(int id)
        {
            return _context.Users.FirstOrDefault(u=> u.ID == id);
        }

        public User Login(User credentials)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == credentials.Email && u.Password == credentials.Password);
            if (user is null)
            {
                throw new NullReferenceException("Site was unable to find user in Database...");
            }
            user.IsLoggedIn = true;
            _context.SaveChanges();
            return user;
        }

        public User Logout(User user)
        {
            var userToLogOut = _context.Users.FirstOrDefault(u =>u == user);
            user.IsLoggedIn = false;
            _context.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
