using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; }   
    }
}
