namespace SportSystem.Web.Models
{
    using System.Collections.Generic;

    public class MatchesViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }
    }
}