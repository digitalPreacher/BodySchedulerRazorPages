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
using System.Diagnostics;

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

            try
            {
                var itemsList = new List<ExerciseItem>();
                int itemCount = 0;
                while (form.ContainsKey($"ExerciseItem.{itemCount}.Title"))
                {
                    itemsList.Add(new ExerciseItem
                    {
                        Title = form[$"ExerciseItem.{itemCount}.Title"].ToString(),
                        QuantityApproaches = int.Parse(form[$"ExerciseItem.{itemCount}.QuantityApproaches"]),
                        QuantityRepetions = int.Parse(form[$"ExerciseItem.{itemCount}.QuantityRepetions"])
                    });
                    itemCount++;
                }
                _dal.UpdateEvent(form, user, itemsList);

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error occurred: " + ex.Message);
            }

            return Page();

        }
    }
}
