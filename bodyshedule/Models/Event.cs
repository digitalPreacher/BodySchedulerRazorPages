using bodyshedule.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class Event
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным"), MaxLength(31)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным"), MaxLength(60)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным")]
        public DateTimeOffset StartTime { get; set; }

        [Required(ErrorMessage = "Это поле является обязательным")]
        public DateTimeOffset EndTime { get; set; }

        public ICollection<ExerciseItem> Items { get; set; } = new List<ExerciseItem>();
        public virtual ApplicationUser User { get; set; }

        public Event(IFormCollection form, ApplicationUser user, ICollection<ExerciseItem> itemList)
        {
            User = user;
            Items = itemList;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTimeOffset.Parse(form["Event.StartTime.LocalDateTime"].ToString()).ToUniversalTime();
            EndTime = DateTimeOffset.Parse(form["Event.EndTime.LocalDateTime"].ToString()).ToUniversalTime();
        }

        public void UpdateEvent(IFormCollection form, ApplicationUser user, ICollection<ExerciseItem> itemList) //Location location
        {
            User = user;
            Items = itemList;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTimeOffset.Parse(form["Event.StartTime.LocalDateTime"].ToString()).ToUniversalTime();
            EndTime = DateTimeOffset.Parse(form["Event.EndTime.LocalDateTime"].ToString()).ToUniversalTime();
        }

        public Event()
        {

        }
    }
}
