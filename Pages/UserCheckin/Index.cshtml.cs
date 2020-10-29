using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.UserCheckin
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.CovidTrackerContext _context;

        public IndexModel(WebApplication1.Models.CovidTrackerContext context)
        {
            _context = context;
        }

        public IList<Models.UserCheckin> UserCheckin { get; set; }
        [BindProperty]
        public string SearchString { get; set; }
        public SelectList Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        public async Task OnGetAsync(string SearchString)
        {
           
            IQueryable<string> userQuery = from u in _context.UserCheckIns
                                           orderby u.User
                                           select u.User.FirstName;

            var user = await _context.UserCheckIns.Include(u => u.User).Include(u => u.Venue).ToListAsync();
                   
            if (!string.IsNullOrEmpty(SearchString))
            {
                user = user.Where(s => s.User.FirstName.Contains(SearchString)).ToList();
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                user = user.Where(x => x.User.FirstName == UserName).ToList();
            }

            Users = new SelectList(await userQuery.Distinct().ToListAsync());


            UserCheckin = user;
               
        }
    }
}
