using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Key]
        public override int Id { get; set; } = default!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.Now;
        //{
        //    get { return DateTimeOffset.Now; }
        //    set { value.ToUniversalTime(); }
        //}

    }
}
