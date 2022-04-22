using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepositoory
    {
        List<ArticleCategory> GetAll();
        void Add(ArticleCategory model);
        ArticleCategory Get(int Id);
        void Save();
        bool Exsitis(string title);
    }
}
