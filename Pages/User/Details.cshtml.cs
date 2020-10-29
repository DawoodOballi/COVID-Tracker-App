using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Pages.User
{
    public class DetailsModel : PageModel
    {
        UserHelper _uHelper;
        VenueHelper _vHelper;
        public string Username => $"{CurrentUser.Title} {CurrentUser.FirstName} {CurrentUser.LastName}";
        public IList<Models.Venue> Venues { get; set; }
        public Models.User CurrentUser { get; set; }
        public Models.Venue CurrentVenue { get; set; }
        public bool IsCheckedIn { get; set; }
        [BindProperty]
        public int SelectedVenueID { get; set; }
        public DetailsModel(CovidTrackerContext db)
        {
            _uHelper = new UserHelper(db);
            _vHelper = new VenueHelper(db);
        }

        public void OnGet(int id)
        {
            CurrentUser = _uHelper.GetUserFromID(id);
            IsCheckedIn = _uHelper.IsUserCheckedIn(id);
            CurrentVenue = _vHelper.GetCurrentVenueForUser(id);
            Venues = _vHelper.GetAllVenues();
        }
        public IActionResult OnPost(int id, bool checkout)
        {
            if (checkout)
            {
                _uHelper.CheckUserOut(id);
            }
            else
            {
                CurrentUser = _uHelper.GetUserFromID(id);
                if (SelectedVenueID == 0)
                {
                    ModelState.AddModelError("Venue", "Please select a venue");
                    IsCheckedIn = _uHelper.IsUserCheckedIn(id);
                    CurrentVenue = _vHelper.GetCurrentVenueForUser(id);
                    Venues = _vHelper.GetAllVenues();
                    return Page();
                }
                _uHelper.CheckUserIn(CurrentUser.UserID, SelectedVenueID);
            }
            return RedirectToPage("./Index");
        }
    }
}
