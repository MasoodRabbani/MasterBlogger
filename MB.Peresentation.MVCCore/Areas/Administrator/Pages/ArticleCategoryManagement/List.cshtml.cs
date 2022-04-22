using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Area.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategorys { get; set; }

        private IArticleCategoryApplication CategoryApplication;

        public ListModel(IArticleCategoryApplication categoryApplication)
        {
            CategoryApplication = categoryApplication;
        }
        public void OnGet()
        {
            ArticleCategorys = CategoryApplication.List();
        }

        public IActionResult OnPostRemove(int Id)
        {
            CategoryApplication.Remove(Id);
            return RedirectToPage();
        }
        public IActionResult OnPostActive(int Id)
        {
            CategoryApplication.Active(Id);
            return RedirectToPage();
        }
    }
}
