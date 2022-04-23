using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contact.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ICommentApplication commentApplication;
        public ArticleQueryView ArticleQueryView { get; set; }
        private readonly IArticleQuery ArticleQuery;

        public DetailsModel(ICommentApplication commentApplication, IArticleQuery articleQuery)
        {
            this.commentApplication = commentApplication;
            ArticleQuery = articleQuery;
        }
        public void OnGet(int Id)
        {
            ArticleQueryView = ArticleQuery.GetArticleQuery(Id);
        }

        public IActionResult OnPost(AddComment Command)
        {
            commentApplication.Add(Command);
            return RedirectToPage(new {Id=Command.ArticleId});
        }
    }
}