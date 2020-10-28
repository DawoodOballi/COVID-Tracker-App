using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApplication1.Pages.User
{
    public class DetailsModel : PageModel
    {
        public string Username => $"{CurrentUser.Title} {CurrentUser.FirstName} {CurrentUser.LastName}";
        public Models.User CurrentUser { get; set; }
        [BindProperty]
        public Models.Venue SelectedVenue { get; set; }
        public void OnGet(int? id)
        {
            CurrentUser = new Models.User { Title = "Mr", FirstName = "Dan", LastName = "Layland", UserID = 1, DOB = DateTime.Now };
            //get the user from the id and set CurrentUser
        }
        public IActionResult OnPost()
        {
            // check a venue has been selected
            // send venue ID and user ID to be updated and to set the user as checked in
            return RedirectToPage("./Index");
        }
    }
}
