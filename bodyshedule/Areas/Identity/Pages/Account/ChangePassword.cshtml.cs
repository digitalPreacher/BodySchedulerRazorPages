using bodyshedule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Areas.Identity.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Поле обязательно для заполнения")]
            [EmailAddress]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Поле обязательно для заполнения")]
            [Display(Name = "Текущий пароль")]
            public string CurentPassword { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Поле обязательно для заполнения")]
            [Display(Name = "Новый пароль")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Поле обязательно для заполнения")]
            [Display(Name = "Подтверждение пароля")]
            [Compare("NewPassword", ErrorMessage = "Данные не совподают")]
            public string ConfirmNewPassword { get; set; }


        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email не найден");
                return Page();
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(user, Input.CurentPassword, Input.NewPassword);
            if (result.Succeeded) 
            {
                return RedirectToPage("./ResetPasswordConfirmation");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
            
        }
    }
}
