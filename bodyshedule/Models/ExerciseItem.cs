using System.ComponentModel.DataAnnotations;

namespace bodyshedule.Models
{
    public class ExerciseItem
    {
        [Key] 
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuantityApproaches { get; set; }
        public int QuantityRepetions { get; set; }
        public int EventId { get; internal set; }

        public ExerciseItem(ExerciseItem item)
        {
            Title = item.Title;
            QuantityApproaches = item.QuantityApproaches;
            QuantityRepetions = item.QuantityRepetions;
        }

        public ExerciseItem() { }

    }
}
