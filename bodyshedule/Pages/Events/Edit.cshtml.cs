using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bodyshedule.Data;
using bodyshedule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;

namespace bodyshedule.Pages.Events
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(IDAL dal, UserManager<ApplicationUser> userManager)
        {
            _dal = dal;
            _userManager = userManager;
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var getEvent = await _dal.GetEvent(id);

            if (id == null || getEvent == null)
            {
                return NotFound();
            }
            else
            {
                Event = getEvent; ;
            }

            return Page();


        }

        public async Task<IActionResult> OnPostAsync(IFormCollection form)
        {
            var user = await _userManager.GetUserAsync(User);
            //var @event = await _dal.GetEvent(int.Parse(form["Event.id"]));
            try
            {
                _dal.UpdateEvent(form, user);
                TempData["Aler"] = "Success! You modified an getEvent for: " + form["Event.name"];
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
            }
            //Event = @event;
            return Page();

        }
    }
}
