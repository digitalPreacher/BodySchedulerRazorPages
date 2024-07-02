using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bodyshedule.Data;
using bodyshedule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;

namespace bodyshedule.Pages.Events
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(IDAL dal, UserManager<ApplicationUser> userManager)
        {
            _dal = dal;
            _userManager = userManager;
        }


        public Event Event { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var @event = await _dal.GetEvent(id);

            if (id == null || @event == null)
            {
                return NotFound();
            }
            else 
            {
                Event = @event;
            }

            return Page();
        }
    }
}
