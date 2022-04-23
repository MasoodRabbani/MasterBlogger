using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contact.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBlogerContext context;

        public ArticleRepository(MasterBlogerContext context)
        {
            this.context = context;
        }

        public void Add(Article entity)
        {
            context.Articles.Add(entity);
            context.SaveChanges();
        }

        public Article Get(long Id)
        {
            return context.Articles.FirstOrDefault(s => s.Id == Id);
        }

        public List<ArticleViewModel> GetAll()
        {
            return context.Articles.Include(s=>s.ArticleCategory).Select(s => new ArticleViewModel()
            {
                Id = s.Id,
                Title = s.Title,
                IsDeleted = s.IsDeleted,
                CreationDate = s.CreationDate.ToString(),
                ArticleCategory = s.ArticleCategory.Title
            }).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
