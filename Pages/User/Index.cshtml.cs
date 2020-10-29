using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers;
using WebApplication1.ServiceUtils;

namespace WebApplication1.Pages.User
{
    public class IndexModel : PageModel
    {
        UserHelper _uHelper;

        public IndexModel(Models.CovidTrackerContext context)
        {
            _uHelper = new UserHelper(new UserService(context));
        }

        public IList<Models.User> Users { get; set; }
        

        public async Task OnGet()
        {
            var users = await _uHelper.GetAllUsersAsync();
            Users = users.ToList();
        }
    }
}
