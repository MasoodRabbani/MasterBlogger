using MB.Application.Contact.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetAll();
        void Add(Article entity);
        Article Get(long Id);
        void Save();
    }
}
