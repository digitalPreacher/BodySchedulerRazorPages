using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using bodyshedule.Data;
using bodyshedule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace bodyshedule.Pages.Events
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IDAL _dal;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(IDAL dal, UserManager<ApplicationUser> userManager)
        {
            _dal = dal;
            _userManager = userManager;
            ExerciseList = GetExerciseList();
        }

        public  IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        public List<string> ExerciseList {  get; set; }

        public async Task<IActionResult> OnPostAsync(IFormCollection form)
        {
            var user = await _userManager.GetUserAsync(User);
            var itemsList = new List<ExerciseItem>();
            int itemCount = 1;
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
        public List<string> GetExerciseList()
        {
            // Replace this with your actual logic to retrieve data from the database
            // This is an example assuming you have a table with "ExerciseName" values
            List<string> exercises = new List<string>();
            exercises.Add("Push-ups");
            exercises.Add("Squats");
            exercises.Add("Lunges");
            exercises.Add("Deadlifts");
            return exercises;
        }

    }
}
