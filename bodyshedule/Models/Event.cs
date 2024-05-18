using bodyshedule.Data;
using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class Event
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //public virtual Location Location { get; set; }  
        public virtual ApplicationUser User { get; set; }

        public Event(IFormCollection form, ApplicationUser user)
        {
            User = user;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            //Location = location;
        }

        public void UpdateEvent(IFormCollection form, ApplicationUser user) //Location location
        {
            User = user;
            Name = form["Event.name"].ToString();
            Description = form["Event.description"].ToString();
            StartTime = DateTime.Parse(form["Event.StartTime"].ToString());
            EndTime = DateTime.Parse(form["Event.EndTime"].ToString());
            //Location = location;
        }

        public Event()
        {

        }
    }
}
