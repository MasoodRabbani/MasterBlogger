using MB.Application.Contact.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBlogerContext context;

        public CommentRepository(MasterBlogerContext context)
        {
            this.context = context;
        }

        public void Create(Comment entity)
        {
            context.Comments.Add(entity);
            Save();
        }

        public Comment Get(long Id)
        {
            return context.Comments.FirstOrDefault(s => s.Id == Id);
        }

        public List<CommentViewModel> GetList()
        {
            return context.Comments.Include(s => s.Article)
                .Select(s => new CommentViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreationDate = s.CreationDate.ToString(),
                    Status = s.Status,
                    Artice = s.Article.Title,
                    Email = s.Email,
                    Message = s.Message
                }).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
