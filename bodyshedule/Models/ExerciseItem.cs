using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class ExerciseItem
    {
        [Key] 
        public int Id { get; set; }
        [Required, MaxLength(60)]
        public string Title { get; set; }
        public int QuantityApproaches { get; set; }
        public int QuantityRepetions { get; set; }
        public int EventId { get; internal set; }

        public ExerciseItem() { }

    }
}
