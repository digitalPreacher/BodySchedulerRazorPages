using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using bodyshedule.Data;
using bodyshedule.Models;

namespace bodyshedule.Pages.Events
{
    [Authorize]
    public class CopyModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly UserManager<ApplicationUser> _userManager;

        public CopyModel(IDAL dal, UserManager<ApplicationUser> userManager)
        {
            _dal = dal;
            _userManager = userManager;
        }

        public List<string> ExerciseList { get; set; }
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

            var exerciseList = _dal.GetExercises();
            List<string> exercises = new List<string>();
            foreach (var item in exerciseList)
            {
                exercises.Add(item.Title);
            }

            ExerciseList = exercises;

            return Page();

        }

        [BindProperty]
        public Event Event { get; set; }
        public async Task<IActionResult> OnPostAsync(IFormCollection form)
        {
            var user = await _userManager.GetUserAsync(User);

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

            _dal.CreateEvent(form, user, itemsList);

            return RedirectToPage("./Index");
        }
    }
}
