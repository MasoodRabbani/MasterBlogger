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
        public void OnGet(string Msg="")
        {
            if (Msg!="")
            {
                ViewData["Massage"] = Msg;
            }
            
            Article = ArticleApplication.GetList();
        }

        public RedirectToPageResult OnPostRemove(long Id)
        {
            ArticleApplication.Remove(Id);
            return RedirectToPage();
        }
        public RedirectToPageResult OnPostActive(long Id)
        {
            ArticleApplication.Active(Id);
            return RedirectToPage();
        }
    }
}
