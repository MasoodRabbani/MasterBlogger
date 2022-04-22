using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository:IArticleCategoryRepositoory
    {
        private MasterBlogerContext context;

        public ArticleCategoryRepository(MasterBlogerContext context)
        {
            this.context = context;
        }

        public void Add(ArticleCategory model)
        {
            context.ArticleCategories.Add(model);
            context.SaveChanges();
        }

        public bool Exsitis(string title)
        {
            return context.ArticleCategories.Any(s => s.Title == title);
        }

        public ArticleCategory Get(int Id)
        {
            return context.ArticleCategories.FirstOrDefault(s => s.Id == Id);
        }

        public List<ArticleCategory> GetAll()
        {
            return context.ArticleCategories.OrderByDescending(s=>s.Id).ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
