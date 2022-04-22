using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contact.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Article { get; set; }
        private readonly IArticleApplication ArticleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            ArticleApplication = articleApplication;
        }
        public void OnGet()
        {
            Article = ArticleApplication.GetList();
        }
    }
}
