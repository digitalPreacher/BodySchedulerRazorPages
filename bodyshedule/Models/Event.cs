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
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Это поле является обязательным")]
        public DateTime EndTime { get; set; }

        public ICollection<ExerciseItem> Items { get; set; } = new List<ExerciseItem>();
        public virtual ApplicationUser User { get; set; }

        public Event(IFormCollection form, ApplicationUser user, ICollection<ExerciseItem> itemList)
        {
            User = user;
            Items = itemList;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
        }

        public void UpdateEvent(IFormCollection form, ApplicationUser user, ICollection<ExerciseItem> itemList) //Location location
        {
            User = user;
            Items = itemList;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
        }

        public Event()
        {

        }
    }
}
