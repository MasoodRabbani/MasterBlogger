using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contact.Article;
using MB.Application.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Peresentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticle ViewModel { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }

        private IArticleCategoryApplication articleCategoryApplication;
        private IArticleApplication articleApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
            this.articleApplication = articleApplication;
        }
        public void OnGet(long Id)
        {
            ViewModel = articleApplication.Get(Id);
            SelectListItems = articleCategoryApplication.List()
                .Select(s => new SelectListItem(s.Title, s.Id.ToString())).ToList();
        }

        public IActionResult OnPost()
        {
            articleApplication.Edit(ViewModel);
            return RedirectToPage("./List", new {Msg = "عملیات ویرایش با موفقیت انجام شد"});
        }
    }
}
