using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ServiceUtils.Interfaces;

namespace WebApplication1.ServiceUtils
{
    public class UserService : IUserService
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
        public User GetUserByID(int id)
        {
            return _db.Users.Where(x => x.UserID == id).Include(x => x.CheckIns).FirstOrDefault();
        }
        public void AddUserCheckin(UserCheckin checkin)
        {
            _db.UserCheckIns.Add(checkin);
            _db.SaveChanges();
        }
        public void CheckOut(int CheckInId, DateTime checkoutTime)
        {
            var record = _db.UserCheckIns.Where(x => x.CheckedOutAt == null && x.UserCheckinID == CheckInId).FirstOrDefault();
            record.CheckedOutAt = checkoutTime;
            _db.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _db.Users.Include(x => x.CheckIns).ToListAsync();
        }
    }
}
