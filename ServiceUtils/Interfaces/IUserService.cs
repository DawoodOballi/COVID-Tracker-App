using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ServiceUtils.Interfaces
{
    public interface IUserService
    {
        void AddNewUser(User user);
        Task AddNewUserAsync(User user);
        void AddUserCheckin(UserCheckin checkin);
        void CheckOut(int CheckInId, DateTime checkoutTime);
        User GetUserByID(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}