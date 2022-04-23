using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Pages
{
    public class DetailsModel : PageModel
    {
        public ArticleQueryView ArticleQueryView { get; set; }
        private readonly IArticleQuery ArticleQuery;

        public DetailsModel(IArticleQuery articleQuery)
        {
            ArticleQuery = articleQuery;
        }
        public void OnGet(int Id)
        {
            ArticleQueryView = ArticleQuery.GetArticleQuery(Id);
        }
    }
}