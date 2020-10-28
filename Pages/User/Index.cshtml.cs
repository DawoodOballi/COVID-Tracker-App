using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly Models.CovidTrackerContext _context;

        public IndexModel(Models.CovidTrackerContext context)
        {
            _context = context;
        }

        public IList<Models.User> Users { get; set; }
        

        public async Task OnGet()
        {
            var users = from u in _context.Users
                        select u;
            Users = await users.ToListAsync();
        }
    }
}
