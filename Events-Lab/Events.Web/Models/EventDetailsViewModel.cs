namespace Events.Web.Models
{
    using Events.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Event, EventDetailsViewModel>> ViewModel
        {
            get
            {
                return x => new EventDetailsViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Comments = x.Comments
                        .AsQueryable()
                        .Select(CommentViewModel.ViewModel),
                    AuthorId = x.Author.Id
                };
            }
        }
    }
}