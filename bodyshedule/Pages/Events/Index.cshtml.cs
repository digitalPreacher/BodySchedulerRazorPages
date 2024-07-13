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
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

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

        public IList<Event> Event { get; set; } = default!;

        private DateTime _minDate = DateTime.MinValue;
        public int TotalPages { get; set; }
        public int FilterTotalPage { get; set; }

        private bool _isFilterActive = false;
        public bool IsFilterActive
        {
            get => _isFilterActive;
            set => _isFilterActive = value;

        }

        private DateTime? _startDateCreated;
        public DateTime FilterStartDateTime
        {
            get {
                return this._startDateCreated == DateTime.MinValue
                 ? DateTime.Now : this._startDateCreated.Value;
            }
            set
            {
                 this._startDateCreated = value;
            }
        }

        private DateTime? _endDateCreated;
        public DateTime FilterEndDateTime {
            get
            {
                return this._endDateCreated == DateTime.MinValue
                 ? DateTime.Now.AddDays(1)
                 : this._endDateCreated.Value;
            }
            set
            {
                this._endDateCreated = value;
            }
        }


        public async Task<IActionResult> OnGetAsync(int? pageNumber, DateTime startDateTime, 
            DateTime endDateTime, bool isFilterActive)
        {
            var pageSize = 10; 
            var currentPage = pageNumber ?? 1;
            FilterStartDateTime = startDateTime.ToUniversalTime();
            FilterEndDateTime = endDateTime.ToUniversalTime();
            IsFilterActive = isFilterActive;
            var user = await _userManager.GetUserAsync(User);

            if (IsFilterActive)
            {
                IQueryable<Event> filterEvents = _dal.GetMyFilteringEvents(user.Id,
                    FilterStartDateTime.ToUniversalTime(), FilterEndDateTime.ToUniversalTime());

                FilterTotalPage = (int)Math.Ceiling(filterEvents.ToList().Count / (double)pageSize);

                if (pageNumber < 1 || pageNumber > FilterTotalPage) 
                {
                    return NotFound();
                } 
                else
                {
                    var currentFilterEventList = filterEvents.Skip((currentPage - 1) * pageSize)
                        .Take(pageSize).ToList();

                    FilterStartDateTime = startDateTime;
                    FilterEndDateTime = endDateTime;
                
                    Event = currentFilterEventList.ToList();
                }
            } 
            else
            {
                var myEvents = _dal.GetMyEvents(user.Id);
                TotalPages = (int)Math.Ceiling(myEvents.Count / (double)pageSize);

                if (pageNumber < 1 || pageNumber > TotalPages)
                {
                    return NotFound();
                } 
                else
                {
                    FilterStartDateTime = DateTime.Now;
                    FilterEndDateTime = DateTime.Now.AddDays(1);
                    
                    var currentEventList = myEvents.Skip((currentPage - 1) * pageSize)
                        .Take(pageSize).ToList();

                    Event = currentEventList;
                }

            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAll()
        {
            var user = await _userManager.GetUserAsync(User);
            _dal.DeleteMyEvents(user.Id);

            return RedirectToPage("./Index");
        }
    }
}
