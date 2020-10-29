using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ServiceUtils;
using WebApplication1.ServiceUtils.Interfaces;

namespace WebApplication1.Helpers
{
    public class UserHelper
    {
        IUserService _uService;

        public UserHelper(IUserService service)
        {
            _uService = service;
        }

        public Models.User GetUserFromID(int id)
        {
            return _uService.GetUserByID(id);
        }

        public bool IsUserCheckedIn(int SelectedUserId)
        {
            var user = _uService.GetUserByID(SelectedUserId);
            return user.CheckIns.Where(x => x.CheckedOutAt == null).Count() > 0;
        }

        public void CheckUserIn(int SelectedUserId, int SelectedVenueId)
        {

            _uService.AddUserCheckin(new UserCheckin
            {
                UserID = SelectedUserId,
                CheckedInAt = DateTime.Now,
                VenueID = SelectedVenueId
            });
        }

        public void CheckUserOut(int SelectedUserId)
        {
            var userCheckin = _uService.GetUserByID(SelectedUserId).CheckIns.Where(x => x.CheckedOutAt == null).FirstOrDefault();
            _uService.CheckOut(userCheckin.UserCheckinID, DateTime.Now);
        }
    }
}
