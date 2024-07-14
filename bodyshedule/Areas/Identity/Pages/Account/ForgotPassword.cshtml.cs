using bodyshedule.Data;
using bodyshedule.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Matching;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Web;

namespace bodyshedule.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDAL _dAL;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IDAL dAL)
        {
            _userManager = userManager;
            _dAL = dAL;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "������� Email")]
            [Required(ErrorMessage = "���� ����������� ��� ����������")]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "������� ��������� �����")]
            [Required(ErrorMessage = "���� ����������� ��� ����������")]
            public string SecretWord { get; set; }
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
                ModelState.AddModelError("", "Email �� ������");
                return Page();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var link = Url.PageLink(
                "./ResetPassword",
                pageHandler: null,
                values: new { code = token, email = Input.Email },
                protocol: Request.Scheme

                );

            var isValidateUser = _dAL.CheckUser(user.Id, Input.SecretWord);
            if (isValidateUser)
            {
                return Redirect(link);
            }
            else 
            {
                ModelState.AddModelError("", "������� ������� ��������� �����");
            }

            return Page();
        }
    }
}
