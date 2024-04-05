using System.ComponentModel.DataAnnotations;

namespace CalendarApp.Models
{
    public class Event
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Location Location { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Event(IFormCollection form, Location location) 
        {
            id = int.Parse(form["id"]);
            Name = form["Name"];
            Description = form["Description"];
            StartTime = DateTime.Parse(form["StartTime"]);
            EndTime = DateTime.Parse(form["EndTime"]);
            Location = location;
        }
        public void UpdateEvent(IFormCollection form, Location location)
        {
            id = int.Parse(form["id"]);
            Name = form["Name"];
            Description = form["Description"];
            StartTime = DateTime.Parse(form["StartTime"]);
            EndTime = DateTime.Parse(form["EndTime"]);
            Location = location;
        }
        public Event() { }

     }
}
