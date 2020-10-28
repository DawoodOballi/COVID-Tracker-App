using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Pages.Venue
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Models.CovidTrackerContext _context;

        public IndexModel(WebApplication1.Models.CovidTrackerContext context)
        {
            _context = context;
        }

        public IList<Models.Venue> Venue { get;set; }

        public async Task OnGetAsync()
        {
            Venue = await _context.Venues.ToListAsync();
        }
    }
}
