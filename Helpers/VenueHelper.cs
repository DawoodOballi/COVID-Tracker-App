using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ServiceUtils;

namespace WebApplication1.Helpers
{
    public class VenueHelper
    {
        private readonly CovidTrackerContext _db;
        public VenueHelper(CovidTrackerContext context)
        {
            _db = context;
        }

        public IList<UserCheckin> GetUsersCheckedIn(int id)
        {
            var getUsersCheckedIn = _db.UserCheckIns.Include(u => u.User)
                .Where(u => u.VenueID == id)
                .Where(u => u.CheckedOutAt == null);

            return getUsersCheckedIn.ToList(); ;
        }

        public IList<UserCheckin> GetUsersCheckedOut(int id)
        {
            var getUsersCheckedOut = _db.UserCheckIns.Include(u => u.User)
                .Where(u => u.VenueID == id)
                .Where(u => u.CheckedOutAt != null);

            return getUsersCheckedOut.ToList();
        }
    }
}
