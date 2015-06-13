using Events.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Events.Web.Models
{
    public class CommentViewModel
    {
        public string Text { get; set; }
        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return x => new CommentViewModel()
                {
                   Text = x.Text,
                   Author = x.Author.FullName
                };
            }
        }
    }
}
