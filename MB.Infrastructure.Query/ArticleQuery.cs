using MB.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBlogerContext context;

        public ArticleQuery(MasterBlogerContext context)
        {
            this.context = context;
        }

        public ArticleQueryView GetArticleQuery(long Id)
        {
            return context.Articles.Include(s => s.ArticleCategory)
                .Select(s => new ArticleQueryView
                {
                    Id = s.Id,
                    ArticleCategory = s.ArticleCategory.Title,
                    CreationDate = s.CreationDate.ToString(),
                    ShortDescription = s.ShortDescription,
                    Title = s.Title,
                    Image = s.Image,
                    Content = s.Content
                }).FirstOrDefault(s=>s.Id==Id);
        }

        public List<ArticleQueryView> GetArticles()
        {
            return context.Articles.Include(s => s.ArticleCategory)
                .Select(s=>new ArticleQueryView
            {
                    Id = s.Id,
                    ArticleCategory = s.ArticleCategory.Title,
                    CreationDate = s.CreationDate.ToString(),
                    ShortDescription = s.ShortDescription,
                    Title = s.Title,
                    Image = s.Image
            }).ToList();
        }
    }
}