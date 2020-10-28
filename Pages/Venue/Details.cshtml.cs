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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Models.CovidTrackerContext _context;

        public DetailsModel(WebApplication1.Models.CovidTrackerContext context)
        {
            _context = context;
        }

        public Models.Venue Venue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = await _context.Venues.FirstOrDefaultAsync(m => m.VenueID == id);

            if (Venue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
