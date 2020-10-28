using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CovidTrackerContext _context;

        public IndexModel(CovidTrackerContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; }
        

        public async Task OnGet()
        {
            var users = from u in _context.Users
                        select u;
            Users = await users.ToListAsync();
        }
    }
}
