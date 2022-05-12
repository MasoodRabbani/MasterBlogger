using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepositoory
    {
        private MasterBlogerContext context;

        public ArticleCategoryRepository(MasterBlogerContext context) : base(context)
        {
            this.context = context;
        }
    }
}
