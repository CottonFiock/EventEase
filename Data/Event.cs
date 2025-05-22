using System.ComponentModel.DataAnnotations;

namespace EventEase.Data
{

    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        public List<string> Attendees { get; set; } = new();

    }
}