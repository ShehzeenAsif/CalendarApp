using Microsoft.AspNetCore.Identity;

namespace CalendarApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}
