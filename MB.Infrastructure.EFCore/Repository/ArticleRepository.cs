using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using MB.Application.Contact.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:BaseRepository<long,Article>,IArticleRepository
    {
        private readonly MasterBlogerContext context;

        public ArticleRepository(MasterBlogerContext context):base(context)
        {
            this.context = context;
        }


        public List<ArticleViewModel> GetList()
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

    }
}
