using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Pages
{
    public class IndexModel : PageModel
    {
        public List<ArticleQueryView> ArticleQueryViews { get; set; }
        private readonly IArticleQuery ArticleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            ArticleQuery = articleQuery;
        }
        public void OnGet()
        {
            ArticleQueryViews = ArticleQuery.GetArticles();
        }
    }
}