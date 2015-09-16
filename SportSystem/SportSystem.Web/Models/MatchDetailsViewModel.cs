namespace SportSystem.Web.Models
{
    using System.Collections.Generic;

    using Data;

    public class MatchDetailsViewModel : MatchViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}