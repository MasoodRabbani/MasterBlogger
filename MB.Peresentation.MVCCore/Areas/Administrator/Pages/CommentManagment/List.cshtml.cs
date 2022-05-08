using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contact.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Peresentation.MVCCore.Areas.Administrator.Pages.CommentManagment
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> CommentViewModels { get; set; }
        private readonly ICommentApplication CommentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            CommentApplication = commentApplication;
        }
        public void OnGet()
        {
            CommentViewModels = CommentApplication.GetList();
        }

        public IActionResult OnPostConfirm(long Id)
        {
            CommentApplication.Confirm(Id);
            return RedirectToPage("./list");
        }
        public IActionResult OnPostCancel(long Id)
        {
            CommentApplication.Canceled(Id);
            return RedirectToPage("./list");
        }

    }
}
