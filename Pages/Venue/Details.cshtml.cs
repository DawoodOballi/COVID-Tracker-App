using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Pages.Venue
{
    public class DetailsModel : PageModel
    {
        private readonly UserHelper _userHelper;
        private readonly VenueHelper _venueHelper;

        public DetailsModel(CovidTrackerContext db)
        {
            _userHelper = new UserHelper(db);
            _venueHelper = new VenueHelper(db);
        }

        public Models.Venue Venue { get; set; }
        public IList<Models.UserCheckin> Users { get; set; }
        
        public void OnGet(int id)
        {
            Venue = _venueHelper.GetAllVenues().Where(v => v.VenueID == id).FirstOrDefault();
            Users = _venueHelper.GetUsersCheckedIn(id);
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = _venueHelper.GetAllVenues().Where(v => v.VenueID == id).FirstOrDefault();

            if (Venue == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
