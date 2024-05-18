using bodyshedule.Data;
using bodyshedule.Helpers;
using bodyshedule.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bodyshedule.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, IDAL dAl, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _dal = dAl;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            var myEvents = _dal.GetMyEvents(user.Id);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(myEvents);

            return Page();
        }
    }
}
