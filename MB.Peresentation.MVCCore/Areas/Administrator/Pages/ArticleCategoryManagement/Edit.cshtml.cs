using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contact.ArticleCategory;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RenameArticleCategory RenameArticleCategory { get; set; }
        private IArticleCategoryApplication articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(int Id)
        {
            RenameArticleCategory = articleCategoryApplication.Get(Id);
        }

        public IActionResult OnPost()
        {
            articleCategoryApplication.Rename(RenameArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
