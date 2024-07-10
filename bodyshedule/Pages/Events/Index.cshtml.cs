using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using bodyshedule.Data;
using bodyshedule.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace bodyshedule.Pages.Events
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IDAL dal, UserManager<ApplicationUser> userManager)
        {
            _dal = dal;
            _userManager = userManager;
        }


        public IList<Event> Event { get;set; } = default!;

        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageNumber)
        {
            var pageSize = 10; 
            var currentPage = pageNumber ?? 1;
            var user = await _userManager.GetUserAsync(User);
            var myEvents = _dal.GetMyEvents(user.Id);

            TotalPages = (int)Math.Ceiling(myEvents.Count / (double)pageSize);

            if (currentPage > TotalPages || currentPage < 1)
            {
                return NotFound();
            } 
            else
            {
                var currentEventList = myEvents.Skip((currentPage - 1) * pageSize)
                    .Take(pageSize).ToList();

                Event = currentEventList;
            }

            return Page();
        }
    }
}
