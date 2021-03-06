using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contact.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticle Command);
        void Edit(EditArticle Command);
        EditArticle Get(long Id);
        void Remove(long Id);
        void Active(long Id);
    }
}
