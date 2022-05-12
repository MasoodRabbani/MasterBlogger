using MB.Application.Contact.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository:BaseRepository<long,Comment>,ICommentRepository
    {
        private readonly MasterBlogerContext context;

        public CommentRepository(MasterBlogerContext context):base(context)
        {
            this.context = context;
        }


        public List<CommentViewModel> Getlist()
        {
            return context.Comments.Include(s => s.Article)
                .Select(s => new CommentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreationDate = s.CreateDateTime.ToString(),
                    Status = s.Status,
                    Artice = s.Article.Title,
                    Email = s.Email,
                    Message = s.Message
                }).ToList();
        }
    }
}
