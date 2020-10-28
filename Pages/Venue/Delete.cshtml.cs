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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Models.CovidTrackerContext _context;

        public DeleteModel(WebApplication1.Models.CovidTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = await _context.Venues.FindAsync(id);

            if (Venue != null)
            {
                _context.Venues.Remove(Venue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
