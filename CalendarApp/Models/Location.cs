using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Models
{
    public class Location
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Event> Events { get; set; }
    }
}
