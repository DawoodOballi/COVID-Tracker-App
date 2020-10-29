using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class UserHelper
    {
        CovidTrackerContext _db;

        public UserHelper(CovidTrackerContext db)
        {
            _db = db;
        }

        public Models.User GetUserFromID(int id)
        {
            return _db.Users.Where(x => x.UserID == id).Include(x => x.CheckIns).FirstOrDefault();
        }

        public bool IsUserCheckedIn(int SelectedUserId)
        {
            var selectedUserWithCheckin = _db.Users.Include(x => x.CheckIns).Where(x => x.UserID == SelectedUserId).FirstOrDefault();
            if (selectedUserWithCheckin.CheckIns.Where(x => x.CheckedOutAt == null).Count() > 0)
            {
                return true;
            }
            else return false;
        }

        public void CheckUserIn(int SelectedUserId, int SelectedVenueId)
        {
            _db.UserCheckIns.Add(
                new UserCheckin
                {
                    UserID = SelectedUserId,
                    CheckedInAt = DateTime.Now,
                    VenueID = SelectedVenueId
                });
            _db.SaveChanges();
        }

        public void CheckUserOut(int SelectedUserId)
        {
            var allCheckIns = _db.UserCheckIns.Where(x => x.UserID == SelectedUserId).Where(x => x.CheckedOutAt == null).FirstOrDefault();
            allCheckIns.CheckedOutAt = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
