using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contact.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void Add(AddComment Command)
        {
            commentRepository.Create(new Comment(Command.Name,Command.Email,Command.Message,Command.ArticleId));
        }

        public void Canceled(long Id)
        {
            var model = commentRepository.Get(Id);
            model.Canceled();
            commentRepository.Save();
        }

        public void Confirm(long Id)
        {
            var model = commentRepository.Get(Id);
            model.Confirm();
            commentRepository.Save();
        }

        public List<CommentViewModel> GetList()
        {
            return commentRepository.GetList();
        }
    }
}
