using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using MB.Application.Contact.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommentRepository commentRepository;

        public CommentApplication(IUnitOfWork unitOfWork, ICommentRepository commentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.commentRepository = commentRepository;
        }

        public void Add(AddComment Command)
        {
            unitOfWork.BeginTran();
            commentRepository.Create(new Comment(Command.Name,Command.Email,Command.Message,Command.ArticleId));
            unitOfWork.CommitTran();
        }

        public void Canceled(long Id)
        {
            unitOfWork.BeginTran();
            var model = commentRepository.Get(Id);
            model.Canceled();
            unitOfWork.CommitTran();
            //commentRepository.Save();
        }

        public void Confirm(long Id)
        {
            unitOfWork.BeginTran();
            var model = commentRepository.Get(Id);
            model.Confirm();
            unitOfWork.CommitTran();
            //commentRepository.Save();
        }

        public List<CommentViewModel> GetList()
        {
            return commentRepository.Getlist();
        }
    }
}
