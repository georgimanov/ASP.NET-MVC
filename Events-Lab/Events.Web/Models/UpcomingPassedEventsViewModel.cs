namespace Events.Web.Models
{
    using System.Collections.Generic;

    public class UpcomingPassedEventsViewModel
    {
        public IEnumerable<EventViewModel> UpcommingEvents { get; set; }
        public IEnumerable<EventViewModel> PassedEvents { get; set; }
    }
}