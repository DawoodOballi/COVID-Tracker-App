using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Helpers;
using WebApplication1.Models;
using WebApplication1.ServiceUtils;

namespace WebApplication1.Pages.User
{
    public class NewModel : PageModel
    {
        UserHelper _uHelper;

        [BindProperty]
        public Models.User NewUser { get; set; }
        public NewModel(CovidTrackerContext db)
        {
            _uHelper = new UserHelper(new UserService(db));
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (NewUser.Title == "Choose...")
            {
                ModelState.AddModelError("Title", "Please select a Title");
            }
            if (ModelState.IsValid)
            {
                await _uHelper.AddNewUserAsync(NewUser);
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
