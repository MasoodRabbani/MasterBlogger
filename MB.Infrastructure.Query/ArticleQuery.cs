using MB.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
                .Include(s=>s.Comments)
                .Select(s => new ArticleQueryView
                {
                    Id = s.Id,
                    ArticleCategory = s.ArticleCategory.Title,
                    CreationDate = s.CreationDate.ToString(),
                    ShortDescription = s.ShortDescription,
                    Title = s.Title,
                    Image = s.Image,
                    Content = s.Content,
                    CommentCount = s.Comments.Count(s=>s.Status==Statuses.Confirm),
                    CommentQueryViews = MapComments(s.Comments.Where(x=>x.Status==Statuses.Confirm))
                }).FirstOrDefault(s=>s.Id==Id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> where)
        {
            var result = new List<CommentQueryView>();
            foreach (var i in where)
            {
                result.Add(new CommentQueryView()
                {
                    Name = i.Name,
                    CreationDate = i.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Message = i.Message
                });
            }

            return result;
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
                    Image = s.Image,
                    CommentCount = s.Comments.Count(s => s.Status == Statuses.Confirm)
                }).ToList();
        }
    }
}