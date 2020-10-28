using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ServiceUtils
{
    public class UserService
    {
        CovidTrackerContext _db;
        public UserService(CovidTrackerContext db)
        {
            _db = db;
        }
        public void AddNewUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public async Task AddNewUserAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}
