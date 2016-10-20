namespace MvcTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        public string AuthorIp { get; set; }

        [Required]
        public int Points { get; set; }
    }
}
