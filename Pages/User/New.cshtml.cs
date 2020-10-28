using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.ServiceUtils;

namespace WebApplication1.Pages.User
{
    public class NewModel : PageModel
    {
        UserService _uService;

        [BindProperty]
        public Models.User NewUser { get; set; }
        public NewModel(CovidTrackerContext db)
        {
            _uService = new UserService(db);
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
                await _uService.AddNewUserAsync(NewUser);
                return new JsonResult(new { success = true });
            }
            return Page();
        }
    }
}
