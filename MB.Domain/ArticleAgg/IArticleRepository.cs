using MB.Application.Contact.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
    }
}
