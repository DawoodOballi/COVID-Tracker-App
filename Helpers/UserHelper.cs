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
        UserHelper userHelper;

        public UserHelper(CovidTrackerContext db)
        {
            _db = db;
        }

        public bool IsUserCheckedIn(int SelectedUserId)
        {
            var selectedUserWithCheckin = _db.Users.Where(x => x.UserID == SelectedUserId).Include(x => x.CheckIns).ToString();
            if (selectedUserWithCheckin != null)
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
                }
                );
            _db.SaveChanges();
        }

        public void CheckUserOut(int SelectedUserId, int SelectedVenueId)
        {
            _db.UserCheckIns.Update(
                    new UserCheckin
                    {
                        UserID = SelectedUserId,
                        CheckedOutAt = DateTime.Now,
                        VenueID = SelectedVenueId
                    }
                    );
            _db.SaveChanges();

        }

    }
}
