using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBlogerContext context;

        public ArticleRepository(MasterBlogerContext context)
        {
            this.context = context;
        }
    }
}
